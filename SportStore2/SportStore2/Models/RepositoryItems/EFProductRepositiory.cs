using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore2.Models.RepositoryItems
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;
        public EFProductRepository(ApplicationDbContext context)
        {
            _context = context;
            SeedData.EnsurePopulated(_context);
        }
        public IQueryable<Product> Products => _context.Products;
    }

}
