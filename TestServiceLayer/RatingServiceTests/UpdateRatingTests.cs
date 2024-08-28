// <copyright file="UpdateRatingTests.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

using DataMapper.Interfaces;
using DomainModel.Enums;
using DomainModel.Models;
using Moq;
using NUnit.Framework;
using ServiceLayer.Implementation;
using System.Diagnostics.CodeAnalysis;

namespace TestServiceLayer.RatingServiceTests
{
    /// <summary>
    /// Test class for <see cref="RatingServicesImplementation.UpdateRating(Rating)"/> method.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class UpdateRatingTests
    {
        /// <summary>
        /// Updates the null rating.
        /// </summary>
        [Test]
        public void UPDATE_NullRating()
        {
            Rating nullRating = null;

            var ratingServiceMock = new Mock<IRatingDataServices>();

            var ratingService = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingService.UpdateRating(nullRating), Is.False);
        }

        /// <summary>
        /// Updates the invalid rating null product.
        /// </summary>
        [Test]
        public void UPDATE_InvalidRating_NullProduct()
        {
            Rating rating = new Rating(
               null,
               new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
               new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
               8);

            var ratingServiceMock = new Mock<IRatingDataServices>();

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingServices.UpdateRating(rating), Is.False);
        }

        /// <summary>
        /// Updates the invalid rating invalid product name null.
        /// </summary>
        [Test]
        public void UPDATE_InvalidRating_InvalidProduct_Name_Null()
        {
            Rating rating = new Rating(
             new Product(
              null,
              "face poze",
              new Category("Aparat foto", null),
              100,
              ECurrency.EUR,
              new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
              DateTime.Today.AddDays(-10),
              DateTime.Today.AddDays(-5)),
              new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
              new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
              8);

            var ratingServiceMock = new Mock<IRatingDataServices>();

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingServices.UpdateRating(rating), Is.False);
        }

        /// <summary>
        /// Updates the invalid rating invalid product name empty.
        /// </summary>
        [Test]
        public void UPDATE_InvalidRating_InvalidProduct_Name_Empty()
        {
            Rating rating = new Rating(
             new Product(
              String.Empty,
              "face poze",
              new Category("Aparat foto", null),
              100,
              ECurrency.EUR,
              new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
              DateTime.Today.AddDays(-10),
              DateTime.Today.AddDays(-5)),
              new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
              new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
              8);

            var ratingServiceMock = new Mock<IRatingDataServices>();

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingServices.UpdateRating(rating), Is.False);
        }

        /// <summary>
        /// Updates the invalid rating invalid product starting price negative.
        /// </summary>
        [Test]
        public void UPDATE_InvalidRating_InvalidProduct_StartingPrice_Negative()
        {
            Rating rating = new Rating(
             new Product(
              "Aparat",
              "face poze",
              new Category("Aparat foto", null),
              -1,
              ECurrency.EUR,
              new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
              DateTime.Today.AddDays(-10),
              DateTime.Today.AddDays(-5)),
              new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
              new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
              8);

            var ratingServiceMock = new Mock<IRatingDataServices>();

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingServices.UpdateRating(rating), Is.False);
        }

        /// <summary>
        /// Updates the invalid rating invalid product null seller.
        /// </summary>
        [Test]
        public void UPDATE_InvalidRating_InvalidProduct_NullSeller()
        {
            Rating rating = new Rating(
             new Product(
              "Aparat",
              "face poze",
              new Category("Aparat foto", null),
              10,
              ECurrency.EUR,
              null,
              DateTime.Today.AddDays(-10),
              DateTime.Today.AddDays(-5)),
              new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
              new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
              8);

            var ratingServiceMock = new Mock<IRatingDataServices>();

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingServices.UpdateRating(rating), Is.False);
        }

        /// <summary>
        /// Updates the invalid rating grade less than0.
        /// </summary>
        [Test]
        public void UPDATE_InvalidRating_Grade_LessThan0()
        {
            Rating rating = new Rating(
                new Product("Aparat foto CANNON", "face poze", new Category("Aparat foto", null), 100, ECurrency.EUR,
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                DateTime.Today.AddDays(-10),
                DateTime.Today.AddDays(-5)),
                new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                -1);
            var ratingServiceMock = new Mock<IRatingDataServices>();

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingServices.UpdateRating(rating), Is.False);
        }


        /// <summary>
        /// Updates the invalid rating grade more than10.
        /// </summary>
        [Test]
        public void UPDATE_InvalidRating_Grade_MoreThan10()
        {
            Rating rating = new Rating(
                new Product("Aparat foto CANNON", "face poze", new Category("Aparat foto", null), 100, ECurrency.EUR,
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                DateTime.Today.AddDays(-10),
                DateTime.Today.AddDays(-5)),
                new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                11);
            var ratingServiceMock = new Mock<IRatingDataServices>();

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingServices.UpdateRating(rating), Is.False);
        }

        /// <summary>
        /// Updates the invalid rating none existing rating.
        /// </summary>
        [Test]
        public void UPDATE_InvalidRating_NoneExistingRating()
        {
            Rating rating = new Rating(
                new Product("Aparat foto CANNON", "face poze", new Category("Aparat foto", null), 100, ECurrency.EUR,
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                DateTime.Today.AddDays(-10),
                DateTime.Today.AddDays(-5)),
                new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                7);
            Rating nullRating = null;
            var ratingServiceMock = new Mock<IRatingDataServices>();
            ratingServiceMock.Setup(x=>x.GetRatingById(rating.Id)).Returns(nullRating);
            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingServices.UpdateRating(rating), Is.False);
        }

        /// <summary>
        /// Updates the valid rating.
        /// </summary>
        [Test]
        public void UPDATE_ValidRating()
        {
            Rating rating = new Rating(
               new Product("Aparat foto CANNON", "face poze", new Category("Aparat foto", null), 100, ECurrency.EUR,
               new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
               DateTime.Today.AddDays(-10),
               DateTime.Today.AddDays(-5)),
               new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
               new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
               7);
            Rating nullRating = null;
            var ratingServiceMock = new Mock<IRatingDataServices>();
            ratingServiceMock.Setup(x => x.GetRatingById(rating.Id)).Returns(rating);
            ratingServiceMock.Setup(x => x.UpdateRating(rating)).Returns(true);
            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingServices.UpdateRating(rating), Is.True);
        }

    }
}
