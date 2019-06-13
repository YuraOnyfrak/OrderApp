using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Common.Abstract
{
    public interface IResult
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
}
