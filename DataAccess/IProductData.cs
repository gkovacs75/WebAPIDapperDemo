using Breakglass.Core.Entities;

namespace DataAccess
{
    public interface IProductData
    {        
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task InsertAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}