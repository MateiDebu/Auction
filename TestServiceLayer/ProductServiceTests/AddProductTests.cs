// <copyright file="AddProductTests.cs" company="Transilvania University of Brasov">
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
    /// Test class for <see cref="ProductServicesImplementation.AddProduct(Product)"/> method.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class AddProductTests
    {
        /// <summary>
        /// Adds the null product.
        /// </summary>
        [Test]
        public void ADD_NullProduct()
        {
            Product? nullProduct = null;
            var productServiceMock = new Mock<IProductDataServices>();
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.That(productServices.AddProduct(nullProduct!), Is.False);
        }

        /// <summary>
        /// Adds the invalid product name null.
        /// </summary>
        [Test]
        public void ADD_InvalidProduct_Name_Null()
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

            Assert.That(productServices.AddProduct(product), Is.False);
        }

        /// <summary>
        /// Updates the invalid product name empty.
        /// </summary>
        [Test]
        public void ADD_InvalidProduct_Name_Empty()
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

            Assert.That(productServices.AddProduct(product), Is.False);
        }

        /// <summary>
        /// Adds the invalid product name too long.
        /// </summary>
        [Test]
        public void ADD_InvalidProduct_Name_TooLong()
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

            Assert.That(productServices.AddProduct(product), Is.False);
        }

        /// <summary>
        /// Adds the invalid product description null.
        /// </summary>
        [Test]
        public void ADD_InvalidProduct_Description_Null()
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

            Assert.That(productServices.AddProduct(product), Is.False);
        }

        /// <summary>
        /// Adds the invalid product description empty.
        /// </summary>
        [Test]
        public void ADD_InvalidProduct_Description_Empty()
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

            Assert.That(productServices.AddProduct(product), Is.False);
        }

        /// <summary>
        /// Adds the invalid product description too long.
        /// </summary>
        [Test]
        public void ADD_InvalidProduct_Description_TooLong()
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

            Assert.That(productServices.AddProduct(product), Is.False);
        }

        /// <summary>
        /// Adds the invalid product category null.
        /// </summary>
        [Test]
        public void ADD_InvalidProduct_Category_Null()
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

            Assert.That(productServices.AddProduct(product), Is.False);
        }

        /// <summary>
        /// Adds the invalid product category name null.
        /// </summary>
        [Test]
        public void ADD_InvalidProduct_Category_Name_Null()
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

            Assert.That(productServices.AddProduct(product), Is.False);
        }

        /// <summary>
        /// Adds the invalid product starting price negative.
        /// </summary>
        [Test]
        public void ADD_InvalidProduct_StartingPrice_Negative()
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

            Assert.That(productServices.AddProduct(product), Is.False);
        }

        /// <summary>
        /// Adds the invalid product null seller.
        /// </summary>
        [Test]
        public void ADD_InvalidProduct_NullSeller()
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

            Assert.That(productServices.AddProduct(product), Is.False);
        }

        /// <summary>
        /// Adds the invalid product invalid seller account type unknown.
        /// </summary>
        [Test]
        public void ADD_InvalidProduct_InvalidSeller_AccountType_Unknown()
        {
            Product product = new Product(
               "Aparat foto Leica",
               "face poze frumoase",
               new Category("Aparat foto", null),
               100,
               ECurrency.EUR,
               new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
               DateTime.Today.AddDays(5),
               DateTime.Today.AddDays(10));

            product.Seller.AccountType = EAccountType.Unknown;

            var productServiceMock = new Mock<IProductDataServices>();
            var userScoreMock = new Mock<IUserScoreAndLimitsDataServices>();

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreMock.Object);

            Assert.That(productServices.AddProduct(product), Is.False);
        }

        /// <summary>
        /// Adds the invalid product end date before start date.
        /// </summary>
        [Test]
        public void ADD_InvalidProduct_EndDateBeforeStartDate()
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

            Assert.That(productServices.AddProduct(product), Is.False);
        }

        /// <summary>
        /// Adds the valid product too many auctions.
        /// </summary>
        [Test]
        public void ADD_ValidProduct_TooManyAuctions()
        {
            Product product = new Product(
              "Aparat foto Leica",
              "face poze frumoase",
              new Category("Aparat foto", null),
              100,
              ECurrency.EUR,
              new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
              DateTime.Today.AddDays(5),
              DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            productServiceMock.Setup(x => x.GetNoOfActiveAndFutureAuctionsByUserId(product.Seller.Id)).Returns(20);
            var userScoreMock = new Mock<IUserScoreAndLimitsDataServices>();
            userScoreMock.Setup(x => x.GetUserLimitsByUserId(product.Seller.Id)).Returns(20);
            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreMock.Object);

            Assert.That(productServices.AddProduct(product), Is.False);
        }

        /// <summary>
        /// Adds the valid product too many active auctions at the same time.
        /// </summary>
        [Test]
        public void ADD_ValidProduct_TooManyActiveAuctionsAtTheSameTime()
        {
            Product product = new Product(
              "Aparat foto Leica",
              "face poze frumoase",
              new Category("Aparat foto", null),
              100,
              ECurrency.EUR,
              new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
              DateTime.Today.AddDays(5),
              DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            productServiceMock.Setup(x => x.GetNoOfActiveAndFutureAuctionsByUserId(product.Seller.Id)).Returns(19);
            productServiceMock.Setup(x => x.GetNoOfActiveAuctionsOfUserInInterval(product.Seller.Id, product.StartDate, product.TerminationDate)).Returns(10);
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();
            userScoreAndLimitsServiceMock.Setup(x => x.GetUserLimitsByUserId(product.Seller.Id)).Returns(20);
            userScoreAndLimitsServiceMock.Setup(x => x.GetConditionalValueByName("K")).Returns(10);

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.That(productServices.AddProduct(product), Is.False);
        }

        /// <summary>
        /// Adds the valid product too many active auctions at the same category.
        /// </summary>
        [Test]
        public void ADD_ValidProduct_TooManyActiveAuctionsAtTheSameCategory()
        {
            Product product = new Product(
              "Aparat foto Leica",
              "face poze frumoase",
              new Category("Aparat foto", null),
              100,
              ECurrency.EUR,
              new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
              DateTime.Today.AddDays(5),
              DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            productServiceMock.Setup(x => x.GetNoOfActiveAndFutureAuctionsByUserId(product.Seller.Id)).Returns(19);
            productServiceMock.Setup(x => x.GetNoOfActiveAuctionsOfUserInInterval(product.Seller.Id, product.StartDate, product.TerminationDate)).Returns(9);
            productServiceMock.Setup(x => x.GetNoOfActiveAuctionOfUserInCategory(product.Seller.Id, product.Category, product.StartDate, product.TerminationDate)).Returns(5);
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();
            userScoreAndLimitsServiceMock.Setup(x => x.GetUserLimitsByUserId(product.Seller.Id)).Returns(20);
            userScoreAndLimitsServiceMock.Setup(x => x.GetConditionalValueByName("K")).Returns(10);
            userScoreAndLimitsServiceMock.Setup(x => x.GetConditionalValueByName("M")).Returns(5);

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.That(productServices.AddProduct(product), Is.False);
        }

        /// <summary>
        /// Adds the valid product description too similar too other product descriptions.
        /// </summary>
        [Test]
        public void ADD_ValidProduct_DescriptionTooSimilarTooOtherProductDescriptions()
        {
            Product product = new Product(
              "Aparat foto Leica",
              "face poze frumoase",
              new Category("Aparat foto", null),
              100,
              ECurrency.EUR,
              new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
              DateTime.Today.AddDays(5),
              DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            productServiceMock.Setup(x => x.GetNoOfActiveAndFutureAuctionsByUserId(product.Seller.Id)).Returns(19);
            productServiceMock.Setup(x => x.GetNoOfActiveAuctionsOfUserInInterval(product.Seller.Id, product.StartDate, product.TerminationDate)).Returns(9);
            productServiceMock.Setup(x => x.GetNoOfActiveAuctionOfUserInCategory(product.Seller.Id, product.Category, product.StartDate, product.TerminationDate)).Returns(4);
            productServiceMock.Setup(x => x.GetAllProductDescriptions()).Returns(new List<string>() { new string('#', 500), product.Description });
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();
            userScoreAndLimitsServiceMock.Setup(x => x.GetUserLimitsByUserId(product.Seller.Id)).Returns(20);
            userScoreAndLimitsServiceMock.Setup(x => x.GetConditionalValueByName("K")).Returns(10);
            userScoreAndLimitsServiceMock.Setup(x => x.GetConditionalValueByName("M")).Returns(5);
            userScoreAndLimitsServiceMock.Setup(x => x.GetConditionalValueByName("L")).Returns(100);

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.That(productServices.AddProduct(product), Is.False);
        }

        /// <summary>
        /// Adds the valid product.
        /// </summary>
        [Test]
        public void ADD_ValidProduct()
        {
            Product product = new Product(
             "Aparat foto Leica",
             "face poze frumoase",
             new Category("Aparat foto", null),
             100,
             ECurrency.EUR,
             new User("Matei", "Debu", "MateiDebu", "0770123455", "mateideb@gmail.com", "Parola12!"),
             DateTime.Today.AddDays(5),
             DateTime.Today.AddDays(10));

            var productServiceMock = new Mock<IProductDataServices>();
            productServiceMock.Setup(x => x.GetNoOfActiveAndFutureAuctionsByUserId(product.Seller.Id)).Returns(19);
            productServiceMock.Setup(x => x.GetNoOfActiveAuctionsOfUserInInterval(product.Seller.Id, product.StartDate, product.TerminationDate)).Returns(9);
            productServiceMock.Setup(x => x.GetNoOfActiveAuctionOfUserInCategory(product.Seller.Id, product.Category, product.StartDate, product.TerminationDate)).Returns(4);
            productServiceMock.Setup(x => x.GetAllProductDescriptions()).Returns(new List<string>());
            productServiceMock.Setup(x => x.AddProduct(product)).Returns(true);
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();
            userScoreAndLimitsServiceMock.Setup(x => x.GetUserLimitsByUserId(product.Seller.Id)).Returns(20);
            userScoreAndLimitsServiceMock.Setup(x => x.GetConditionalValueByName("K")).Returns(10);
            userScoreAndLimitsServiceMock.Setup(x => x.GetConditionalValueByName("M")).Returns(5);
            userScoreAndLimitsServiceMock.Setup(x => x.GetConditionalValueByName("L")).Returns(100);

            var productServices = new ProductServicesImplementation(productServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.That(productServices.AddProduct(product), Is.True);
        }
    }
}
