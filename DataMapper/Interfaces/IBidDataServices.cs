// <copyright file="IBidDataServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace DataMapper.Interfaces
{
    using DomainModel.Models;

    /// <summary>
    /// The bid data services.
    /// </summary>
    public interface IBidDataServices
    {
        /// <summary>
        /// Adds the bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns>bool.</returns>
        bool AddBid(Bid bid);

        /// <summary>
        /// Gets all bids.
        /// </summary>
        /// <returns>a list with all bids.</returns>
        IList<Bid> GetAllBids();

        /// <summary>
        /// Gets the bid by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>bid.</returns>
        Bid GetBidById(int id);

        /// <summary>
        /// Gets the bids by product identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a list of bids.</returns>
        IList<Bid> GetBidsByProductId(int id);

        /// <summary>
        /// Gets the no of active bids by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>int.</returns>
        int GetNoOfActiveBidsByUserId(int id);

        /// <summary>
        /// Updates the bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns>bool.</returns>
        bool UpdateBid(Bid bid);

        /// <summary>
        /// Deletes the bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns>bool.</returns>
        bool DeleteBid(Bid bid);
    }
}
