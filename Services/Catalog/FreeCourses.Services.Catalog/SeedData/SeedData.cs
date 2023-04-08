using FreeCourses.Services.Catalog.Dto.Author;
using FreeCourses.Services.Catalog.Dtos.Blog;
using FreeCourses.Services.Catalog.Dtos.Category;
using FreeCourses.Services.Catalog.Dtos.Color;
using FreeCourses.Services.Catalog.Dtos.Contact;
using FreeCourses.Services.Catalog.Dtos.For;
using FreeCourses.Services.Catalog.Dtos.Popularity;
using FreeCourses.Services.Catalog.Dtos.Product;
using FreeCourses.Services.Catalog.Dtos.Size;
using FreeCourses.Services.Catalog.Dtos.Slider;
using FreeCourses.Services.Catalog.Dtos.Subscribe;
using FreeCourses.Services.Catalog.Services.interfaces;

namespace FreeCourses.Services.Catalog.SeedData
{
    public class SeedData
    {
        public static async Task SeedAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var categoryService = serviceProvider.GetRequiredService<ICategoryService>();
                var colorService = serviceProvider.GetRequiredService<IColorService>();
                var blogService = serviceProvider.GetRequiredService<IBlogService>();
                var forService = serviceProvider.GetRequiredService<IForService>();

                var contactService = serviceProvider.GetRequiredService<IContactService>();
                var sizeService = serviceProvider.GetRequiredService<ISizeService>();

                var popularityService = serviceProvider.GetRequiredService<IPopularityService>();
                var sliderService = serviceProvider.GetRequiredService<ISliderService>();
                var productService = serviceProvider.GetRequiredService<IProductService>();
                var SubscribeService = serviceProvider.GetRequiredService<ISubscribeService>();



                if (!colorService.GetAllAsync().Result.Data.Any())
                {
                    colorService.CreateAsync(new ColorDto { Name = "Red" }).Wait();
                    colorService.CreateAsync(new ColorDto { Name = "Green" }).Wait();
                    colorService.CreateAsync(new ColorDto { Name = "Blue" }).Wait();
                    colorService.CreateAsync(new ColorDto { Name = "Pink" }).Wait();
                    colorService.CreateAsync(new ColorDto { Name = "white" }).Wait();
                    colorService.CreateAsync(new ColorDto { Name = "Black" }).Wait();
                    colorService.CreateAsync(new ColorDto { Name = "Gray" }).Wait();
                    colorService.CreateAsync(new ColorDto { Name = "Aquamarine" }).Wait();

                }

                if (!categoryService.GetAllAsync().Result.Data.Any())
                {
                    categoryService.CreateAsync(new CategoryDto { Name = "Sport" }).Wait();
                    categoryService.CreateAsync(new CategoryDto { Name = "Fashion" }).Wait();
                    categoryService.CreateAsync(new CategoryDto { Name = "Last" }).Wait();
                    categoryService.CreateAsync(new CategoryDto { Name = "Most wanted" }).Wait();
                    categoryService.CreateAsync(new CategoryDto { Name = "Lazy human" }).Wait();


                }
                if (!sizeService.GetAllAsync().Result.Data.Any())
                {
                    sizeService.CreateAsync(new SizeDto { SizeName = "L" }).Wait();
                    sizeService.CreateAsync(new SizeDto { SizeName = "Green" }).Wait();
                    sizeService.CreateAsync(new SizeDto { SizeName = "XL" }).Wait();
                    sizeService.CreateAsync(new SizeDto { SizeName = "XXL" }).Wait();
                    sizeService.CreateAsync(new SizeDto { SizeName = "D" }).Wait();

                }


                if (!SubscribeService.GetAllAsync().Result.Data.Any())
                {
                    SubscribeService.CreateAsync(new SubscribeDto { Email = "huseyinekh@code.edu.az" }).Wait();
                    SubscribeService.CreateAsync(new SubscribeDto { Email = "huseyn7355608@gmail.com" }).Wait();
                    SubscribeService.CreateAsync(new SubscribeDto { Email = "isim@soyisim.com" }).Wait();
                }

                if (!popularityService.GetAllAsync().Result.Data.Any())
                {
                    popularityService.CreateAsync(new PopularityDto { Name = "Brend" }).Wait();
                    popularityService.CreateAsync(new PopularityDto { Name = "Trent" }).Wait();
                    popularityService.CreateAsync(new PopularityDto { Name = "Popular" }).Wait();
                    popularityService.CreateAsync(new PopularityDto { Name = "Prestiging" }).Wait();
                    popularityService.CreateAsync(new PopularityDto { Name = "Cheap" }).Wait();


                }
                if (!sliderService.GetAllAsync().Result.Data.Any())
                {
                    sliderService.CreateAsync(new SliderDto
                    {
                        Name = " The new Brend",
                        Description = "Hurry my friend its he best koynek",
                        Picture = "slide.jpg",
                    }).Wait();
                    sliderService.CreateAsync(new SliderDto
                    {
                        Name = " The old  Brend",
                        Description = "Hurry  its old but gold ",
                        Picture = "slide1.jpg",
                    }).Wait();
                    sliderService.CreateAsync(new SliderDto
                    {
                        Name = " The vintage  Brend",
                        Description = "vintage is winter clothes ",
                        Picture = "slide3.jpg",
                    }).Wait();


                }



