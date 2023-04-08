namespace FreeCourses.Services.Catalog.Models
{
    public class BlogDto
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public DateTime CreatedDate { get; set; }

        public string AuthorId { get; set; }
        public Author? Author { get; set; }


    }
}
