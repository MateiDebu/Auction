// <copyright file="SQLRatingDataServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace DataMapper.SqlServerDAO
{
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;
    using DataMapper.Interfaces;
    using DomainModel.Models;
    using log4net;

    /// <summary>
    /// The rating data services.
    /// </summary>
    /// <seealso cref="DataMapper.Interfaces.IRatingDataServices" />
    [ExcludeFromCodeCoverage]
    public class SQLRatingDataServices : IRatingDataServices
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(Environment.MachineName);

        private readonly AuctionContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLRatingDataServices"/> class.
        /// </summary>
        /// <param name="context">context.</param>
        public SQLRatingDataServices(AuctionContext context = null)
        {
            this.context = context ?? new AuctionContext();
        }

        /// <summary>
        /// Adds the rating.
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <returns>true or false.</returns>
        public bool AddRating(Rating rating)
        {
            try
            {
                this.context.Ratings.Add(rating);
                this.context.SaveChanges();
                Logger.Info("Rating added successfully!");
                return true;
            }
            catch (Exception exception)
            {
                Logger.Error("Error while adding new rating. " + exception.Message.ToString() + " " + exception.InnerException.ToString());
                return false;
            }
        }

        /// <summary>
        /// Deletes the rating.
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <returns>true or false.</returns>
        public bool DeleteRating(Rating rating)
        {
            try
            {
                this.context.Ratings.Attach(rating);
                this.context.Ratings.Remove(rating);
                this.context.SaveChanges();
                Logger.Info("Rating deleted successfully!");
                return true;
            }
            catch (Exception exception)
            {
                Logger.Error("Error while deleting rating. " + exception.Message.ToString() + " " + exception.InnerException.ToString());
                return false;
            }
        }

        /// <summary>
        /// Gets all ratings.
        /// </summary>
        /// <returns>a list with ratings.</returns>
        public IList<Rating> GetAllRatings()
        {
            IList<Rating> ratings = new List<Rating>();
            ratings = this.context.Ratings.Include("Product").Include("RatingUser").Include("RatedUser").OrderBy((rating) => rating.Id).ToList();
            return ratings;
        }

        /// <summary>
        /// Gets the rating by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>rating.</returns>
        public Rating GetRatingById(int id)
        {
            Rating rating = null;
            rating = this.context.Ratings.Include("Product").Include("RatingUser").Include("RatedUser").Where((rating) => rating.Id == id).FirstOrDefault();
            return rating;
        }

        /// <summary>
        /// Gets the rating by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A list with ratings.</returns>
        public IList<Rating> GetRatingByUserId(int id)
        {
            IList<Rating> ratings = new List<Rating>();

            ratings = this.context.Ratings.Include("Product").Include("RatingUser").Include("RatedUser").Where((rating) => rating.RatedUser.Id == id).OrderByDescending((rating) => rating.DateAndTime).ToList();

            return ratings;
        }

        /// <summary>
        /// Gets the rating by user identifier and product identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>a rating.</returns>
        public Rating GetRatingByUserIdAndProductId(int userId, int productId)
        {
            Rating rating = null;

            rating = this.context.Ratings.Include("Product").Include("RatingUser").Include("RatedUser").Where((rating) => rating.RatingUser.Id == userId && rating.Product.Id == productId).FirstOrDefault();

            return rating;
        }

        /// <summary>
        /// Gets the winning bid user by product identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>null or winning user.</returns>
        public User GetWinningBidUserByProductId(int id)
        {
            Bid winningBid = null;

            winningBid = this.context.Bids.Include("Buyer").Include("Product").Include("Product.Seller").Where((bid) => bid.Product.Id == id).OrderByDescending((bid) => bid.DateAndTime).FirstOrDefault();

            if (winningBid != null)
            {
                return winningBid.Buyer;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Updates the rating.
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <returns>true or false.</returns>
        public bool UpdateRating(Rating rating)
        {
            try
            {
                this.context.Ratings.Attach(rating);
                this.context.Entry(rating).State = EntityState.Modified;
                this.context.SaveChanges();
                Logger.Info("Rating updated successfully!");
                return true;
            }
            catch (Exception exception)
            {
                Logger.Error("Error while updating rating. " + exception.Message.ToString() + " " + exception.InnerException.ToString());
                return false;
            }
        }
    }
}
