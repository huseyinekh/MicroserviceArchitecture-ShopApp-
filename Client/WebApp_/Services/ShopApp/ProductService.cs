using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Product;
using WebApp_.Helpers;
using WebApp_.Models.Catalog;
using WebApp_.Services.Intefaces;
using WebApp_.Services.Intefaces.ShopApp;

namespace WebApp_.Services.ShopApp
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        private readonly IPhotoStockService _photoStockService;
        private readonly PhotoHelper _photoHelper;


        public ProductService(HttpClient client, IPhotoStockService photoStockService, PhotoHelper photoHelper)
        {
            _client = client;
            _photoStockService = photoStockService;
            _photoHelper = photoHelper;
        }

        public async Task<bool> CreateAsync(ProductCreateDto courseCreateInput)
        {
            //var resultPhotoService = await _photoStockService.UploadPhoto(courseCreateInput.PhotoFormFile);

            //if (resultPhotoService != null)
            //{
            //    courseCreateInput.Picture = resultPhotoService.Url;
            //}
            var response = await _client.PostAsJsonAsync<ProductCreateDto>("product", courseCreateInput);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            var courseRes = await GetByIdAsync(Id);
            if (courseRes != null)
            {
                if (courseRes.Picture != null)
                {
                    await _photoStockService.DeletePhoto(courseRes.Picture);

                }

            }
            var response = await _client.DeleteAsync($"product/{Id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<CategoryViewModel>> GetAllCategoryAsync()
        {
            var response = await _client.GetAsync("category");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<CategoryViewModel>>>();

            return responseSuccess.Data;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            //http:localhost:5000/services/catalog/courses
            var response = await _client.GetAsync("product");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ProductDto>>>();
            //responseSuccess.Data.ForEach(x =>
            //{
            //    x.StockPictureUrl = _photoHelper.GetPhotoStockUrl(x.Picture);
            //});
            return responseSuccess.Data;
        }


        public async Task<ProductDto> GetByIdAsync(string courseId)
        {
            var response = await _client.GetAsync($"product/{courseId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<ProductDto>>();

            //  responseSuccess.Data.StockPictureUrl = _photoHelper.GetPhotoStockUrl(responseSuccess.Data.Picture);

            return responseSuccess.Data;
        }

        public async Task<bool> UpdateAsync(ProductDto courseUpdateInput)
        {
            //var resultPhotoService = await _photoStockService.UploadPhoto(courseUpdateInput.PhotoFormFile);

            //if (resultPhotoService != null)
            //{
            //    await _photoStockService.DeletePhoto(courseUpdateInput.Picture);
            //    courseUpdateInput.Picture = resultPhotoService.Url;
            //}

            var response = await _client.PutAsJsonAsync<ProductDto>("product", courseUpdateInput);

            return response.IsSuccessStatusCode;
        }

        public Task<List<ProductDto>> GetByPage(int pageNum)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetByColor(string colorId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetByCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetBySize(string size)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> Search(string searchWord)
        {
            throw new NotImplementedException();
        }
    }
}
