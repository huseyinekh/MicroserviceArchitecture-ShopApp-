using AutoMapper;
using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Product;
using FreeCourses.Services.Catalog.Models;
using FreeCourses.Services.Catalog.Services.interfaces;
using FreeCourses.Services.Catalog.Settings;
using MongoDB.Driver;

namespace FreeCourses.Services.Catalog.Services
{
    public class ProductService : IProductService
    {

        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection =
                database.GetCollection<Product>(databaseSettings.ProductsCollectionName);
        }


        public async Task<Response<List<ProductDto>>> GetAllAsync() =>
              Response<List<ProductDto>>.Success(
                  _mapper.Map<List<ProductDto>>(
                      await _productCollection.Find(x => true).ToListAsync()), 200);

        public async Task<Response<ProductDto>> GetByIdAsync(string id)
        {
            var Product = await _productCollection.
                Find<Product>(x => x.Id == id).FirstOrDefaultAsync();
            if (Product == null)
                return Response<ProductDto>.Fail("Product Not Found", 404);
            return Response<ProductDto>.Success(_mapper.Map<ProductDto>(Product), 200);
        }

        public async Task<Response<ProductCreateDto>> CreateAsync(ProductCreateDto ProductDto)
        {
            var Product = _mapper.Map<Product>(ProductDto);
            await _productCollection.InsertOneAsync(Product);
            return Response<ProductCreateDto>
                .Success(_mapper.Map<ProductCreateDto>(Product), 200);
        }

        public async Task<Response<NoConetent>> DeleteAsync(string id)
        {
            var deleteItem = await _productCollection.DeleteOneAsync(x => x.Id == id);
            if (deleteItem.DeletedCount > 0)
                return Response<NoConetent>.Success(204);
            return Response<NoConetent>.Fail("Not found ProductItem", 404);
        }

        public Task<Response<List<ProductDto>>> GetByPage(int pageNum)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ProductDto>>> GetByColor(string colorId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ProductDto>>> GetByCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ProductDto>>> GetBySize(string size)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ProductDto>>> Search(string searchWord)
        {
            throw new NotImplementedException();
        }



        public async Task<Response<NoConetent>> UpdateAsync(ProductDto course)
        {
            var updateCourse = _mapper.Map<Product>(course);
            var res = await _productCollection.FindOneAndReplaceAsync(x => x.Id == updateCourse.Id, updateCourse);
            var updateProduct = _mapper.Map<Product>(course);
            if (res == null)
                return Response<NoConetent>.Fail("Product Not Found", 404);
            return Response<NoConetent>.Success(200);

            //  var res = await _productCollection.UpdateOneAsync(x => x.Id == updateProduct.Id, updateProduct);
        }
    }
}
