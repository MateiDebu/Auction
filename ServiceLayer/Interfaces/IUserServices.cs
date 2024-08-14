using DomainModel.Models;

namespace ServiceLayer.Interfaces
{
    /// <summary>
    /// The user services.
    /// </summary>
    public interface IUserServices
    {
        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        bool AddUser(User user);
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        IList<User> GetAllUsers();
        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        User GetUserById(int id);
        /// <summary>
        /// Gets the user by email and password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        User GetUserByEmailAndPassword(string email, string password);
        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        bool UpdateUser(User user);
        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        bool DeleteUser(User user);
    }
}
