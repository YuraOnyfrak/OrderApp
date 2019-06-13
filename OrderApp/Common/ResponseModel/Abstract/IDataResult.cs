using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Common.Abstract
{
    public interface IDataResult<TEntity> : IResult 
    {
        TEntity Data { get; set; }
    }
}
