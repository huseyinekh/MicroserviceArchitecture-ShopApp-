namespace FreeCourses.Services.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CourseCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string SizeCollectionName { get; set; }
        public string ColorCollectionName { get; set; }
        public string ForCollectionName { get; set; }
        public string BlogCollectionName { get; set; }
        public string AuthorCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string MessageCollectionName { get; set; }
        public string SliderCollectionName { get; set; }
        public string SubscribeCollectionName { get; set; }
        public string PopularityCollectionName { get; set; }
        public string SizesCollectionName { get; set; }
        public string ProductsCollectionName { get; set; }

    }
}
