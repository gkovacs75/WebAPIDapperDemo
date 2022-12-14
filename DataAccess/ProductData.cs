using Breakglass.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductData : IProductData
    {
        private readonly ISqlDataAccess _db;

        public ProductData(ISqlDataAccess db)
        {
            this._db = db;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() => await _db.LoadDataAsync<Product, dynamic>("dbo.WebAPI_Products_GetAll", new { });

        public async Task<Product?> GetByIdAsync(int id)
        {
            var results = await _db.LoadDataAsync<Product, dynamic>("dbo.WebAPI_Products_GetById", new { Id = id });

            return results.FirstOrDefault();
        }

        public Task InsertAsync(Product product) => _db.SaveDataAsync("dbo.WebAPI_Products_Insert", new { product.ProductName, product.Price, product.Quantity, product.IsActive });

        public Task UpdateAsync(Product product) => _db.SaveDataAsync("dbo.WebAPI_Products_Update", product);

        public Task DeleteAsync(int id) => _db.SaveDataAsync("dbo.WebAPI_Products_Delete", new { Id = id });
    }
}
