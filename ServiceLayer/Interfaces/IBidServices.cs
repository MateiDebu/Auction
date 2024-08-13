using DomainModel.Models;

namespace ServiceLayer.Interfaces
{
    /// <summary>
    /// The Bid services.
    /// </summary>
    public interface IBidServices
    {
        /// <summary>
        /// Adds the bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns></returns>
        bool AddBid(Bid bid);
        /// <summary>
        /// Gets all bids.
        /// </summary>
        /// <returns></returns>
        IList<Bid> GetAllBids();
        /// <summary>
        /// Gets the bid by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Bid GetBidById(int id);
        /// <summary>
        /// Gets the bids by product identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IList<Bid> GetBidsByProductId(int id);
    }
}
