﻿using Estudos.Domain.Entities.Base;

namespace Estudos.Domain.Entities
{
    // Para exemplo de relacionamento com ProductToDb
    public class ProductToDb : BaseEntity
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Qtd { get; set; }

        public Description Description { get; set; }
        public Category Category { get; set; }
        public List<Tag> Tags { get; set; }

        // Não posso colocar no construtor props. de navegação:
        // public ProductToDb(int code, string name, int qtd, Description description, List<Tag> tags)
        public ProductToDb(int code, string name, int qtd)
        {
            Code = code;
            Name = name;
            Qtd = qtd;
        }
    }

}
