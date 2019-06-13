using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Common.Abstract;
using OrderApp.Model;
using OrderApp.Services.Abstract;

namespace OrderApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SetInvoiceNumberController : ControllerBase
    {

        private readonly ISetInvoiceNumberService _setInvoiceNumberService;

        public SetInvoiceNumberController
            (
                ISetInvoiceNumberService setInvoiceNumberService
            )
        {
            _setInvoiceNumberService = setInvoiceNumberService;
        }

        [HttpPost]		
		public async Task<ActionResult<IResult>> InvoiceNumber([FromBody] InvoiceNumberModel model)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

           IResult result = 
                await _setInvoiceNumberService.SetInvoiceNumber(model);

            return new JsonResult(result);
		}
	}
}