
using Common.Logger;
using Microsoft.AspNetCore.Http;
using MikroServisProizvod.Application.Exceptions;
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

            object errorResponse;
            var errorText = "";

            switch (ex)
            {
                case FluentValidation.ValidationException validationEx:
                    code = HttpStatusCode.UnprocessableEntity;
                    var errors = new List<object>();
                    foreach (var exception in validationEx.Errors)
                    {
                        errors.Add(new { property = exception.PropertyName, error = exception.ErrorMessage });
                    }
                    errorResponse = new
                    {
                        Errors = errors,
                        Message = "Validation exception"
                    };
                    break;
                case EntityNotFoundException nfex:
                    errorText = "Entitet sa prosledjenim identifikatorom nije pronadjen u bazi : ";
                    code = HttpStatusCode.NotFound;
                    errorResponse = new
                    {
                        Error = "Entitet sa prosledjenim identifikatorom nije pronadjen u bazi",
                        Message = "Entity not found Exception"
                    };
                    break;
                default:
                    errorText = "Desila se neocekivana greska na serveru, Greska: ";
                    errorResponse = new {
                        Error = "Internal server error",
                        Message = ex.Message
                    };
                    break;
            }
            

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            _textFileAccessor.WriteNewLine(errorText + ex.Message);

            return context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));

        }

        #endregion
    }
}
