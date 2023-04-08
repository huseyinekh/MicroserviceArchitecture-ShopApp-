namespace FreeCourses.Services.Catalog.Dtos.Contact
{
    public class ContactCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string About { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public MapDto Map { get; set; }
    }
}
