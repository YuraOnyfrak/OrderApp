using OrderApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderApp.Entity.XmlEntity;
using OrderApp.Common.Abstract;

namespace OrderApp.Services.Abstract
{
	public interface IImportOrdersService
	{
         Task<IResult> ImportOrder();
    }
}
