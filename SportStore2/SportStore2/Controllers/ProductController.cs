using Microsoft.AspNetCore.Mvc;
using SportStore2.Helpers;
using SportStore2.Models;
using SportStore2.Models.RepositoryItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore2.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        /// <summary>
        /// Elements per page
        /// </summary>
        private int _pageSize = 4;

        public ProductController(IProductRepository repo)
        {
            _repository = repo;
        }

        /// <summary>
        /// https://localhost:port_num/Product/List/?pageNum=2
        /// Get the list of products with pagination
        /// </summary>
        /// <param name="pageNum">Number of page to show</param>
        /// <returns></returns>
        public ViewResult List(int pageNum = 1)
        {
            var sortedProducts = _repository.Products.OrderBy(p => p.ProductID);
            var paginatedProducts = PaginationHelper.Paginate(sortedProducts, pageNum, _pageSize);

            return View(paginatedProducts);
        } 

    }
}
