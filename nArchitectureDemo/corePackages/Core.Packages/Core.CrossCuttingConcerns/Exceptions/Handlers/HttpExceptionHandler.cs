using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions.Handlers
{
    public class HttpExceptionHandler : ExceptionHandler
    {
        private HttpResponse? _response;
        public HttpResponse Response
        {
            get => _response?? throw new ArgumentNullException(nameof(_response));

            set => _response = value;
        }


        protected override Task HandlerException(BusinessException businessException)
        {

            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = new BusinessProblemDetail(businessException.Message).AsJson();
            return Response.WriteAsync(details);
        }
        protected override Task HandlerException(Exception exception)
        {
            Response.StatusCode = StatusCodes.Status500InternalServerError;
            string details = new InternalProblemDetail(exception.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandlerException(ValidationException validationException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = new ValidationProblemDetails(validationException.Errors).AsJson();
            return Response.WriteAsync(details);
        }
    }
}
