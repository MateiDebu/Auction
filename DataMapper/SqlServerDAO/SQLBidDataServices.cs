// <copyright file="SQLBidDataServices.cs" company="Transilvania University of Brasov">
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
    /// The bid data setvices.
    /// </summary>
    /// <seealso cref="DataMapper.Interfaces.IBidDataServices" />
    [ExcludeFromCodeCoverage]
    public class SQLBidDataServices : IBidDataServices
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(Environment.MachineName);

        /// <summary>
        /// Adds the bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns>bool.</returns>
        public bool AddBid(Bid bid)
        {
           using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    if (context.Products != null && context.Users != null && context.Bids != null)
                    {
                        context.Products.Attach(bid.Product);
                        context.Users.Attach(bid.Buyer);
                        context.Bids.Add(bid);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("One or more required DbSet properties are null.");
                    }
                }
                catch (Exception exception)
                {
                    Logger.Error("Error while adding new bid: " + exception.Message.ToString());
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
        /// <returns>bool.</returns>
        public bool DeleteBid(Bid bid)
        {
            using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    if (context.Bids != null)
                    {
                        context.Bids.Attach(bid);
                        context.Bids.Remove(bid);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("The Bids are null");
                    }
                }
                catch (Exception exception)
                {
                    Logger.Error("Error while deleting bid: " + exception.Message.ToString());
                    return false;
                }
            }

            Logger.Info("Bid deleted successfully!");
            return true;
        }

        /// <summary>
        /// Gets all bids.
        /// </summary>
        /// <returns>a list of bids.</returns>
        public IList<Bid> GetAllBids()
        {
            IList<Bid> bids = new List<Bid>();
            using (AuctionContext context = new AuctionContext())
            {
                if (context.Bids != null)
                {
                    bids = context.Bids.Include("Product").Include("Buyer").OrderBy((bid) => bid.Id).ToList();
                }
                else
                {
                    throw new InvalidOperationException("The Bids are null");
                }
            }

            return bids;
        }

        /// <summary>
        /// Gets the bid by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a bid.</returns>
        public Bid GetBidById(int id)
        {
            Bid? bid = null;

            using (AuctionContext context = new AuctionContext())
            {
                if (context.Bids != null)
                {
                    bid = context.Bids.Include("Product").Include("Buyer").Where((bid) => bid.Id == id).FirstOrDefault();
                }
                else
                {
                    throw new InvalidOperationException("The Bids are null");
                }
            }

            return bid!;
        }

        /// <summary>
        /// Gets the bids by product identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a list of bids.</returns>
        public IList<Bid> GetBidsByProductId(int id)
        {
            IList<Bid> productBids = new List<Bid>();

            using (AuctionContext context = new AuctionContext())
            {
                if (context.Bids != null)
                {
                    productBids = context.Bids.Include("Product").Include("Buyer").Where((bid) => bid.Product.Id == id).OrderByDescending((bid) => bid.DateAndTime).ToList();
                }
                else
                {
                    throw new InvalidOperationException("The Bids are null");
                }
            }

            return productBids;
        }

        /// <summary>
        /// Gets the no of active bids by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>int.</returns>
        public int GetNoOfActiveBidsByUserId(int id)
        {
            int activeBids = 0;

            using (AuctionContext context = new AuctionContext())
            {
                if (context.Bids != null)
                {
                    activeBids = context.Bids.Include("Product").Include("Buyer").Where((bid) => bid.Buyer.Id == id && bid.Product.TerminationDate > DateTime.Now).Select((bid) => bid.Product.Id).Distinct().Count();
                }
                else
                {
                    throw new InvalidOperationException("The Bids are null");
                }
            }

            return activeBids;
        }

        /// <summary>
        /// Updates the bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns>bool.</returns>
        public bool UpdateBid(Bid bid)
        {
            using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    if (context.Bids != null)
                    {
                        context.Bids.Attach(bid);
                        context.Entry(bid).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("The Bids are null");
                    }
                }
                catch (Exception exception)
                {
                    Logger.Error("Error while updating bid: " + exception.Message.ToString());
                    return false;
                }
            }

            Logger.Info("Bid update successfully!");
            return true;
        }
    }
}
