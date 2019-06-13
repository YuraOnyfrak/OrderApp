using OrderApp.Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Common.Implementation
{
    public class DataResult<TEntity> : IDataResult<TEntity>
    {
        public TEntity Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
