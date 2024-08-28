// <copyright file="IBidDataServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

using DomainModel.Models;

namespace DataMapper.Interfaces
{
    /// <summary>
    /// The bid data services.
    /// </summary>
    public interface IBidDataServices
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
        /// <summary>
        /// Gets the no of active bids by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        int GetNoOfActiveBidsByUserId(int id);
        /// <summary>
        /// Updates the bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns></returns>
        bool UpdateBid(Bid bid);
        /// <summary>
        /// Deletes the bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns></returns>
        bool DeleteBid(Bid bid);
    }
}
