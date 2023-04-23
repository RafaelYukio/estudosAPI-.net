using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces.Repositories;
using Estudos.Domain.Interfaces.Services;
using Estudos.Domain.Services.Base;

namespace Estudos.Domain.Services
{
    public class DescriptionService : BaseService<Description>, IDescriptionService
    {
        public DescriptionService(IDescriptionRepository descriptionRepository) : base(descriptionRepository)
        {
        }
    }
}
