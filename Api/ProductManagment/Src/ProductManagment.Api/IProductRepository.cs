using ProductManagment.Api.DTOs;

namespace ProductManagment.Api
{
    /// <summary>
    /// Interface to handle product database operations
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Get all produts from database
        /// </summary>
        /// <returns></returns>
        Task<List<ProductDto>> GetAll();

        /// <summary>
        /// Add product to database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<bool> Add(ProductDto product);
    }
}
