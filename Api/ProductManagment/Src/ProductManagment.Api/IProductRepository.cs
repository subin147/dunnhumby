using ProductManagment.Api.DTOs;

namespace ProductManagment.Api
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetAll();
        Task<bool> Add(ProductDto product);
    }
}
