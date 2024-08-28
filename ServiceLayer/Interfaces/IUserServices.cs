// <copyright file="IUserServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace ServiceLayer.Interfaces
{
    using DomainModel.Models;

    /// <summary>
    /// The user services.
    /// </summary>
    public interface IUserServices
    {
        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>bool.</returns>
        bool AddUser(User user);

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>list of User.</returns>
        IList<User> GetAllUsers();

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>User.</returns>
        User GetUserById(int id);

        /// <summary>
        /// Gets the user by email and password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>User.</returns>
        User GetUserByEmailAndPassword(string email, string password);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>bool.</returns>
        bool UpdateUser(User user);

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>bool.</returns>
        bool DeleteUser(User user);
    }
}
