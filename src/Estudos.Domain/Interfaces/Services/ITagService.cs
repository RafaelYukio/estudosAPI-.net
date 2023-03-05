using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Domain.Interfaces.Services
{
    public interface ITagService : IBaseService<Tag>
    {
        Task<Tag> GetByNameAsync(string tagName);
    }
}
