﻿using OrderApp.Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Common.Implementation
{
    public class Result : IResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
