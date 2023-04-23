using Estudos.Domain.Entities.Base;

namespace Estudos.Domain.Entities
{
    public class Description : BaseEntity
    {
        // Refatorado de Category para Description (não fazia sentido categoria com relação one-to-one)
        public string Details { get; set; }
        public ProductToDb Product { get; set; }

        public Description(string details)
        {
            Details = details;
        }
    }
}
