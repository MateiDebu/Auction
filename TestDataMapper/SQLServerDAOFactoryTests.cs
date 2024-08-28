// <copyright file="SQLServerDAOFactoryTests.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestDataMapper
{
    using System.Diagnostics.CodeAnalysis;
    using DataMapper;
    using DataMapper.SqlServerDAO;
    using NUnit.Framework;

    /// <summary>
    /// Test for <see cref="SQLServerDAOFactory"/> class.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class SQLServerDAOFactoryTests
    {
        /// <summary>
        /// The factory.
        /// </summary>
        private SQLServerDAOFactory factory;

        /// <summary>
        /// Sets up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.factory = new SQLServerDAOFactory();
        }

        /// <summary>
        /// Products the data services should return SQL product data services instance.
        /// </summary>
        [Test]
        public void ProductDataServices_ShouldReturnSQLProductDataServicesInstance()
        {
            var service = this.factory.ProductDataServices;

            Assert.IsNotNull(service);
            Assert.IsInstanceOf<SQLProductDataServices>(service);
        }

        /// <summary>
        /// Categories the data services should return SQL category data services instance.
        /// </summary>
        [Test]
        public void CategoryDataServices_ShouldReturnSQLCategoryDataServicesInstance()
        {
            var service = this.factory.CategoryDataServices;

            Assert.IsNotNull(service);
            Assert.IsInstanceOf<SQLCategoryDataServices>(service);
        }

        /// <summary>
        /// Bids the data services should return SQL bid data services instance.
        /// </summary>
        [Test]
        public void BidDataServices_ShouldReturnSQLBidDataServicesInstance()
        {
            var service = this.factory.BidDataServices;

            Assert.IsNotNull(service);
            Assert.IsInstanceOf<SQLBidDataServices>(service);
        }

        /// <summary>
        /// Users the data services should return SQL user data services instance.
        /// </summary>
        [Test]
        public void UserDataServices_ShouldReturnSQLUserDataServicesInstance()
        {
            var service = this.factory.UserDataServices;

            Assert.IsNotNull(service);
            Assert.IsInstanceOf<SQLUserDataServices>(service);
        }

        /// <summary>
        /// Ratings the data services should return SQL rating data services instance.
        /// </summary>
        [Test]
        public void RatingDataServices_ShouldReturnSQLRatingDataServicesInstance()
        {
            var service = this.factory.RatingDataServices;

            Assert.IsNotNull(service);
            Assert.IsInstanceOf<SQLRatingDataServices>(service);
        }

        /// <summary>
        /// Conditions the data services should return SQL condition data services instance.
        /// </summary>
        [Test]
        public void ConditionDataServices_ShouldReturnSQLConditionDataServicesInstance()
        {
            var service = this.factory.ConditionDataServices;

            Assert.IsNotNull(service);
            Assert.IsInstanceOf<SQLConditionDataServices>(service);
        }

        /// <summary>
        /// Users the score and limits data services should return SQL user score and limits data services instance.
        /// </summary>
        [Test]
        public void UserScoreAndLimitsDataServices_ShouldReturnSQLUserScoreAndLimitsDataServicesInstance()
        {
            var service = this.factory.UserScoreAndLimitsDataServices;

            Assert.IsNotNull(service);
            Assert.IsInstanceOf<SQLUserScoreAndLimitsDataServices>(service);
        }
    }
}
