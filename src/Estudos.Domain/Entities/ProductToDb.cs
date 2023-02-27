using Estudos.Domain.Entities.Base;
using Estudos.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Domain.Entities
{
    // Para exemplo de relacionamento com ProductToDb
    public class ProductToDb : BaseEntity
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Qtd { get; set; }

        public Description Description { get; set; }
        public List<Tag> Tags { get; set; }
    }

}
