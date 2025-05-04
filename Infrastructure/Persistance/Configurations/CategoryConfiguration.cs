using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category category1 = new()
            {   
                Id = 1,
                Name = "Elektrik",
                Priorty = 1,
                ParentId = 0,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow
            };
            Category category2 = new()
            {
                Id = 2,
                Name = "Moda",
                Priorty = 2,
                ParentId = 0,   
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow
            };
            Category parent1 = new()
            {
                Id = 3,
                Name = "Bilgisayar",
                Priorty = 1,
                ParentId = 1,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow
            };
            Category parent2 = new()
            {
                Id = 4,
                Name = "Kadın",
                Priorty = 1,
                ParentId = 2,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow
            };
            builder.HasData(category1, category2, parent1, parent2);
        }
    }
}
