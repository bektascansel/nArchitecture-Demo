using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class InternalProblemDetail : ProblemDetails
    {
        public InternalProblemDetail(string detail)
        {
            Title = "Internal Server Error";
            Detail = "Internal Server Error";
            Status = StatusCodes.Status500InternalServerError;
            Type = "http://example.com/probs/internal";

        }
    }


}
