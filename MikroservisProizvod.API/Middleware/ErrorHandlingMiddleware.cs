
using Common.Logger;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MikroservisProizvod.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        #region Fields

        private RequestDelegate _next;
        private ITextFileAccessor _textFileAccessor;

        #endregion

        #region Constructor
        public ErrorHandlingMiddleware(RequestDelegate next, ITextFileAccessor accessor)
        {
            _next = next;
            _textFileAccessor = accessor;
        }
        #endregion

        #region Methods
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; // 500

            if (ex is FluentValidation.ValidationException)
                code = HttpStatusCode.BadRequest; //400

            string result;

            if(code == HttpStatusCode.InternalServerError)
            {
                var errorMessage = ex.Message; // ovo bi trebalo logovati, a korisniku prikazati gresku ispod

                 result = JsonConvert.SerializeObject(
                    new
                    {
                        error = "Desila se neocekivana greska na serveru."
                    });
            } 
            else
            {
                result = JsonConvert.SerializeObject(
                   new
                   {
                       error = ex.Message
                   });
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            _textFileAccessor.WriteNewLine("Desila se neocekivana greska na serveru, Greska: " + ex.Message);

            return context.Response.WriteAsync(result);

        }

        #endregion
    }
}
