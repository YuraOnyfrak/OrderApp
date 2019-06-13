﻿using OrderApp.Entity.EntityDTO;
using OrderApp.Services.Abstract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Services.Abstract.Common
{
    public interface IBillingAddressesRepository : IGenericRepository<BillingAddresses>
    {
    }
}
