// <copyright file="AddRatingTests.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestServiceLayer.RatingServiceTests
{
    using System.Diagnostics.CodeAnalysis;
    using DataMapper.Interfaces;
    using DomainModel.Enums;
    using DomainModel.Models;
    using Moq;
    using NUnit.Framework;
    using ServiceLayer.Implementation;

    /// <summary>
    /// Test class for <see cref="RatingServicesImplementation.AddRating(Rating)"/> method.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class AddRatingTests
    {
        /// <summary>
        /// Adds the null rating.
        /// </summary>
        [Test]
        public void ADD_NullRating()
        {
            Rating? nullRating = null;

            var ratingServiceMock = new Mock<IRatingDataServices>();

            var ratingService = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingService.AddRating(nullRating!), Is.False);
        }

        /// <summary>
        /// Adds the invalid rating null product.
        /// </summary>
        [Test]
        public void ADD_InvalidRating_NullProduct()
        {
            Rating rating = new Rating(
               null!,
               new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
               new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
               8);

            var ratingServiceMock = new Mock<IRatingDataServices>();

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingServices.AddRating(rating), Is.False);
        }

        /// <summary>
        /// Adds the invalid rating grade less than0.
        /// </summary>
        [Test]
        public void ADD_InvalidRating_Grade_LessThan0()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                    DateTime.Today.AddDays(-10),
                    DateTime.Today.AddDays(-5)),
                new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                -1);
            var ratingServiceMock = new Mock<IRatingDataServices>();

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingServices.AddRating(rating), Is.False);
        }

        /// <summary>
        /// Adds the invalid rating grade more than10.
        /// </summary>
        [Test]
        public void ADD_InvalidRating_Grade_MoreThan10()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                    DateTime.Today.AddDays(-10),
                    DateTime.Today.AddDays(-5)),
                new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                11);
            var ratingServiceMock = new Mock<IRatingDataServices>();

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingServices.AddRating(rating), Is.False);
        }

        /// <summary>
        /// Adds the valid rating auction hasnt ended yet.
        /// </summary>
        [Test]
        public void ADD_ValidRating_AuctionHasntEndedYet()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                    DateTime.Today.AddDays(-10),
                    DateTime.Today.AddDays(10)),
                new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                6);
            var ratingServiceMock = new Mock<IRatingDataServices>();

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingServices.AddRating(rating), Is.False);
        }

        /// <summary>
        /// Adds the valid rating rating already given.
        /// </summary>
        [Test]
        public void ADD_ValidRating_RatingAlreadyGiven()
        {
            Rating rating = new Rating(
               new Product(
                   "Aparat foto CANNON",
                   "face poze",
                   new Category("Aparat foto", null),
                   100,
                   ECurrency.EUR,
                   new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                   DateTime.Today.AddDays(-10),
                   DateTime.Today.AddDays(-5)),
               new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
               new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
               6);
            var ratingServiceMock = new Mock<IRatingDataServices>();
            ratingServiceMock.Setup(x => x.GetRatingByUserIdAndProductId(rating.RatingUser.Id, rating.Product.Id)).Returns(rating);
            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingServices.AddRating(rating), Is.False);
        }

        /// <summary>Adds the invalid rating grade change exceeds allowed range.</summary>
        [Test]
        public void ADD_InvalidRating_GradeChangeExceedsAllowedRange()
        {
            var existingRating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                    DateTime.Today.AddDays(-10),
                    DateTime.Today.AddDays(-5)),
                new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                6);

            var newRating = new Rating(
                existingRating.Product,
                existingRating.RatingUser,
                existingRating.RatedUser,
                6.2);

            var ratingServiceMock = new Mock<IRatingDataServices>();
            ratingServiceMock.Setup(x => x.GetRatingByUserIdAndProductId(newRating.RatingUser.Id, newRating.Product.Id))
                             .Returns(existingRating);

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingServices.AddRating(newRating), Is.False);
        }
    }
}
