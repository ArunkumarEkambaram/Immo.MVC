using Immo.MVC.Day2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Immo.MVC.Day2.Repository
{
    public class ProductRepository : IRepositoryWithCategory<Product>
    {
        private readonly ApplicationDbContext _dbContext = null;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> Add(Product entity)
        {
            int res = 0;
            if (entity != null)
            {
                _dbContext.Products.Add(entity);
                res = await _dbContext.SaveChangesAsync();
            }
            return res > 0 ? entity : null;
        }

        public async Task<Product> Delete(int id)
        {
            int res = 0;
            var product = await _dbContext.Products.FindAsync(id);
            if (product != null)
            {
                _dbContext.Remove(product);
                res = await _dbContext.SaveChangesAsync();
            }
            return res > 0 ? product : null;
        }

        public async Task<Product> Get(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> Update(Product entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            var res = await _dbContext.SaveChangesAsync();
            if (res > 0)
                return entity;
            else
                return null;
        }

        public async Task<IEnumerable<SelectListItem>> Categories()
        {
            return await _dbContext.Categories
                .Select(c => new SelectListItem
                {
                    Text = c.CategoryName,
                    Value = c.Id.ToString()
                }).ToListAsync();
        }
    }
}
