using SafetyCommerce.Application.Interfaces.IRepositorys;
using SafetyCommerce.Application.Interfaces.IServices;
using SafetyCommerce.Application.Interfaces.IUnitOfWorks;
using SafetyCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Infrastructure.Services
{
    public class ReceiverAppService : GenericService<ReceiverApp>, IReceiverAppService
    {
        public ReceiverAppService(IGenericRepository<ReceiverApp> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
