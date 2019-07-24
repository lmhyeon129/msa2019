using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using donation_MERCHANT.Models;
using System.Linq;

namespace donation_MERCHANT.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> FindAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> FindOneByIdAsync(string prodId)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProdId == prodId);
        }

        public async Task<IEnumerable<Product>> FindByContitionAsync(Expression<Func<Product, bool>> expression)
        {
            return await _context.Products.Where(expression).ToListAsync();
        }

        public async Task CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public Task Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task Delete(Product product)
        {
            _context.Products.Remove(product);
            return _context.SaveChangesAsync();
        }
    }
}