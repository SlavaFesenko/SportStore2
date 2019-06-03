using Microsoft.AspNetCore.Mvc;
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

        public ProductController(IProductRepository repo)
        {
            _repository = repo;
        }

        public ViewResult List() => View(_repository.Products);

    }
}
