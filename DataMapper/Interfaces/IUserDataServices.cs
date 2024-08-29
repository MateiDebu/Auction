// <copyright file="IUserDataServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace DataMapper.Interfaces
{
    using DomainModel.Models;

    /// <summary>
    /// The user data services.
    /// </summary>
    public interface IUserDataServices
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
        /// <returns>a list with all users.</returns>
        IList<User> GetAllUsers();

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a user.</returns>
        User GetUserById(int id);

        /// <summary>
        /// Gets the user by email and password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>a user.</returns>
        User GetUserByEmailAndPassword(string email, string password);

        /// <summary>
        /// Emails the already exists.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>bool.</returns>
        bool EmailAlreadyExists(string email);

        /// <summary>
        /// Usernames the already exists.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>bool.</returns>
        bool UsernameAlreadyExists(string username);

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
