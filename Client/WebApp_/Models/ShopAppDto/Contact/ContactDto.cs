namespace FreeCourses.Services.Catalog.Dtos.Contact
{
    public class ContactDto
    {

        public string? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string About { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public MapDto Map { get; set; }
    }

    public class MapDto
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }

    }
}
