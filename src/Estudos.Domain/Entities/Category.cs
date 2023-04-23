using Estudos.Domain.Entities.Base;

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
