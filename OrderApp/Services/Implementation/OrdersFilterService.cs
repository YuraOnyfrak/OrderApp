using OrderApp.Common.Abstract;
using OrderApp.Common.Implementation;
using OrderApp.Entity;
using OrderApp.Entity.EntityDTO;
using OrderApp.Model;
using OrderApp.Services.Abstract;
using OrderApp.Services.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Services.Implementation
{
    public class OrdersFilterService : IOrdersFilterRepository
    {
        private readonly IOrderRepository _orderService;

        public OrdersFilterService
            (
                IOrderRepository orderService
            )
        {
            _orderService = orderService;
        }

        public  async Task<IDataResult<IEnumerable<Orders>>> GetOrders(FilterOrdersModel model)
        {
            IDataResult<IEnumerable<Orders>> dataResult =
                new DataResult<IEnumerable<Orders>>();

            Status statusValue;
            List<Orders> orders = new List<Orders>();
            
            if (model.OxId != null && model.OxId > 0)
            {
                Orders order = _orderService.First(s => s.OxId == model.OxId);
                orders.Add(order);

                dataResult.Success = true;               
                dataResult.Data = orders;

                return dataResult;
            }
            else if (model.InvoiceNumber != null && model.InvoiceNumber > 0)
            {
               var order = _orderService.First(s => s.InvoiceNumber == model.InvoiceNumber);
               orders.Add(order);

               dataResult.Success = true;
               dataResult.Data = orders;

               return dataResult;
            }

            orders = await _orderService.FetchAsync();

            if (Enum.TryParse<Status>(model.OrderStatus.ToString(), out statusValue))
            {
                orders = orders.Where(s => s.OrderStatus.HasValue
                                               && s.OrderStatus.Value == (byte)statusValue).ToList();
            }

            if (model.OrderDatetimeStart != null && model.OrderDatetimeEnd != null)
            {
                orders = orders.Where(s => s.OrderDatetime <= model.OrderDatetimeEnd
                                        && s.OrderDatetime >= model.OrderDatetimeStart).ToList();
            }

            dataResult.Data = orders;

            return dataResult;

            
        }
    }
}
