using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using donation_MERCHANT.Models;

namespace donation_MERCHANT.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> FindAllAsync();
        Task<Product> FindOneByIdAsync(string prodId);
        Task<IEnumerable<Product>> FindByContitionAsync(Expression<Func<Product, bool>> expression);
        Task CreateAsync(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}