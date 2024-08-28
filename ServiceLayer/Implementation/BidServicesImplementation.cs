// <copyright file="BidServicesImplementation.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace ServiceLayer.Implementation
{
    using System.ComponentModel.DataAnnotations;
    using DataMapper.Interfaces;
    using DomainModel.Models;
    using log4net;
    using ServiceLayer.Interfaces;

    /// <summary>
    /// The bid services.
    /// </summary>
    /// <seealso cref="ServiceLayer.Interfaces.IBidServices" />
    public class BidServicesImplementation : IBidServices
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILog logger = LogManager.GetLogger(typeof(UserServicesImplementation));

        /// <summary>
        /// The bid data services.
        /// </summary>
        private IBidDataServices bidDataServices;

        /// <summary>
        /// The user score and limits data services.
        /// </summary>
        private IUserScoreAndLimitsDataServices userScoreAndLimitsDataServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="BidServicesImplementation"/> class.
        /// </summary>
        /// <param name="bidDataServices">The bid data services.</param>
        /// <param name="userScoreAndLimitsDataServices">The user score and limits data services.</param>
        public BidServicesImplementation(IBidDataServices bidDataServices, IUserScoreAndLimitsDataServices userScoreAndLimitsDataServices)
        {
            this.bidDataServices = bidDataServices;
            this.userScoreAndLimitsDataServices = userScoreAndLimitsDataServices;
        }

        /// <summary>
        /// Adds the bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns>bool.</returns>
        public bool AddBid(Bid bid)
        {
            if (bid == null)
            {
                this.logger.Warn("Attempted to add a null bid.");
                return false;
            }

            var context = new ValidationContext(bid, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(bid, context, results, true))
            {
                this.logger.Warn("Attempted to add an invalid bid." + string.Join(' ', results));
                return false;
            }

            if (this.bidDataServices.GetNoOfActiveBidsByUserId(bid.Buyer.Id) >= this.userScoreAndLimitsDataServices.GetUserLimitsByUserId(bid.Buyer.Id))
            {
                this.logger.Warn("Attempted to bid over limit.");
            }

            if (bid.DateAndTime < bid.Product.StartDate || bid.DateAndTime > bid.Product.EndDate || bid.DateAndTime > bid.Product.TerminationDate)
            {
                this.logger.Warn("Attempted to bid before the auction started or after the auction ended.");
                return false;
            }

            if (bid.Currency != bid.Product.Currency)
            {
                this.logger.Warn("Attempted to bid with different currency.");
                return false;
            }

            var existingBids = this.bidDataServices.GetBidsByProductId(bid.Product.Id);
            if ((existingBids.Count == 0 && bid.Amount < bid.Product.StartingPrice) || (existingBids.Count > 0 && (bid.Amount < existingBids[0].Amount || bid.Buyer.Id == existingBids[0].Buyer.Id)))
            {
                this.logger.Warn("Attempted to bid with not enough money or user already has the winning bid.");
                return false;
            }

            return this.bidDataServices.AddBid(bid);
        }

        /// <summary>
        /// Gets all bids.
        /// </summary>
        /// <returns>a list of bids.</returns>
        public IList<Bid> GetAllBids()
        {
            return this.bidDataServices.GetAllBids();
        }

        /// <summary>
        /// Gets the bid by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a bid.</returns>
        public Bid GetBidById(int id)
        {
            return this.bidDataServices.GetBidById(id);
        }

        /// <summary>
        /// Gets the bids by product identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a list of bids by product id.</returns>
        public IList<Bid> GetBidsByProductId(int id)
        {
            return this.bidDataServices.GetBidsByProductId(id);
        }
    }
}
