namespace DailyShopApp.Models
{
    public class Contact
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string About { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Map Map { get; set; }
    }

    public class Map
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }

    }
}
