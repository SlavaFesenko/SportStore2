using System.Linq;

namespace SportStore2.Models.RepositoryItems
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
