using OrderApp.Services.Abstract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Services.Abstract.Common
{
    public interface IPaymentsRepository : IGenericRepository<Payments>
    {
    }
}
