namespace DailyShopApp.Models
{
    public class Blog
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public DateTime CreatedDate { get; set; }

        public int AuthorId { get; set; }
        public Author? Author { get; set; }


    }
}
