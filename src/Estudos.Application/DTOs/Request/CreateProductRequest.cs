using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Application.DTOs.Request
{
    public record CreateProductRequest(int Code, string Name, int Qtd, string DescriptionDetails, List<string> TagNames);
}