                if (!forService.GetAllAsync().Result.Data.Any())
                {
                    forService.CreateAsync(new ForDto { Name = "Women" }).Wait();
                    forService.CreateAsync(new ForDto { Name = "Men" }).Wait();
                    forService.CreateAsync(new ForDto { Name = "Kids" }).Wait();
                    forService.CreateAsync(new ForDto { Name = "Sport" }).Wait();
                    forService.CreateAsync(new ForDto { Name = "Unisex" }).Wait();
                    forService.CreateAsync(new ForDto { Name = "Poors" }).Wait();


                }


                if (!blogService.GetAllAuthorAsync().Result.Data.Any())
                {
                    blogService.CreateAuthorAsync(new AuthorCreateDto { FirstName = "Huseyn", LastName = "Khidirov" }).Wait();
                    blogService.CreateAuthorAsync(new AuthorCreateDto { FirstName = "Jonh", LastName = "Doe" }).Wait();
                    blogService.CreateAuthorAsync(new AuthorCreateDto { FirstName = "Murat", LastName = "Vuranok" }).Wait();
                    blogService.CreateAuthorAsync(new AuthorCreateDto { FirstName = "Anar", LastName = "Balaca" }).Wait();
                    blogService.CreateAuthorAsync(new AuthorCreateDto { FirstName = "Famil", LastName = "Hamidov" }).Wait();

                }

                if (!blogService.GetAllAsync().Result.Data.Any())
                {
                    var author = blogService.GetAllAuthorAsync().Result.Data.FirstOrDefault();

                    blogService.CreateAsync(new BlogCreateDto
                    {
                        Name = "New Fashion"
                                                                 ,
                        CreatedDate = DateTime.Now,
                        Description = "lorem ipsun dolor sit amet defa core edora comba domba",
                        Picture = "blog1.jpg",
                        AuthorId = author.Id


                    }).Wait();

                    blogService.CreateAsync(new BlogCreateDto
                    {
                        Name = " Why Womens love fashion?"
                                                               ,
                        CreatedDate = DateTime.Now,
                        Description = "lThe standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        Picture = "blog2.jpg",
                        AuthorId = author.Id


                    }).Wait();
                    blogService.CreateAsync(new BlogCreateDto
                    {
                        Name = " What is Hmm?"
                                                              ,
                        CreatedDate = DateTime.Now,
                        Description = "lThe standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        Picture = "blog3.jpg",
                        AuthorId = author.Id
                    }).Wait();
                }

                if (!contactService.GetAllAsync().Result.Data.Any())
                {
                    contactService.CreateAsync(new ContactCreateDto
                    {
                        Title = "Final project title",
                        About = "rm, accompanied by English versions " +
                        "from the 1914 translation by H. Rackham.",
                        Email = "huseyinekh@gmail.com",
                        Phone = "+994 055 379 54 33",
                        CompanyName = "RNET101",
                        Description = "Malorum\" (The Extremes of Good and Evil) by " +
                            "Cicero, written in 45 BC. This book is a treatise on the " +
                            "theory of ethics, very popular during the Renaissance",
                        Map = new MapDto { Latitude = "40.378422", Longitude = "49.842201" },
                        Address = "Baku 28 May"

                    }).Wait();

                }
                if (!contactService.GetAllMessagesAsync().Result.Data.Any())
                {
                    contactService.SendMessage(

                        new Dtos.Message.MessageDto
                        {
                            Email = "huseyinekh@gmail.com",
                            MessageText = "This is text message",
                            Name = "Huseyn",
                            Subjects = "Greeting Test"

                        }).Wait();

                }


