using Domain.Common;

namespace Domain.Entities
{
    public class Detail : BaseEntity
    {
        public Detail()
        {

        }

        public Detail(string title, string description, int categoryId)
        {
            Title = title;
            Description = description;
            CategoryId = categoryId;
        }

        public  string Title { get; set; }
        public  string Description { get; set; }
        public  int CategoryId { get; set; }

    }
}
