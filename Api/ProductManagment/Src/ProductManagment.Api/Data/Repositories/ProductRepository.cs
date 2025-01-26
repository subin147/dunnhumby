using Microsoft.EntityFrameworkCore;
using ProductManagment.Api.Data.Context;
using ProductManagment.Api.Data.Entities;
using ProductManagment.Api.DTOs;

namespace ProductManagment.Api.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productDbContext;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(ProductDbContext productDbContext,ILogger<ProductRepository> logger) {
            _productDbContext = productDbContext;
            _logger = logger;
        }
        async Task<bool> IProductRepository.Add(ProductDto product)
        {
            try
            {
                var productDb = new Product
                {
                    CategoryId = product.CategoryId,
                    Code = product.Code,
                    DateAdded = DateTime.Now,
                    Name = product.Name,
                    Price = product.Price,
                    SKU = product.SKU,
                    StockQuantity = product.StockQuantity

                };
                _productDbContext.Products.Add(productDb);
                var result = await _productDbContext.SaveChangesAsync();
                return result == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occured while adding product to database.");
                return false;
            }
        }

        async Task<List<ProductDto>> IProductRepository.GetAll()
        {
            try
            {
                return await _productDbContext.Products.AsNoTracking().Select(product => new ProductDto
                {
                    Id = product.Id,
                    Category = product.Category.Description,
                    Code = product.Code,
                    Name = product.Name,
                    Price = product.Price,
                    SKU = product.SKU,
                    DateAdded = product.DateAdded,
                    StockQuantity = product.StockQuantity
                }).OrderBy(a=>a.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occured while fetching products from database.");
                return null;
            }
        }

    }
}
