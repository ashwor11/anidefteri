﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions.HttpExceptions
{
    internal class InternalServerErrorProblemDetails: ProblemDetails
    {
        public InternalServerErrorProblemDetails(string detail)
        {
            Title = "Internal server error";
            Detail = detail;
            Status = StatusCodes.Status500InternalServerError;
            Type = "https://example.com/probs/internal";
            Instance = "";
        }
    }
}
