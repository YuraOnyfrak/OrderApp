using OrderApp.Common;
using OrderApp.Common.Abstract;
using OrderApp.Common.Implementation;
using OrderApp.Entity;
using OrderApp.Model;
using OrderApp.Services.Abstract;
using OrderApp.Services.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Services.Implementation
{
    public class SetOrderStatusService : ISetOrderStatusService
    {

        private readonly IOrderRepository _orderRepository;

        public SetOrderStatusService
           (
            IOrderRepository orderRepository
            )
        {
            _orderRepository = orderRepository;
        }

        public async Task<IResult> SetOrderStatus(StatusModel model)
        {
            Status statusValue;
            IResult result = new Result();

            var order = _orderRepository.First(s => s.OxId == model.Id);

            if (order != null)
            {
                if (Enum.TryParse<Status>(model.Status.ToString(), out statusValue))
                    {
                        order.OrderStatus = model.Status;
                        await _orderRepository.UpdateAsync(order);
                        await _orderRepository.SaveAsync();

                        result.Success = true;
                    }

                result.Success = true; result.Message = MessagesDictionary.GetErrorMessag("SuccessUpdated");
            }
            else
            {
                result.Message = MessagesDictionary.GetErrorMessag("Error");
            }

            return result;
        }
    }
}
