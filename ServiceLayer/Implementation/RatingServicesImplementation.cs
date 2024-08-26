using DataMapper.Interfaces;
using DomainModel.Models;
using log4net;
using ServiceLayer.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Implementation
{
    /// <summary>
    /// The rating services.
    /// </summary>
    /// <seealso cref="ServiceLayer.Interfaces.IRatingServices" />
    public class RatingServicesImplementation : IRatingServices
    {
        /// <summary>
        /// The logger
        /// </summary>
        private ILog logger = LogManager.GetLogger(typeof(UserServicesImplementation));
        /// <summary>
        /// The rating data services
        /// </summary>
        private IRatingDataServices ratingDataServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="RatingServicesImplementation"/> class.
        /// </summary>
        /// <param name="ratingDataServices">The rating data services.</param>
        public RatingServicesImplementation( IRatingDataServices ratingDataServices)
        {
            this.ratingDataServices = ratingDataServices;
        }

        /// <summary>
        /// Adds the rating.
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <returns></returns>
        public bool AddRating(Rating rating)
        {
            if(rating == null)
            {
                this.logger.Warn("Attempted to add a null rating.");
                return false;
            }

            var context = new ValidationContext(rating, serviceProvider: null, items: null);
            var resutls = new List<ValidationResult>();
            if(!Validator.TryValidateObject(rating, context, resutls, true))
            {
                this.logger.Warn("Attempted to add an invalid rating. " + String.Join(' ', resutls));
                return false;
            }

            if(rating.DateAndTime < rating.Product.TerminationDate)
            {
                this.logger.Warn("Attempted to add rating on an active auction. ");
                return false;
            }

            if (this.ratingDataServices.GetRatingByUserIdAndProductId(rating.RatingUser.Id, rating.Product.Id) != null)
            {
                this.logger.Warn("Attempted to add ranting again on an auction.");
                return false;
            }
            User winningBidUser = this.ratingDataServices.GetWinningBidUserByProductId(rating.Product.Id);

            if ((rating.RatingUser.Id != rating.Product.Seller.Id && rating.RatingUser.Id != winningBidUser.Id)
                || (rating.RatingUser.Id == rating.Product.Seller.Id && rating.RatedUser.Id != winningBidUser.Id)
                || (rating.RatingUser.Id == winningBidUser.Id && rating.RatedUser.Id != rating.Product.Seller.Id))
            {
                this.logger.Warn("Attempted to add rating to other user.");
                return false;
            }

            return this.ratingDataServices.AddRating(rating);
        }

        /// <summary>
        /// Deletes the rating.
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <returns></returns>
        public bool DeleteRating(Rating rating)
        {
            if(rating == null)
            {
                this.logger.Warn("Attempted to delete a null rating");
                return false;
            }
            if(this.ratingDataServices.GetRatingById(rating.Id) == null)
            {
                this.logger.Warn("Attempted to delete a nonexisting rating.");
                return false;
            }
            return this.ratingDataServices.DeleteRating(rating);
        }

        /// <summary>
        /// Gets all ratings.
        /// </summary>
        /// <returns></returns>
        public IList<Rating> GetAllRatings()
        {
            return this.ratingDataServices.GetAllRatings();
        }

        /// <summary>
        /// Gets the rating by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Rating GetRatingById(int id)
        {
            return this.ratingDataServices.GetRatingById(id);
        }

        /// <summary>
        /// Gets the ratings by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IList<Rating> GetRatingsByUserId(int id)
        {
            return this.ratingDataServices.GetRatingByUserId(id);
        }

        /// <summary>
        /// Updates the rating.
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <returns></returns>
        public bool UpdateRating(Rating rating)
        {
            if(rating == null)
            {
                this.logger.Warn("Attempted to update a null string.");
                return false;
            }

            var context = new ValidationContext(rating, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            if(!Validator.TryValidateObject(rating, context, results, true))
            {
                this.logger.Warn("Attempted to update an invalid rating." + String.Join(' ', results));
                return false;
            }

            if(this.ratingDataServices.GetRatingById(rating.Id) == null)
            {
                this.logger.Warn("Attempted to update  a nonexisting rating.");
                return false;
            }

            return this.ratingDataServices.UpdateRating(rating);
        }
    }
}
