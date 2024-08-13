using DataMapper.Interfaces;
using DataMapper.SqlServerDAO;
using System.Diagnostics.CodeAnalysis;

namespace DataMapper
{
    [ExcludeFromCodeCoverage]
    public class SQLServerDAOFactory : IDAOFactory
    {
        public IProductDataServices ProductDataServices
        {
            get
            {
                return new SQLProductDataServices();
            }
        }

        public ICategoryDataServices CategoryDataServices
        {
            get
            {
                return new SQLCategoryDataServices();
            }
        }

        public IBidDataServices BidDataServices
        {
            get
            {
                return new SQLBidDataServices();
            }
        }

        public IUserDataServices UserDataServices
        {
            get
            {
                return new SQLUserDataServices();
            }
        }

        public IRatingDataServices RatingDataServices
        {
            get
            {
                return new SQLRatingDataServices();
            }
        }

        public IConditionDataServices ConditionDataServices
        {
            get
            {
                return new SQLConditionDataServices();
            }
        }

        public IUserScoreAndLimitsDataServices UserScoreAndLimitsDataServices
        {
            get
            {
                return new SQLUserScoreAndLimitsDataServices();
            }
        }
    }
}
