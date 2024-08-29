// <copyright file="GetRatingTests.cs" company="Transilvania University of Brasov">
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
    /// The GetRatingTests class.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class GetRatingTests
    {
        /// <summary>
        /// Gets all ratings.
        /// </summary>
        [Test]
        public void GET_AllRatings()
        {
            List<Rating> ratings = GetSampleRatings();
            var ratingServiceMock = new Mock<IRatingDataServices>();
            ratingServiceMock.Setup(r => r.GetAllRatings()).Returns(ratings);

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);
            var expected = ratings;
            var actual = ratingServices.GetAllRatings();

            Assert.That(actual.Count, Is.EqualTo(expected.Count));

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.That(actual[i].Id, Is.EqualTo(expected[i].Id));
                Assert.That(actual[i].DateAndTime, Is.EqualTo(expected[i].DateAndTime));

                Assert.That(actual[i].Product.Id, Is.EqualTo(expected[i].Product.Id));
                Assert.That(actual[i].Product.Name, Is.EqualTo(expected[i].Product.Name));
                Assert.That(actual[i].Product.Description, Is.EqualTo(expected[i].Product.Description));
                Assert.That(actual[i].Product.Category.Id, Is.EqualTo(expected[i].Product.Category.Id));
                Assert.That(actual[i].Product.Category.Name, Is.EqualTo(expected[i].Product.Category.Name));
                Assert.That(actual[i].Product.Category.ParentCategory, Is.EqualTo(expected[i].Product.Category.ParentCategory));
                Assert.That(actual[i].Product.StartingPrice, Is.EqualTo(expected[i].Product.StartingPrice));
                Assert.That(actual[i].Product.Currency, Is.EqualTo(expected[i].Product.Currency));
                Assert.That(actual[i].Product.CreationDate, Is.EqualTo(expected[i].Product.CreationDate));
                Assert.That(actual[i].Product.StartDate, Is.EqualTo(expected[i].Product.StartDate));
                Assert.That(actual[i].Product.EndDate, Is.EqualTo(expected[i].Product.EndDate));
                Assert.That(actual[i].Product.TerminationDate, Is.EqualTo(expected[i].Product.TerminationDate));

                Assert.That(actual[i].RatingUser.Id, Is.EqualTo(expected[i].RatingUser.Id));
                Assert.That(actual[i].RatingUser.FirstName, Is.EqualTo(expected[i].RatingUser.FirstName));
                Assert.That(actual[i].RatingUser.LastName, Is.EqualTo(expected[i].RatingUser.LastName));
                Assert.That(actual[i].RatingUser.UserName, Is.EqualTo(expected[i].RatingUser.UserName));
                Assert.That(actual[i].RatingUser.PhoneNumber, Is.EqualTo(expected[i].RatingUser.PhoneNumber));
                Assert.That(actual[i].RatingUser.Email, Is.EqualTo(expected[i].RatingUser.Email));
                Assert.That(actual[i].RatingUser.Password, Is.EqualTo(expected[i].RatingUser.Password));
                Assert.That(actual[i].RatingUser.AccountType, Is.EqualTo(expected[i].RatingUser.AccountType));

                Assert.That(actual[i].RatedUser.Id, Is.EqualTo(expected[i].RatedUser.Id));
                Assert.That(actual[i].RatedUser.FirstName, Is.EqualTo(expected[i].RatedUser.FirstName));
                Assert.That(actual[i].RatedUser.LastName, Is.EqualTo(expected[i].RatedUser.LastName));
                Assert.That(actual[i].RatedUser.UserName, Is.EqualTo(expected[i].RatedUser.UserName));
                Assert.That(actual[i].RatedUser.PhoneNumber, Is.EqualTo(expected[i].RatedUser.PhoneNumber));
                Assert.That(actual[i].RatedUser.Email, Is.EqualTo(expected[i].RatedUser.Email));
                Assert.That(actual[i].RatedUser.Password, Is.EqualTo(expected[i].RatedUser.Password));
                Assert.That(actual[i].RatedUser.AccountType, Is.EqualTo(expected[i].RatedUser.AccountType));

                Assert.That(actual[i].Grade, Is.EqualTo(expected[i].Grade));
            }
        }

        /// <summary>
        /// Gets all ratings not found.
        /// </summary>
        [Test]
        public void GET_AllRatings_NotFound()
        {
            List<Rating> emptyRatingList = new List<Rating>();
            var ratingServiceMock = new Mock<IRatingDataServices>();
            ratingServiceMock.Setup(x => x.GetAllRatings()).Returns(emptyRatingList);
            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.IsEmpty(ratingServices.GetAllRatings());
        }

        /// <summary>
        /// Gets the rating by identifier.
        /// </summary>
        [Test]
        public void GET_RatingById()
        {
            Rating rating = GetSampleRating();
            var ratingServiceMock = new Mock<IRatingDataServices>();
            ratingServiceMock.Setup(x => x.GetRatingById(rating.Id)).Returns(rating);

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            var expected = rating;
            var actual = ratingServices.GetRatingById(rating.Id);

            Assert.That(actual.Id, Is.EqualTo(expected.Id));
            Assert.That(actual.DateAndTime, Is.EqualTo(expected.DateAndTime));

            Assert.That(actual.Product.Id, Is.EqualTo(expected.Product.Id));
            Assert.That(actual.Product.Name, Is.EqualTo(expected.Product.Name));
            Assert.That(actual.Product.Description, Is.EqualTo(expected.Product.Description));
            Assert.That(actual.Product.Category.Id, Is.EqualTo(expected.Product.Category.Id));
            Assert.That(actual.Product.Category.Name, Is.EqualTo(expected.Product.Category.Name));
            Assert.That(actual.Product.Category.ParentCategory, Is.EqualTo(expected.Product.Category.ParentCategory));
            Assert.That(actual.Product.StartingPrice, Is.EqualTo(expected.Product.StartingPrice));
            Assert.That(actual.Product.Currency, Is.EqualTo(expected.Product.Currency));
            Assert.That(actual.Product.CreationDate, Is.EqualTo(expected.Product.CreationDate));
            Assert.That(actual.Product.StartDate, Is.EqualTo(expected.Product.StartDate));
            Assert.That(actual.Product.EndDate, Is.EqualTo(expected.Product.EndDate));
            Assert.That(actual.Product.TerminationDate, Is.EqualTo(expected.Product.TerminationDate));

            Assert.That(actual.RatingUser.Id, Is.EqualTo(expected.RatingUser.Id));
            Assert.That(actual.RatingUser.FirstName, Is.EqualTo(expected.RatingUser.FirstName));
            Assert.That(actual.RatingUser.LastName, Is.EqualTo(expected.RatingUser.LastName));
            Assert.That(actual.RatingUser.UserName, Is.EqualTo(expected.RatingUser.UserName));
            Assert.That(actual.RatingUser.PhoneNumber, Is.EqualTo(expected.RatingUser.PhoneNumber));
            Assert.That(actual.RatingUser.Email, Is.EqualTo(expected.RatingUser.Email));
            Assert.That(actual.RatingUser.Password, Is.EqualTo(expected.RatingUser.Password));
            Assert.That(actual.RatingUser.AccountType, Is.EqualTo(expected.RatingUser.AccountType));

            Assert.That(actual.RatedUser.Id, Is.EqualTo(expected.RatedUser.Id));
            Assert.That(actual.RatedUser.FirstName, Is.EqualTo(expected.RatedUser.FirstName));
            Assert.That(actual.RatedUser.LastName, Is.EqualTo(expected.RatedUser.LastName));
            Assert.That(actual.RatedUser.UserName, Is.EqualTo(expected.RatedUser.UserName));
            Assert.That(actual.RatedUser.PhoneNumber, Is.EqualTo(expected.RatedUser.PhoneNumber));
            Assert.That(actual.RatedUser.Email, Is.EqualTo(expected.RatedUser.Email));
            Assert.That(actual.RatedUser.Password, Is.EqualTo(expected.RatedUser.Password));
            Assert.That(actual.RatedUser.AccountType, Is.EqualTo(expected.RatedUser.AccountType));

            Assert.That(actual.Grade, Is.EqualTo(expected.Grade));
        }

        /// <summary>
        /// Gets the rating by identifier not found.
        /// </summary>
        [Test]
        public void GET_RatingById_NotFound()
        {
            Rating rating = GetSampleRating();
            Rating? nullRating = null;

            var ratingServiceMock = new Mock<IRatingDataServices>();
            ratingServiceMock.Setup(x => x.GetRatingById(rating.Id)).Returns(nullRating!);

            var ratingService = new RatingServicesImplementation(ratingServiceMock.Object);
            Assert.IsNull(ratingService.GetRatingById(rating.Id));
        }

        /// <summary>
        /// Gets the ratings by user identifier.
        /// </summary>
        [Test]
        public void GET_RatingsByUserId()
        {
            Rating rating = GetSampleRating();
            IList<Rating> ratings = GetSampleRatings();

            var ratingServiceMock = new Mock<IRatingDataServices>();
            ratingServiceMock.Setup(x => x.GetRatingByUserId(rating.RatedUser.Id)).Returns(ratings);

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            var expected = ratings;
            var actual = ratingServices.GetRatingsByUserId(rating.RatedUser.Id);

            Assert.That(actual.Count, Is.EqualTo(expected.Count));

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.That(actual[i].Id, Is.EqualTo(expected[i].Id));
                Assert.That(actual[i].DateAndTime, Is.EqualTo(expected[i].DateAndTime));

                Assert.That(actual[i].Product.Id, Is.EqualTo(expected[i].Product.Id));
                Assert.That(actual[i].Product.Name, Is.EqualTo(expected[i].Product.Name));
                Assert.That(actual[i].Product.Description, Is.EqualTo(expected[i].Product.Description));
                Assert.That(actual[i].Product.Category.Id, Is.EqualTo(expected[i].Product.Category.Id));
                Assert.That(actual[i].Product.Category.Name, Is.EqualTo(expected[i].Product.Category.Name));
                Assert.That(actual[i].Product.Category.ParentCategory, Is.EqualTo(expected[i].Product.Category.ParentCategory));
                Assert.That(actual[i].Product.StartingPrice, Is.EqualTo(expected[i].Product.StartingPrice));
                Assert.That(actual[i].Product.Currency, Is.EqualTo(expected[i].Product.Currency));
                Assert.That(actual[i].Product.CreationDate, Is.EqualTo(expected[i].Product.CreationDate));
                Assert.That(actual[i].Product.StartDate, Is.EqualTo(expected[i].Product.StartDate));
                Assert.That(actual[i].Product.EndDate, Is.EqualTo(expected[i].Product.EndDate));
                Assert.That(actual[i].Product.TerminationDate, Is.EqualTo(expected[i].Product.TerminationDate));

                Assert.That(actual[i].RatingUser.Id, Is.EqualTo(expected[i].RatingUser.Id));
                Assert.That(actual[i].RatingUser.FirstName, Is.EqualTo(expected[i].RatingUser.FirstName));
                Assert.That(actual[i].RatingUser.LastName, Is.EqualTo(expected[i].RatingUser.LastName));
                Assert.That(actual[i].RatingUser.UserName, Is.EqualTo(expected[i].RatingUser.UserName));
                Assert.That(actual[i].RatingUser.PhoneNumber, Is.EqualTo(expected[i].RatingUser.PhoneNumber));
                Assert.That(actual[i].RatingUser.Email, Is.EqualTo(expected[i].RatingUser.Email));
                Assert.That(actual[i].RatingUser.Password, Is.EqualTo(expected[i].RatingUser.Password));
                Assert.That(actual[i].RatingUser.AccountType, Is.EqualTo(expected[i].RatingUser.AccountType));

                Assert.That(actual[i].RatedUser.Id, Is.EqualTo(expected[i].RatedUser.Id));
                Assert.That(actual[i].RatedUser.FirstName, Is.EqualTo(expected[i].RatedUser.FirstName));
                Assert.That(actual[i].RatedUser.LastName, Is.EqualTo(expected[i].RatedUser.LastName));
                Assert.That(actual[i].RatedUser.UserName, Is.EqualTo(expected[i].RatedUser.UserName));
                Assert.That(actual[i].RatedUser.PhoneNumber, Is.EqualTo(expected[i].RatedUser.PhoneNumber));
                Assert.That(actual[i].RatedUser.Email, Is.EqualTo(expected[i].RatedUser.Email));
                Assert.That(actual[i].RatedUser.Password, Is.EqualTo(expected[i].RatedUser.Password));
                Assert.That(actual[i].RatedUser.AccountType, Is.EqualTo(expected[i].RatedUser.AccountType));

                Assert.That(actual[i].Grade, Is.EqualTo(expected[i].Grade));
            }
        }

        /// <summary>
        /// Gets the ratings by user identifier not found.
        /// </summary>
        [Test]
        public void GET_RatingsByUserId_NotFound()
        {
            Rating rating = GetSampleRating();
            List<Rating> emptyRatingList = new List<Rating>();

            var ratingServiceMock = new Mock<IRatingDataServices>();
            ratingServiceMock.Setup(x => x.GetRatingByUserId(rating.RatedUser.Id)).Returns(emptyRatingList);

            var bidServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.IsEmpty(bidServices.GetRatingsByUserId(rating.RatedUser.Id));
        }

        /// <summary>
        /// Gets the sample rating.
        /// </summary>
        /// <returns>a rating.</returns>
        private static Rating GetSampleRating()
        {
            return new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                    DateTime.Today,
                    DateTime.Today.AddDays(1)),
                new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                8);
        }

        /// <summary>
        /// Gets the sample ratings.
        /// </summary>
        /// <returns>A list with ratings.</returns>
        private static List<Rating> GetSampleRatings()
        {
            return new List<Rating>
            {
                new Rating(
                    new Product(
                        "Aparat foto CANNON",
                        "face poze",
                        new Category("Aparat foto", null),
                        100,
                        ECurrency.EUR,
                        new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                        DateTime.Today,
                        DateTime.Today.AddDays(1)),
                    new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                    new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                    8),
                new Rating(
                    new Product(
                        "Aparat foto CANNON",
                        "face poze",
                        new Category("Aparat foto", null),
                        100,
                        ECurrency.EUR,
                        new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                        DateTime.Today,
                        DateTime.Today.AddDays(1)),
                    new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                    new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                    10),
            };
        }
    }
}
