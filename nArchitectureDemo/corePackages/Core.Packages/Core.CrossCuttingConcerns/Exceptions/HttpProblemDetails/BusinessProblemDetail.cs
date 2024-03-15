﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class BusinessProblemDetail:ProblemDetails
    {
        public BusinessProblemDetail(string detail)
        {
                Title = "Rule Violation";
                Detail = detail;
                Status = StatusCodes.Status400BadRequest;
                Type = "http://example.com/probs/business";
                
        }
    }


}
