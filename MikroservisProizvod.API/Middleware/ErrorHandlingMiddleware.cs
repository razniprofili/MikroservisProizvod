
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
        private ILoggTextFileAccessor _textFileAccessor;

        #endregion

        #region Constructor
        public ErrorHandlingMiddleware(RequestDelegate next, ILoggTextFileAccessor accessor)
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

            var errors = new List<object>();

            switch (ex)
            {
                case FluentValidation.ValidationException validationEx:
                    code = HttpStatusCode.UnprocessableEntity;
                    foreach(var exception in validationEx.Errors)
                    {
                        errors.Add(new { property = exception.PropertyName, error = exception.ErrorMessage });
                    }
                    break;
                default:
                    errors.Add(new { error = ex.Message });
                    break;
            }
            

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            _textFileAccessor.WriteNewLine("Desila se neocekivana greska na serveru, Greska: " + ex.Message);

            return context.Response.WriteAsync(JsonConvert.SerializeObject(errors));

        }

        #endregion
    }
}
