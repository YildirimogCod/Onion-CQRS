using Bogus;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class DetailConfiguration:IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker = new Faker("tr");
            Detail detail1 = new Detail
            {
                Id = 1,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 1,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false,
            };
            Detail detail2 = new Detail
            {
                Id = 2,
                Title = faker.Lorem.Sentence(2),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 3,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = true,
            };
            Detail detail3 = new Detail
            {
                Id = 3,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 4,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false,
            };
            builder.HasData(detail1, detail2, detail3);

        }
    }
}
