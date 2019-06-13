using OrderApp.Common.Abstract;
using OrderApp.Common.Implementation;
using OrderApp.Model;
using OrderApp.Services.Abstract;
using OrderApp.Services.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Services.Implementation
{
    public class SetInvoiceNumberService : ISetInvoiceNumberService
    {
        private readonly IOrderRepository _orderRepository;

        public SetInvoiceNumberService
           (
            IOrderRepository orderRepository
            )
        {
            _orderRepository = orderRepository;
        }

        public async Task<IResult> SetInvoiceNumber(InvoiceNumberModel model)
        {
            IResult result = new Result();

            var order = _orderRepository.First(s => s.OxId == model.Id);

            if (order != null)
            {
                order.InvoiceNumber = model.InvoiceNumber;
                await _orderRepository.UpdateAsync(order);
                await _orderRepository.SaveAsync();

                result.Success = true;
            }

                      
            return result;

        }
    }
}
