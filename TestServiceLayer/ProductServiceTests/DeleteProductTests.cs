// <copyright file="DeleteProductTests.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestServiceLayer.ProductServiceTests
{
    using System.Diagnostics.CodeAnalysis;
    using DataMapper.Interfaces;
    using DomainModel.Enums;
    using DomainModel.Models;
    using Moq;
    using NUnit.Framework;
    using ServiceLayer.Implementation;

    /// <summary>
    /// Test class for <see cref="ProductServicesImplementation.DeleteProduct(Product)"/> method.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class DeleteProductTests
    {
        /// <summary>
        /// Deletes the null product.
        /// </summary>
        [Test]
        public void DELETE_NullProduct()
        {
            Product? product = null;

            var productServiceMock = new Mock<IProductDataServices>();
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productService = new ProductServicesImplementation(productServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.That(productService.DeleteProduct(product!), Is.False);
        }

        /// <summary>
        /// Deletes the non existing product.
        /// </summary>
        [Test]
        public void DELETE_NonExistingProduct()
        {
            Product product = new Product(
                "Aparat foto Leica",
                "face poze frumoase",
                new Category("Aparat foto", null),
                100,
                ECurrency.EUR,
                new User("Matei", "Debu", "MateiDebu", "0770453212", "matei@gmail.com", "Matei123!!"),
                DateTime.Today.AddDays(5),
                DateTime.Today.AddDays(10));
            Product? nullProduct = null;

            var productServiceMock = new Mock<IProductDataServices>();
            productServiceMock.Setup(x => x.GetProductById(product.Id)).Returns(nullProduct!);
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.That(productServices.DeleteProduct(product), Is.False);
        }

        /// <summary>
        /// Deletes the valid product.
        /// </summary>
        [Test]
        public void DELETE_ValidProduct()
        {
            Product product = new Product(
               "Aparat foto Leica",
               "face poze frumoase",
               new Category("Aparat foto", null),
               100,
               ECurrency.EUR,
               new User("Matei", "Debu", "MateiDebu", "0770453212", "matei@gmail.com", "Matei123!!"),
               DateTime.Today.AddDays(5),
               DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            productServiceMock.Setup(x => x.GetProductById(product.Id)).Returns(product);
            productServiceMock.Setup(x => x.DeleteProduct(product)).Returns(true);
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.That(productServices.DeleteProduct(product), Is.True);
        }
    }
}
