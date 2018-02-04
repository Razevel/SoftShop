using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PathPart { get; set; }
        

        public virtual List<Product> Products { get; set; }
    }
}