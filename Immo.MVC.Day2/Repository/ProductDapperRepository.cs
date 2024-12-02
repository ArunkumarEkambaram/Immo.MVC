using Dapper;
using Immo.MVC.Day2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Immo.MVC.Day2.Repository
{
    public class ProductDapperRepository : IRepositoryWithCategory<Product>
    {
        private readonly DapperDbContext _dbContext;

        public ProductDapperRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> Add(Product entity)
        {
            using var connection = _dbContext.GetConnection;
            await connection.ExecuteAsync("Insert Products(ProductName, Price, Quantity, CategoryId, AddedDate) values (@ProductName, @Price, @Quantity, @CategoryId, @AddedDate)", entity);
            return entity;
        }

        public async Task<IEnumerable<SelectListItem>> Categories()
        {
            using var connection = _dbContext.GetConnection;
            var categories = await connection.QueryAsync<Category>("Select Id, CategoryName from Categories");
            return categories.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.Id.ToString()
            });
        }

        public Task<Product> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            using var connection = _dbContext.GetConnection;
            return await connection.QueryAsync<Product>("Select a.Id, ProductName, CategoryName from Products a, Categories b Where a.CategoryId = b.Id");
        }

        public Task<Product> Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
