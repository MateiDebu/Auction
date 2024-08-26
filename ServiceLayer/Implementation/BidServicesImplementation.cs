using DataMapper.Interfaces;
using DomainModel.Models;
using log4net;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementation
{
    public class BidServicesImplementation : IBidServices
    {
        private ILog logger = LogManager.GetLogger(typeof(UserServicesImplementation));
        private IBidDataServices bidDataServices;
        private IUserScoreAndLimitsDataServices userScoreAndLimitsDataServices;

        public BidServicesImplementation(ILog logger, IBidDataServices bidDataServices, IUserScoreAndLimitsDataServices userScoreAndLimitsDataServices)
        {
            this.logger = logger;
            this.bidDataServices = bidDataServices;
            this.userScoreAndLimitsDataServices = userScoreAndLimitsDataServices;
        }

        public bool AddBid(Bid bid)
        {
            throw new NotImplementedException();
        }

        public IList<Bid> GetAllBids()
        {
            throw new NotImplementedException();
        }

        public Bid GetBidById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Bid> GetBidsByProductId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
