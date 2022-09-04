using Breakglass.Core.Entities;

namespace DataAccess
{
    public interface IProductData
    {
        Task Delete(int id);
        Task<IEnumerable<Product>> GetAll();
        Task<Product?> GetById(int id);
        Task Insert(Product product);
        Task Update(Product product);
    }
}