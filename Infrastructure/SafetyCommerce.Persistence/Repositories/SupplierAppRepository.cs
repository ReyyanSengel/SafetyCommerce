using Microsoft.EntityFrameworkCore;
using SafetyCommerce.Application.Interfaces.IRepositorys;
using SafetyCommerce.Domain.Entities;
using SafetyCommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Persistence.Repositories
{
    public class SupplierAppRepository : GenericRepsitory<SupplierApp>, ISupplierAppRepository
    {
        public SupplierAppRepository(SafetyCommerceDbContext context) : base(context)
        {
        }
    }
}
