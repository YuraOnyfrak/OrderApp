using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Common.Abstract;
using OrderApp.Common.Implementation;
using OrderApp.Entity.EntityDTO;
using OrderApp.Model;
using OrderApp.Services.Abstract;
using OrderApp.Services.Abstract.Common;

namespace OrderApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersFilterRepository _orderFilterService;
        private readonly IOrderRepository _orderRepository;

        public OrdersController
            (
                IOrdersFilterRepository orderFilterService,
                IOrderRepository orderRepository
            )
        {
            _orderFilterService = orderFilterService;
            _orderRepository = orderRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _orderRepository.GetAllAsync();

            IDataResult<IEnumerable<Orders>> dataResult =
               new DataResult<IEnumerable<Orders>>();

            dataResult.Data = data;
            dataResult.Success = true;

            return new JsonResult(dataResult);
        }

        [HttpPost]		
		public async  Task<IActionResult> Orders([FromBody] FilterOrdersModel model)
		{			
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

            var result =  await _orderFilterService.GetOrders(model);

            return new JsonResult(result);
        }
	}
}