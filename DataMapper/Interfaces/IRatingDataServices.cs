// <copyright file="IRatingDataServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace DataMapper.Interfaces
{
    using DomainModel.Models;

    /// <summary>
    /// The rating data services.
    /// </summary>
    public interface IRatingDataServices
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
        /// <returns>a list with all ratings.</returns>
        IList<Rating> GetAllRatings();

        /// <summary>
        /// Gets the rating by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a rating.</returns>
        Rating GetRatingById(int id);

        /// <summary>
        /// Gets the rating by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a list of ratings.</returns>
        IList<Rating> GetRatingByUserId(int id);

        /// <summary>
        /// Gets the rating by user identifier and product identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>rating.</returns>
        Rating GetRatingByUserIdAndProductId(int userId, int productId);

        /// <summary>
        /// Gets the winning bid user by product identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a user.</returns>
        User GetWinningBidUserByProductId(int id);

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
