// <copyright file="IRatingServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace ServiceLayer.Interfaces
{
    using DomainModel.Models;

    /// <summary>
    /// The rating services.
    /// </summary>
    public interface IRatingServices
    {
        /// <summary>
        /// Adds the rating.
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <returns>bool.</returns>
        bool AddRating(Rating rating);

        /// <summary>
        /// Gets all ratings.
        /// </summary>
        /// <returns>all ratings.</returns>
        IList<Rating> GetAllRatings();

        /// <summary>
        /// Gets the rating by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>rating.</returns>
        Rating GetRatingById(int id);

        /// <summary>
        /// Gets the ratings by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>list of ratings.</returns>
        IList<Rating> GetRatingsByUserId(int id);

        /// <summary>
        /// Updates the rating.
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <returns>bool.</returns>
        bool UpdateRating(Rating rating);

        /// <summary>
        /// Deletes the rating.
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <returns>bool.</returns>
        bool DeleteRating(Rating rating);
    }
}
