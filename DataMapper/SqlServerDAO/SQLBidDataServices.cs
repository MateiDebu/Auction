using DataMapper.Interfaces;
using DomainModel.Models;
using log4net;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;

namespace DataMapper.SqlServerDAO
{
    /// <summary>
    /// The bid data setvices.
    /// </summary>
    /// <seealso cref="DataMapper.Interfaces.IBidDataServices" />
    [ExcludeFromCodeCoverage]
    public class SQLBidDataServices : IBidDataServices
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(Environment.MachineName);
        /// <summary>
        /// Adds the bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns></returns>
        public bool AddBid(Bid bid)
        {
           using(AuctionContext context = new AuctionContext())
            {
                try
                {
                    context.Products.Attach(bid.Product);
                    context.Users.Attach(bid.Buyer);
                    context.Bids.Add(bid);
                    context.SaveChanges();

                }catch(Exception exception)
                {
                    Logger.Error("Error while adding new bid: " + exception.Message.ToString() + " " + exception.InnerException.ToString());
                    return false;
                }
            }
            Logger.Info("Bid added successfully");
            return true;
        }

        /// <summary>
        /// Deletes the bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns></returns>
        public bool DeleteBid(Bid bid)
        {
            using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    context.Bids.Attach(bid);
                    context.Bids.Remove(bid);
                    context.SaveChanges();
                }catch(Exception exception)
                {
                    Logger.Error("Error while deleting bid: " + exception.Message.ToString() + " " + exception.InnerException.ToString());
                    return false;
                }
            }
            Logger.Info("Bid deleted successfully!");
            return true;

        }

        /// <summary>
        /// Gets all bids.
        /// </summary>
        /// <returns></returns>
        public IList<Bid> GetAllBids()
        {
            IList<Bid> bids = new List<Bid>();
            using (AuctionContext context =  new AuctionContext())
            {
                bids = context.Bids.Include("Product").Include("Buyer").OrderBy((bid) => bid.Id).ToList();
            }
            return bids;
        }

        /// <summary>
        /// Gets the bid by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Bid GetBidById(int id)
        {
            Bid bid = null;

            using(AuctionContext context = new AuctionContext())
            {
               bid =  context.Bids.Include("Product").Include("Buyer").Where((bid) => bid.Id == id).FirstOrDefault();
            }

            return bid;
        }

        /// <summary>
        /// Gets the bids by product identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IList<Bid> GetBidsByProductId(int id)
        {
            IList<Bid> productBids = new List<Bid>();

            using (AuctionContext context = new AuctionContext())
            {
                productBids = context.Bids.Include("Product").Include("Buyer").Where((bid) => bid.Product.Id == id).OrderByDescending((bid) => bid.DateAndTime).ToList();
            }

            return productBids;
        }

        /// <summary>
        /// Gets the no of active bids by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public int GetNoOfActiveBidsByUserId(int id)
        {
            int activeBids;

            using (AuctionContext context = new AuctionContext())
            {
                activeBids = context.Bids.Include("Product").Include("Buyer").Where((bid) => bid.Buyer.Id == id && bid.Product.TerminationDate > DateTime.Now).Select((bid) => bid.Product.Id).Distinct().Count();
            }
            return activeBids;
        }

        /// <summary>
        /// Updates the bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns></returns>
        public bool UpdateBid(Bid bid)
        {
            using(AuctionContext context = new AuctionContext())
            {
                try
                {
                    context.Bids.Attach(bid);
                    context.Entry(bid).State = EntityState.Modified;
                    context.SaveChanges();
                }catch(Exception exception)
                {
                    Logger.Error("Error while updating bid: " + exception.Message.ToString() + " " + exception.InnerException.ToString());
                    return false;
                }
            }
            Logger.Info("Bid update successfully!");
            return true;
        }
    }
}
