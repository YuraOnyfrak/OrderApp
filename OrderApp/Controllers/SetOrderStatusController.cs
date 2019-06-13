using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Common.Abstract;
using OrderApp.Entity;
using OrderApp.Model;
using OrderApp.Services.Abstract;

namespace OrderApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SetOrderStatusController : ControllerBase
    {
        private readonly ISetOrderStatusService _setOrderStatusService;

        public SetOrderStatusController
            (
                ISetOrderStatusService setOrderStatusService
            )
        {
            _setOrderStatusService = setOrderStatusService;
        }

        [HttpPost]		
		public async Task<IActionResult> SetStatus([FromBody] StatusModel model) 
		{ 

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

            IResult result = 
                await _setOrderStatusService.SetOrderStatus(model);

            return new JsonResult(result);

        }
	}
}