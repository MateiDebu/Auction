namespace ServiceLayer.Interfaces
{
    using DomainModel.Models;

    /// <summary>
    /// The Bid services.
    /// </summary>
    public interface IBidServices
    {
        /// <summary>
        /// Adds the bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns>true.</returns>
        bool AddBid(Bid bid);

        /// <summary>
        /// Gets all bids.
        /// </summary>
        /// <returns>A list with all bids.</returns>
        IList<Bid> GetAllBids();

        /// <summary>
        /// Gets the bid by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a bit with a specific id.</returns>
        Bid GetBidById(int id);

        /// <summary>
        /// Gets the bids by product identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a list with all bit for a product.</returns>
        IList<Bid> GetBidsByProductId(int id);
    }
}
