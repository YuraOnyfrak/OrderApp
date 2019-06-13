using OrderApp.Entity.EntityDTO;
using OrderApp.Services.Abstract;
using OrderApp.Services.Abstract.Common;
using OrderApp.Services.Implementation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Services.Implementation.Common
{
    public class BillingAddressesRepository : GenericRepository<BillingAddresses>, IBillingAddressesRepository
    {
        public BillingAddressesRepository(OrdersDBContext context) : base(context)
        {
        }
    }
}
