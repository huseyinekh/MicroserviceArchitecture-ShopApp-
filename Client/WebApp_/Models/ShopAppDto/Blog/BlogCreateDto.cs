using FreeCourses.Services.Catalog.Dto.Author;

namespace FreeCourses.Services.Catalog.Dtos.Blog
{
    public class BlogCreateDto
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string AuthorId { get; set; }
        public AuthorDto? Author { get; set; }


    }
}
