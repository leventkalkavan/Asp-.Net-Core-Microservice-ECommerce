using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly IMongoCollection<Product> _mongoCollection;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _mongoCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        var values = await _mongoCollection.Find<Product>(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDto>>(values);
    }

    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        var value = _mapper.Map<Product>(createProductDto);
        await _mongoCollection.InsertOneAsync(value);
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var value = _mapper.Map<Product>(updateProductDto);
        await _mongoCollection.FindOneAndReplaceAsync(x => x.Id == updateProductDto.Id, value);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _mongoCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
    {
        var value = await _mongoCollection.Find<Product>(x => x.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDto>(value);
    }
}