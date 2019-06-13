using OrderApp.Services.Abstract;
using OrderApp.Services.Abstract.Common;
using OrderApp.Services.Implementation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Services.Implementation.Common
{
    public class PaymentsRepository : GenericRepository<Payments>, IPaymentsRepository
    {
        public PaymentsRepository(OrdersDBContext context) : base(context)
        {
        }
    }
}
