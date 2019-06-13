using OrderApp.Common.Abstract;
using OrderApp.Entity.EntityDTO;
using OrderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Services.Abstract
{
    public interface IOrdersFilterRepository
    {
        Task<IDataResult<IEnumerable<Orders>>> GetOrders(FilterOrdersModel model);
    }
}
