using DataMapper.Interfaces;
using DataMapper.SqlServerDAO;
using System.Diagnostics.CodeAnalysis;

namespace DataMapper
{
    /// <summary>
    /// The service factory.
    /// </summary>
    /// <seealso cref="DataMapper.IDAOFactory" />
    public class SQLServerDAOFactory : IDAOFactory
    {
        /// <summary>
        /// Gets the product data services.
        /// </summary>
        /// <value>
        /// The product data services.
        /// </value>
        public IProductDataServices ProductDataServices
        {
            get
            {
                return new SQLProductDataServices();
            }
        }

        /// <summary>
        /// Gets the category data services.
        /// </summary>
        /// <value>
        /// The category data services.
        /// </value>
        public ICategoryDataServices CategoryDataServices
        {
            get
            {
                return new SQLCategoryDataServices();
            }
        }

        /// <summary>
        /// Gets the bid data services.
        /// </summary>
        /// <value>
        /// The bid data services.
        /// </value>
        public IBidDataServices BidDataServices
        {
            get
            {
                return new SQLBidDataServices();
            }
        }

        /// <summary>
        /// Gets the user data services.
        /// </summary>
        /// <value>
        /// The user data services.
        /// </value>
        public IUserDataServices UserDataServices
        {
            get
            {
                return new SQLUserDataServices();
            }
        }

        /// <summary>
        /// Gets the rating data services.
        /// </summary>
        /// <value>
        /// The rating data services.
        /// </value>
        public IRatingDataServices RatingDataServices
        {
            get
            {
                return new SQLRatingDataServices();
            }
        }

        /// <summary>
        /// Gets the condition data services.
        /// </summary>
        /// <value>
        /// The condition data services.
        /// </value>
        public IConditionDataServices ConditionDataServices
        {
            get
            {
                return new SQLConditionDataServices();
            }
        }

        /// <summary>
        /// Gets the user score and limits data services.
        /// </summary>
        /// <value>
        /// The user score and limits data services.
        /// </value>
        public IUserScoreAndLimitsDataServices UserScoreAndLimitsDataServices
        {
            get
            {
                return new SQLUserScoreAndLimitsDataServices();
            }
        }
    }
}
