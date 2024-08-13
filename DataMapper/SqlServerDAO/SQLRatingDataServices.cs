using DataMapper.Interfaces;
using DomainModel.Models;
using log4net;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;

namespace DataMapper.SqlServerDAO
{
    /// <summary>
    /// The rating data services.
    /// </summary>
    /// <seealso cref="DataMapper.Interfaces.IRatingDataServices" />
    [ExcludeFromCodeCoverage]
    public class SQLRatingDataServices:IRatingDataServices
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(Environment.MachineName);

        /// <summary>
        /// Adds the rating.
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <returns></returns>
        public bool AddRating(Rating rating)
        {
            using(AuctionContext context = new AuctionContext())
            {
                try
                {
                    context.Ratings.Add(rating);
                    context.SaveChanges();
                }catch(Exception exception)
                {
                    Logger.Error("Error while adding new rating. " + exception.Message.ToString() + " " + exception.InnerException.ToString());
                    return false;
                }
            }
            Logger.Info("Rating added successfully!");
            return true;
        }

        /// <summary>
        /// Deletes the rating.
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <returns></returns>
        public bool DeleteRating(Rating rating)
        {
            using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    context.Ratings.Attach(rating);
                    context.Ratings.Remove(rating);
                    context.SaveChanges();
                }
                catch (Exception exception)
                {
                    Logger.Error("Error while deleting rating. " + exception.Message.ToString() + " " + exception.InnerException.ToString());
                    return false;
                }
            }

            Logger.Info("Rating deleted successfully!");
            return true;
        }

        /// <summary>
        /// Gets all ratings.
        /// </summary>
        /// <returns></returns>
        public IList<Rating> GetAllRatings()
        {
            IList<Rating> ratings = new List<Rating>();
            using(AuctionContext context = new AuctionContext())
            {
                ratings = context.Ratings.Include("Product").Include("RatingUser").Include("RatedUser").OrderBy((rating) => rating.Id).ToList();
            }
            return ratings;
        }

        /// <summary>
        /// Gets the rating by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Rating GetRatingById(int id)
        {
            Rating rating = null;
            using (AuctionContext context = new AuctionContext())
            {
                rating = context.Ratings.Include("Product").Include("RatingUser").Include("RatedUser").Where((rating) => rating.Id == id).FirstOrDefault();
            }
            return rating;
        }

        /// <summary>
        /// Gets the rating by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IList<Rating> GetRatingByUserId(int id)
        {

            IList<Rating> ratings = new List<Rating>();

            using (AuctionContext context = new AuctionContext())
            {
                ratings = context.Ratings.Include("Product").Include("RatingUser").Include("RatedUser").Where((rating) => rating.RatedUser.Id == id).OrderByDescending((rating) => rating.DateAndTime).ToList();
            }

            return ratings;
        }

        /// <summary>
        /// Gets the rating by user identifier and product identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public Rating GetRatingByUserIdAndProductId(int userId, int productId)
        {
            Rating rating = null;

            using (AuctionContext context = new AuctionContext())
            {
                rating = context.Ratings.Include("Product").Include("RatingUser").Include("RatedUser").Where((rating) => rating.RatingUser.Id == userId && rating.Product.Id == productId).FirstOrDefault();
            }

            return rating;
        }

        /// <summary>
        /// Gets the winning bid user by product identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public User GetWinningBidUserByProductId(int id)
        {
            Bid winningBid = null;

            using (AuctionContext context = new AuctionContext())
            {
                winningBid = context.Bids.Include("Buyer").Include("Product").Include("Product.Seller").Where((bid) => bid.Product.Id == id).OrderByDescending((bid) => bid.DateAndTime).FirstOrDefault();
            }

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
        /// <returns></returns>
        public bool UpdateRating(Rating rating)
        {
            using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    context.Ratings.Attach(rating);
                    context.Entry(rating).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception exception)
                {
                    Logger.Error("Error while updating rating. " + exception.Message.ToString() + " " + exception.InnerException.ToString());
                    return false;
                }
            }

            Logger.Info("Rating updated successfully!");
            return true;
        }
    }
}
