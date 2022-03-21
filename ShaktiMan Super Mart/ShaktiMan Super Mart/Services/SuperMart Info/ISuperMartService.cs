using ShaktiMan_Super_Mart.Models;

namespace ShaktiMan_Super_Mart.Services.SuperMart_Info
{
    public interface ISuperMartService
    {
        private const string ConnectionString = @"Data Source=SAIF-PC;Initial Catalog=MyDatabase;User ID=myuser;Password=root";

        public Task<List<Product>> GetAllProductsAsync();

        public Task InsertAsync(Product product);

        public Task UpdateAsync(Product product);

        public Task DeleteAsync(int id);

        public Task<Product> Find(int id);

        public Task<ProductSearch> FindByName(string name);
    }
}
