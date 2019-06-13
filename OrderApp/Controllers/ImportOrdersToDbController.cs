using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Common.Abstract;
using OrderApp.Services.Abstract;

namespace OrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportOrdersToDbController : ControllerBase
    {
		private readonly IImportOrdersService _importOrdersService;

		public ImportOrdersToDbController
			(
			IImportOrdersService importOrdersService
			)
		{
			_importOrdersService = importOrdersService;
		}


		public async Task<IActionResult> Index()
		{
			IResult result =  await _importOrdersService.ImportOrder();

			return new JsonResult(result);
        }
	}
}
    