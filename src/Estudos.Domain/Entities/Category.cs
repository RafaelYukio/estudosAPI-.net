using Estudos.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<ProductToDb> Products { get; set; }
        public Category(string name)
        {
            Name = name;
        }
    }
}
