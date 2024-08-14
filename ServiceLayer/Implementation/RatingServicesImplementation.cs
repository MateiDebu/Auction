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
    public class RatingServicesImplementation : IRatingServices
    {
        private ILog logger = LogManager.GetLogger(typeof(UserServicesImplementation));
        private IRatingDataServices ratingDataServices;

        public RatingServicesImplementation( IRatingDataServices ratingDataServices)
        {
            this.ratingDataServices = ratingDataServices;
        }

        public bool AddRating(Rating rating)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRating(Rating rating)
        {
            throw new NotImplementedException();
        }

        public IList<Rating> GetAllRatings()
        {
            throw new NotImplementedException();
        }

        public Rating GetRatingById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Rating> GetRatingsByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRating(Rating rating)
        {
            throw new NotImplementedException();
        }
    }
}
