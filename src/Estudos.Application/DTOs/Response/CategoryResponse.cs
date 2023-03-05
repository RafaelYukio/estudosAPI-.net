using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Application.DTOs.Response
{
    public record CategoryResponse (Guid Id, string Name)
    {
    }
}
