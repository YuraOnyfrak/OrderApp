using OrderApp.Common.Abstract;
using OrderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Services.Abstract
{
    public interface ISetOrderStatusService
    {
        Task<IResult> SetOrderStatus(StatusModel model);
    }
}
