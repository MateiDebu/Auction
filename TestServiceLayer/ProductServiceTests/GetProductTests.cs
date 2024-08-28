// <copyright file="GetProductTests.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

using DataMapper.Interfaces;
using DomainModel.Enums;
using DomainModel.Models;
using Moq;
using NUnit.Framework;
using ServiceLayer.Implementation;
using System.Diagnostics.CodeAnalysis;

namespace TestServiceLayer.ProductServiceTests
{
    /// <summary>
    /// Test class for <see cref="ProductServicesImplementation.GetAllProducts()"/> and 
    /// <see cref="ProductServicesImplementation.GetProductById(int)"/> methods.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]

    internal class GetProductTests
    {
        /// <summary>
        /// Gets all products.
        /// </summary>
        [Test]
        public void GET_AllProducts()
        {
            List<Product> products = GetSampleProducts();
            var productServiceMock = new Mock<IProductDataServices>();
            productServiceMock.Setup(x => x.GetAllProducts()).Returns(products);
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            var expected = products;
            var actual = productServices.GetAllProducts();

            Assert.That(actual.Count, Is.EqualTo(expected.Count));

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.That(actual[i].Id, Is.EqualTo(expected[i].Id));
                Assert.That(actual[i].Name, Is.EqualTo(expected[i].Name));
                Assert.That(actual[i].Description, Is.EqualTo(expected[i].Description));

                Assert.That(actual[i].Category.Id, Is.EqualTo(expected[i].Category.Id));
                Assert.That(actual[i].Category.Name, Is.EqualTo(expected[i].Category.Name));
                Assert.That(actual[i].Category.ParentCategory, Is.EqualTo(expected[i].Category.ParentCategory));

                Assert.That(actual[i].StartingPrice, Is.EqualTo(expected[i].StartingPrice));
                Assert.That(actual[i].Currency, Is.EqualTo(expected[i].Currency));
                Assert.That(actual[i].CreationDate, Is.EqualTo(expected[i].CreationDate));
                Assert.That(actual[i].StartDate, Is.EqualTo(expected[i].StartDate));
                Assert.That(actual[i].EndDate, Is.EqualTo(expected[i].EndDate));
                Assert.That(actual[i].TerminationDate, Is.EqualTo(expected[i].TerminationDate));
            }
        }

        /// <summary>
        /// Gets all products not found.
        /// </summary>
        [Test]
        public void GET_AllProducts_NotFound()
        {
            List<Product> emptyProductList = new List<Product>();

            var productServiceMock = new Mock<IProductDataServices>();
            productServiceMock.Setup(x => x.GetAllProducts()).Returns(emptyProductList);
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.IsEmpty(productServices.GetAllProducts());
        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        [Test]
        public void GET_ProductById()
        {
            Product product = GetSampleProduct();

            var productServiceMock = new Mock<IProductDataServices>();
            productServiceMock.Setup(x => x.GetProductById(product.Id)).Returns(product);
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            var expected = product;
            var actual = productServices.GetProductById(product.Id);

            Assert.That(actual.Id, Is.EqualTo(expected.Id));
            Assert.That(actual.Name, Is.EqualTo(expected.Name));
            Assert.That(actual.Description, Is.EqualTo(expected.Description));

            Assert.That(actual.Category.Id, Is.EqualTo(expected.Category.Id));
            Assert.That(actual.Category.Name, Is.EqualTo(expected.Category.Name));
            Assert.That(actual.Category.ParentCategory, Is.EqualTo(expected.Category.ParentCategory));

            Assert.That(actual.StartingPrice, Is.EqualTo(expected.StartingPrice));
            Assert.That(actual.Currency, Is.EqualTo(expected.Currency));
            Assert.That(actual.CreationDate, Is.EqualTo(expected.CreationDate));
            Assert.That(actual.StartDate, Is.EqualTo(expected.StartDate));
            Assert.That(actual.EndDate, Is.EqualTo(expected.EndDate));
            Assert.That(actual.TerminationDate, Is.EqualTo(expected.TerminationDate));
        }

        /// <summary>
        /// Gets the product by identifier not found.
        /// </summary>
        [Test]
        public void GET_ProductById_NotFound()
        {
            Product product = GetSampleProduct();
            Product nullProduct = null;

            var productServiceMock = new Mock<IProductDataServices>();
            productServiceMock.Setup(x => x.GetProductById(product.Id)).Returns(nullProduct);
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            var expected = nullProduct;
            var actual = productServices.GetProductById(product.Id);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Gets the sample product.
        /// </summary>
        /// <returns></returns>
        private static Product GetSampleProduct()
        {
            return new Product(
                "Aparat foto CANNON",
                "face poze",
                new Category("Aparat foto", null),
                100,
                ECurrency.EUR,
                new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
                DateTime.Today.AddDays(5),
                DateTime.Today.AddDays(10));
        }

        /// <summary>
        /// Gets the sample products.
        /// </summary>
        /// <returns></returns>
        private static List<Product> GetSampleProducts()
        {
            List<Product> products = new List<Product>();

            Product p1 = new Product(
                "Aparat foto CANNON",
                "face poze",
                new Category("Aparat foto", null),
                100,
                ECurrency.EUR,
                new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
                DateTime.Today.AddDays(5),
                DateTime.Today.AddDays(10));
            Product p2 = new Product(
                "Smartphone",
                "memorie buna",
                new Category("Telefoane", null),
                1000,
                ECurrency.USD,
                new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
                DateTime.Today.AddDays(5),
                DateTime.Today.AddDays(10));

            products.Add(p1);
            products.Add(p2);

            return products;
        }
    }
}
