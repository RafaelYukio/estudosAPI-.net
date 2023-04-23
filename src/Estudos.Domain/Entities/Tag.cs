using Estudos.Domain.Entities.Base;

namespace Estudos.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public List<ProductToDb> Products { get; set; }
        public Tag(string name)
        {
            Name = name;
        }
    }
}
