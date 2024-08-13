using DomainModel.Models;

namespace ServiceLayer.Interfaces
{
    /// <summary>
    /// The rating services.
    /// </summary>
    public interface IRatingServices
    {
        /// <summary>
        /// Adds the rating.
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <returns></returns>
        bool AddRating(Rating rating);
        /// <summary>
        /// Gets all ratings.
        /// </summary>
        /// <returns></returns>
        IList<Rating> GetAllRatings();
        /// <summary>
        /// Gets the rating by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Rating GetRatingById(int id);
        /// <summary>
        /// Gets the ratings by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IList<Rating> GetRatingsByUserId(int id);
        /// <summary>
        /// Updates the rating.
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <returns></returns>
        bool UpdateRating(Rating rating);
        /// <summary>
        /// Deletes the rating.
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <returns></returns>
        bool DeleteRating(Rating rating);  
    }
}
