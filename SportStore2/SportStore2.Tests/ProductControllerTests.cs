using Moq;
using Xunit;
using SportStore2.Models.RepositoryItems;
using SportStore2.Models;
using System.Linq;
using SportStore2.Controllers;
using System.Collections.Generic;

namespace SportStore2Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            #region Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            }).AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            #endregion

            #region Act

            IEnumerable<Product> result =
                controller.List(2).ViewData.Model as IEnumerable<Product>;

            #endregion

            #region Assert

            Product[] prodArray = result.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);

            #endregion


        }
    }
}
