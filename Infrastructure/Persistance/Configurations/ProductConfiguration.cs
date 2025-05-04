using Bogus;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Configurations
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            Faker faker = new Faker("tr");
            Product product1 = new()
            {
                Id = 1,
                Title = faker.Commerce.ProductName(),
                Description = faker.Lorem.Paragraph(2),
                BrandId = 1,    
                Discount = faker.Random.Decimal(0, 10),
                Price = faker.Finance.Amount(10, 1000),
                CreatedAt = DateTime.Now,
                IsDeleted = false
            };
            Product product2 = new()
            {
                Id = 2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Lorem.Paragraph(2),
                BrandId = 3,
                Discount = faker.Random.Decimal(0, 10),
                Price = faker.Finance.Amount(10, 1000),
                CreatedAt = DateTime.Now,
                IsDeleted = false
            };
            builder.HasData(product1, product2);
        }
    }
}
