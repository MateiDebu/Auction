// <copyright file="UpdateProductTests.cs" company="Transilvania University of Brasov">
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
    using NUnit.Framework.Internal;
    using ServiceLayer.Implementation;

    /// <summary>
    /// The class test <see cref="ProductServicesImplementation.UpdateProduct(Product)"/> method.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class UpdateProductTests
    {
        /// <summary>
        /// Updates the null product.
        /// </summary>
        [Test]
        public void UPDATE_NullProduct()
        {
            Product? nullProduct = null;

            var productServiceMock = new Mock<IProductDataServices>();
            var userScoreMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productService = new ProductServicesImplementation(productServiceMock.Object, userScoreMock.Object);

            Assert.That(productService.UpdateProduct(nullProduct!), Is.False);
        }

        /// <summary>
        /// Updates the invalid product name null.
        /// </summary>
        [Test]
        public void UPDATE_InvalidProduct_Name_Null()
        {
            Product product = new Product(
                null!,
                "face poze",
                new Category("Aparat foto", null),
                100,
                ECurrency.EUR,
                new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
                DateTime.Today.AddDays(5),
                DateTime.Today.AddDays(10));
            var productServiceMock = new Mock<IProductDataServices>();
            var userScoreMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreMock.Object);

            Assert.That(productServices.UpdateProduct(product), Is.False);
        }

        /// <summary>
        /// Updates the invalid product name empty.
        /// </summary>
        [Test]
        public void UPDATE_InvalidProduct_Name_Empty()
        {
            Product product = new Product(
                string.Empty,
                "face poze",
                new Category("Aparat foto", null),
                100,
                ECurrency.EUR,
                new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
                DateTime.Today.AddDays(5),
                DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            var userScoreMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreMock.Object);

            Assert.That(productServices.UpdateProduct(product), Is.False);
        }

        /// <summary>
        /// Updates the invalid product name too long.
        /// </summary>
        [Test]
        public void UPDATE_InvalidProduct_Name_TooLong()
        {
            Product product = new Product(
                new string('s', 251),
                "face poze",
                new Category("Aparat foto", null),
                100,
                ECurrency.EUR,
                new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
                DateTime.Today.AddDays(5),
                DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            var userScoreMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreMock.Object);

            Assert.That(productServices.UpdateProduct(product), Is.False);
        }

        /// <summary>
        /// Updates the invalid product description null.
        /// </summary>
        [Test]
        public void UPDATE_InvalidProduct_Description_Null()
        {
            Product product = new Product(
                "Aparat foto Leica",
                null!,
                new Category("Aparat foto", null),
                100,
                ECurrency.EUR,
                new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
                DateTime.Today.AddDays(5),
                DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            var userScoreMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreMock.Object);

            Assert.That(productServices.UpdateProduct(product), Is.False);
        }

        /// <summary>
        /// Updates the invalid product description empty.
        /// </summary>
        [Test]
        public void UPDATE_InvalidProduct_Description_Empty()
        {
            Product product = new Product(
                "Aparat foto Leica",
                string.Empty,
                new Category("Aparat foto", null),
                100,
                ECurrency.EUR,
                new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
                DateTime.Today.AddDays(5),
                DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            var userScoreMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreMock.Object);

            Assert.That(productServices.UpdateProduct(product), Is.False);
        }

        /// <summary>
        /// Updates the invalid product description too long.
        /// </summary>
        [Test]
        public void UPDATE_InvalidProduct_Description_TooLong()
        {
            Product product = new Product(
                "Aparat foto Leica",
                new string('s', 501),
                new Category("Aparat foto", null),
                100,
                ECurrency.EUR,
                new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
                DateTime.Today.AddDays(5),
                DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            var userScoreMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreMock.Object);

            Assert.That(productServices.UpdateProduct(product), Is.False);
        }

        /// <summary>
        /// Updates the invalid product category null.
        /// </summary>
        [Test]
        public void UPDATE_InvalidProduct_Category_Null()
        {
            Product product = new Product(
                "Aparat foto Leica",
                "face poze frumoase",
                null!,
                100,
                ECurrency.EUR,
                new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
                DateTime.Today.AddDays(5),
                DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            var userScoreMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreMock.Object);

            Assert.That(productServices.UpdateProduct(product), Is.False);
        }

        /// <summary>
        /// Updates the invalid product category name null.
        /// </summary>
        [Test]
        public void UPDATE_InvalidProduct_Category_Name_Null()
        {
            Product product = new Product(
                "Aparat foto Leica",
                "face poze frumoase",
                new Category(null!, null),
                100,
                ECurrency.EUR,
                new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
                DateTime.Today.AddDays(5),
                DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            var userScoreMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreMock.Object);

            Assert.That(productServices.UpdateProduct(product), Is.False);
        }

        /// <summary>
        /// Updates the invalid product starting price negative.
        /// </summary>
        [Test]
        public void UPDATE_InvalidProduct_StartingPrice_Negative()
        {
            Product product = new Product(
               "Aparat foto Leica",
               "face poze frumoase",
               new Category("Aparat foto", null),
               -1,
               ECurrency.EUR,
               new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
               DateTime.Today.AddDays(5),
               DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            var userScoreMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreMock.Object);

            Assert.That(productServices.UpdateProduct(product), Is.False);
        }

        /// <summary>
        /// Updates the invalid product null seller.
        /// </summary>
        [Test]
        public void UPDATE_InvalidProduct_NullSeller()
        {
            Product product = new Product(
               "Aparat foto Leica",
               "face poze frumoase",
               new Category("Aparat foto", null),
               100,
               ECurrency.EUR,
               null!,
               DateTime.Today.AddDays(5),
               DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            var userScoreMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreMock.Object);

            Assert.That(productServices.UpdateProduct(product), Is.False);
        }

        /// <summary>
        /// Updates the invalid product end date before start date.
        /// </summary>
        [Test]
        public void UPDATE_InvalidProduct_EndDateBeforeStartDate()
        {
            Product product = new Product(
               "Aparat foto Leica",
               "face poze frumoase",
               new Category("Aparat foto", null),
               10,
               ECurrency.EUR,
               new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
               DateTime.Today.AddDays(5),
               DateTime.Today);

            var productServiceMock = new Mock<IProductDataServices>();
            var userScoreMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreMock.Object);

            Assert.That(productServices.UpdateProduct(product), Is.False);
        }

        /// <summary>
        /// Updates the non existing product.
        /// </summary>
        [Test]
        public void UPDATE_NonExistingProduct()
        {
            Product product = new Product(
               "Aparat foto Leica",
               "face poze frumoase",
               new Category("Aparat foto", null),
               10,
               ECurrency.EUR,
               new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
               DateTime.Today.AddDays(5),
               DateTime.Today.AddDays(10));

            Product? nullProduct = null;
            var productMock = new Mock<Product>();
            productMock.SetupGet(p => p.Id).Returns(1);
            var productServiceMock = new Mock<IProductDataServices>();
            productServiceMock.Setup(x => x.GetProductById(product.Id)).Returns(nullProduct!);
            productServiceMock.Setup(x => x.UpdateProduct(product)).Returns(false);
            var userScoreMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreMock.Object);

            Assert.That(productServices.UpdateProduct(product), Is.False);
        }

        /// <summary>
        /// Updates the valid product description too similar too other product description.
        /// </summary>
        [Test]
        public void UPDATE_ValidProduct_DescriptionTooSimilarTooOtherProductDescription()
        {
            Product product = new Product(
              "Aparat foto Leica",
              "face poze frumoase",
              new Category("Aparat foto", null),
              10,
              ECurrency.EUR,
              new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
              DateTime.Today.AddDays(5),
              DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            productServiceMock.Setup(x => x.GetProductById(product.Id)).Returns(product);
            productServiceMock.Setup(x => x.GetAllProductDescriptions()).Returns(new List<string>() { new string('#', 500), product.Description });
            productServiceMock.Setup(x => x.UpdateProduct(product)).Returns(true);
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();
            userScoreAndLimitsServiceMock.Setup(x => x.GetConditionalValueByName("L")).Returns(100);

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.That(productServices.UpdateProduct(product), Is.False);
        }

        /// <summary>
        /// Updates the valid product.
        /// </summary>
        [Test]
        public void UPDATE_ValidProduct()
        {
            Product product = new Product(
             "Aparat foto Leica",
             "face poze frumoase",
             new Category("Aparat foto", null),
             10,
             ECurrency.EUR,
             new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
             DateTime.Today.AddDays(5),
             DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            productServiceMock.Setup(x => x.GetProductById(product.Id)).Returns(product);
            productServiceMock.Setup(x => x.GetAllProductDescriptions()).Returns(new List<string>());
            productServiceMock.Setup(x => x.UpdateProduct(product)).Returns(true);
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();
            userScoreAndLimitsServiceMock.Setup(x => x.GetConditionalValueByName("L")).Returns(100);

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.That(productServices.UpdateProduct(product), Is.True);
        }
    }
}