                if (!productService.GetAllAsync().Result.Data.Any())
                {
                    var color = colorService.GetAllAsync().Result.Data.ToList();
                    var size = sizeService.GetAllAsync().Result.Data.ToList();
                    var cat = categoryService.GetAllAsync().Result.Data.ToList();
                    var for_ = forService.GetAllAsync().Result.Data.ToList();
                    var popularity = popularityService.GetAllAsync().Result.Data.ToList();




                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                        ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat.FirstOrDefault().Id
                         ,
                        PopularityId = popularity.FirstOrDefault().Id,
                        Picture = "product.jpg",
                        ForId = for_.FirstOrDefault().Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat.FirstOrDefault().Id
                        ,
                        PopularityId = popularity.FirstOrDefault().Id,
                        Picture = "product2.jpg",
                        ForId = for_.FirstOrDefault().Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "Wears",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat.FirstOrDefault().Id
                        ,
                        PopularityId = popularity[0].Id,
                        Picture = "product4.jpg",
                        ForId = for_[1].Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat[2].Id
                        ,
                        PopularityId = popularity.FirstOrDefault().Id,
                        Picture = "product3.jpg",
                        ForId = for_[2].Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "Half skirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat[2].Id
                        ,
                        PopularityId = popularity[2].Id,
                        Picture = "product.jpg",
                        ForId = for_.FirstOrDefault().Id,


                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "Cordova back hatt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat[2].Id
                        ,
                        PopularityId = popularity.FirstOrDefault().Id,
                        Picture = "product.jpg",
                        ForId = for_[2].Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "CUriuculum",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat[3].Id
                        ,
                        PopularityId = popularity[2].Id,
                        Picture = "product.jpg",
                        ForId = for_.FirstOrDefault().Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat[2].Id
                        ,
                        PopularityId = popularity.FirstOrDefault().Id,
                        Picture = "product.jpg",
                        ForId = for_.FirstOrDefault().Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat[1].Id
                        ,
                        PopularityId = popularity[1].Id,
                        Picture = "product.jpg",
                        ForId = for_[0].Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat[0].Id
                        ,
                        PopularityId = popularity[0].Id,
                        Picture = "product.jpg",
                        ForId = for_[0].Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat.FirstOrDefault().Id
                        ,
                        PopularityId = popularity[0].Id,
                        Picture = "product.jpg",
                        ForId = for_[0].Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat[1].Id
                        ,
                        PopularityId = popularity[0].Id,
                        Picture = "product5.jpg",
                        ForId = for_[0].Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat.FirstOrDefault().Id
                        ,
                        PopularityId = popularity[0].Id,
                        Picture = "product6.jpg",
                        ForId = for_.FirstOrDefault().Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat[0].Id
                        ,
                        PopularityId = popularity[0].Id,
                        Picture = "product.jpg",
                        ForId = for_.FirstOrDefault().Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "Boze lose",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat[2].Id
                        ,
                        PopularityId = popularity[1].Id,
                        Picture = "product.jpg",
                        ForId = for_.FirstOrDefault().Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat[0].Id
                        ,
                        PopularityId = popularity.FirstOrDefault().Id,
                        Picture = "product.jpg",
                        ForId = for_.FirstOrDefault().Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat[0].Id
                        ,
                        PopularityId = popularity.FirstOrDefault().Id,
                        Picture = "product7.jpg",
                        ForId = for_.FirstOrDefault().Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat.FirstOrDefault().Id
                        ,
                        PopularityId = popularity.FirstOrDefault().Id,
                        Picture = "product8.jpg",
                        ForId = for_.FirstOrDefault().Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat.FirstOrDefault().Id
                        ,
                        PopularityId = popularity.FirstOrDefault().Id,
                        Picture = "product9.jpg",
                        ForId = for_[1].Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat.FirstOrDefault().Id
                        ,
                        PopularityId = popularity[0].Id,
                        Picture = "product.jpg",
                        ForId = for_[0].Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat.FirstOrDefault().Id
                        ,
                        PopularityId = popularity.FirstOrDefault().Id,
                        Picture = "product3.jpg",
                        ForId = for_[0].Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "Consibe bella de cella",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat[0].Id
                        ,
                        PopularityId = popularity.FirstOrDefault().Id,
                        Picture = "product2.jpg",
                        ForId = for_.FirstOrDefault().Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat.FirstOrDefault().Id
                        ,
                        PopularityId = popularity.FirstOrDefault().Id,
                        Picture = "product3.jpg",
                        ForId = for_[2].Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat[2].Id
                        ,
                        PopularityId = popularity[3].Id,
                        Picture = "product.jpg",
                        ForId = for_[0].Id,

                    }).Wait();
                    productService.CreateAsync(new ProductCreateDto
                    {
                        Name = "T-shirt",
                        CreatedDate = DateTime.Now,
                        Description = "its a best t-shirt for modern human"
                       ,
                        Price = 4.00M,
                        UnitsOfStock = 10,
                        ColorIds = new string[] { color[0].Id, color[1].Id, color[3].Id },
                        SizeIds = new string[] { size[0].Id, size[1].Id, size[2].Id },
                        CategoryId = cat.FirstOrDefault().Id
                        ,
                        PopularityId = popularity.FirstOrDefault().Id,
                        Picture = "product.jpg",
                        ForId = for_.FirstOrDefault().Id,

                    }).Wait();

                }


            }


        }
    }
}
