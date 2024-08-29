// <copyright file="GetBidTests.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestServiceLayer.BidServiceTests
{
    using System.Diagnostics.CodeAnalysis;
    using DataMapper.Interfaces;
    using DomainModel.Enums;
    using DomainModel.Models;
    using Moq;
    using NUnit.Framework;
    using ServiceLayer.Implementation;

    /// <summary>
    /// Test class for GetBidTests.
    /// <see cref="BidServicesImplementation.GetAllBids()"/>
    /// <see cref="BidServicesImplementation.GetBidById(int)"/> and
    /// <see cref="BidServicesImplementation.GetBidsByProductId(int)"/> methods.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class GetBidTests
    {
        /// <summary>
        /// Gets all bids.
        /// </summary>
        [Test]
        public void GET_AllBids()
        {
            IList<Bid> bids = GetSampleBids();

            var bidServiceMock = new Mock<IBidDataServices>();
            bidServiceMock.Setup(x => x.GetAllBids()).Returns(bids);
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();
            var bidServices = new BidServicesImplementation(bidServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            var expected = bids;
            var actual = bidServices.GetAllBids();

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

                Assert.That(actual[i].Buyer.Id, Is.EqualTo(expected[i].Buyer.Id));
                Assert.That(actual[i].Buyer.FirstName, Is.EqualTo(expected[i].Buyer.FirstName));
                Assert.That(actual[i].Buyer.LastName, Is.EqualTo(expected[i].Buyer.LastName));
                Assert.That(actual[i].Buyer.UserName, Is.EqualTo(expected[i].Buyer.UserName));
                Assert.That(actual[i].Buyer.PhoneNumber, Is.EqualTo(expected[i].Buyer.PhoneNumber));
                Assert.That(actual[i].Buyer.Email, Is.EqualTo(expected[i].Buyer.Email));
                Assert.That(actual[i].Buyer.Password, Is.EqualTo(expected[i].Buyer.Password));
                Assert.That(actual[i].Buyer.AccountType, Is.EqualTo(expected[i].Buyer.AccountType));

                Assert.That(actual[i].Amount, Is.EqualTo(expected[i].Amount));
                Assert.That(actual[i].Currency, Is.EqualTo(expected[i].Currency));
            }
        }

        /// <summary>
        /// Gets all ratings not found.
        /// </summary>
        [Test]
        public void GET_AllRatings_NotFound()
        {
            List<Bid> emptyBidList = new List<Bid>();
            var bidServiceMock = new Mock<IBidDataServices>();
            bidServiceMock.Setup(b => b.GetAllBids()).Returns(emptyBidList);
            var userScore = new Mock<IUserScoreAndLimitsDataServices>();

            var bidServices = new BidServicesImplementation(bidServiceMock.Object, userScore.Object);

            Assert.IsEmpty(bidServices.GetAllBids());
        }

        /// <summary>
        /// Gets the bid by identifier.
        /// </summary>
        [Test]
        public void GET_BidById()
        {
            Bid bid = GetSampleBid();

            var bidServiceMock = new Mock<IBidDataServices>();
            bidServiceMock.Setup(x => x.GetBidById(bid.Id)).Returns(bid);
            var userScore = new Mock<IUserScoreAndLimitsDataServices>();
            var bidServices = new BidServicesImplementation(bidServiceMock.Object, userScore.Object);

            var expected = bid;
            var actual = bidServices.GetBidById(bid.Id);

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

            Assert.That(actual.Buyer.Id, Is.EqualTo(expected.Buyer.Id));
            Assert.That(actual.Buyer.FirstName, Is.EqualTo(expected.Buyer.FirstName));
            Assert.That(actual.Buyer.LastName, Is.EqualTo(expected.Buyer.LastName));
            Assert.That(actual.Buyer.UserName, Is.EqualTo(expected.Buyer.UserName));
            Assert.That(actual.Buyer.PhoneNumber, Is.EqualTo(expected.Buyer.PhoneNumber));
            Assert.That(actual.Buyer.Email, Is.EqualTo(expected.Buyer.Email));
            Assert.That(actual.Buyer.Password, Is.EqualTo(expected.Buyer.Password));
            Assert.That(actual.Buyer.AccountType, Is.EqualTo(expected.Buyer.AccountType));

            Assert.That(actual.Amount, Is.EqualTo(expected.Amount));
            Assert.That(actual.Currency, Is.EqualTo(expected.Currency));
        }

        /// <summary>
        /// Gets the bid by identifier not found.
        /// </summary>
        [Test]
        public void GET_BidById_NotFound()
        {
            Bid bid = GetSampleBid();
            Bid? nullBid = null;

            var bidServiceMock = new Mock<IBidDataServices>();
            bidServiceMock.Setup(x => x.GetBidById(bid.Id)).Returns(nullBid!);
            var userScore = new Mock<IUserScoreAndLimitsDataServices>();

            var bidServices = new BidServicesImplementation(bidServiceMock.Object, userScore.Object);
            Assert.IsNull(bidServices.GetBidById(bid.Id));
        }

        /// <summary>
        /// Gets the bids by product identifier.
        /// </summary>
        [Test]
        public void GET_BidsByProductId()
        {
            Bid bid = GetSampleBid();
            IList<Bid> bids = GetSampleBids();
            var bidServiceMock = new Mock<IBidDataServices>();
            bidServiceMock.Setup(x => x.GetBidsByProductId(bid.Product.Id)).Returns(bids);
            var userScore = new Mock<IUserScoreAndLimitsDataServices>();

            var bidServices = new BidServicesImplementation(bidServiceMock.Object, userScore.Object);

            var expected = bids;
            var actual = bidServices.GetBidsByProductId(bid.Product.Id);

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

                Assert.That(actual[i].Buyer.Id, Is.EqualTo(expected[i].Buyer.Id));
                Assert.That(actual[i].Buyer.FirstName, Is.EqualTo(expected[i].Buyer.FirstName));
                Assert.That(actual[i].Buyer.LastName, Is.EqualTo(expected[i].Buyer.LastName));
                Assert.That(actual[i].Buyer.UserName, Is.EqualTo(expected[i].Buyer.UserName));
                Assert.That(actual[i].Buyer.PhoneNumber, Is.EqualTo(expected[i].Buyer.PhoneNumber));
                Assert.That(actual[i].Buyer.Email, Is.EqualTo(expected[i].Buyer.Email));
                Assert.That(actual[i].Buyer.Password, Is.EqualTo(expected[i].Buyer.Password));
                Assert.That(actual[i].Buyer.AccountType, Is.EqualTo(expected[i].Buyer.AccountType));

                Assert.That(actual[i].Amount, Is.EqualTo(expected[i].Amount));
                Assert.That(actual[i].Currency, Is.EqualTo(expected[i].Currency));
            }
        }

        /// <summary>
        /// Gets the bids by product identifier not found.
        /// </summary>
        [Test]
        public void GET_BidsByProductId_NotFound()
        {
            Bid bid = GetSampleBid();
            IList<Bid> emptyBidList = new List<Bid>();

            var bidServiceMock = new Mock<IBidDataServices>();
            bidServiceMock.Setup(x => x.GetBidsByProductId(bid.Product.Id)).Returns(emptyBidList);
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var bidServices = new BidServicesImplementation(bidServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.IsEmpty(bidServices.GetBidsByProductId(bid.Product.Id));
        }

        /// <summary>
        /// Gets the sample bid.
        /// </summary>
        /// <returns>a bid.</returns>
        private static Bid GetSampleBid()
        {
            return new Bid(
                new Product(
                    "Aparat foto Leica",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "MateiDebu", "0770432566", "mateide@yahoo.com", "Parola12!"),
                    DateTime.Today.AddDays(-5),
                    DateTime.Today.AddDays(5)),
                new User("Vladut", "Andrei", "AndVlad", "0892122344", "vlad@hormail.com", "Parola32!"),
                1000,
                ECurrency.EUR);
        }

        /// <summary>
        /// Gets the sample bids.
        /// </summary>
        /// <returns>a list of bids.</returns>
        private static List<Bid> GetSampleBids()
        {
            return new List<Bid>
            {
                new Bid(
                new Product(
                    "Aparat foto Leica",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "MateiDebu", "0770432566", "mateide@yahoo.com", "Parola12!"),
                    DateTime.Today.AddDays(-5),
                    DateTime.Today.AddDays(5)),
                new User("Vladut", "Andrei", "AndVlad", "0892122344", "vlad@hormail.com", "Parola32!"),
                1000,
                ECurrency.EUR),
                new Bid(
                new Product(
                    "Aparat foto Canon",
                    "face poze frumoase",
                    new Category("Aparat foto", null),
                    10,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "MateiDebu", "0770432566", "mateide@yahoo.com", "Parola12!"),
                    DateTime.Today.AddDays(-5),
                    DateTime.Today.AddDays(5)),
                new User("Vladut", "Andrei", "AndVlad", "0892122344", "vlad@hormail.com", "Parola32!"),
                100,
                ECurrency.EUR),
            };
        }
    }
}
