using Domain.Common;

namespace Domain.Entities
{
    public class Product:BaseEntity
    {
        public Product()
        {
            
        }
        public Product(string title, string description, int brandId, decimal price, decimal discount)
        {
            Title = title;
            Description = description;
            BrandId = brandId;
            Price = price;
            Discount = discount;
        }
        public  string Title { get; set; }
       public  string Description { get; set; }

       public  int BrandId { get; set; }
       public  decimal Price { get; set; }

        public  decimal Discount { get; set; }

        public Brand Brand { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
