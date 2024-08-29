// <copyright file="SQLUserDataServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace DataMapper.SqlServerDAO
{
    using System.Data.Entity;
    using DataMapper.Interfaces;
    using DomainModel.Models;
    using log4net;

    /// <summary>
    /// The user data services.
    /// </summary>
    /// <seealso cref="DataMapper.Interfaces.IUserDataServices" />
    public class SQLUserDataServices : IUserDataServices
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(Environment.MachineName);

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly AuctionContext? context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLUserDataServices"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SQLUserDataServices(AuctionContext? context = null)
        {
            this.context = context ?? new AuctionContext();
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// bool.
        /// </returns>
        public bool AddUser(User user)
        {
            try
            {
                this.context.Users.Add(user);
                this.context.SaveChanges();
                Logger.Info("User added successfully!");
                return true;
            }
            catch (Exception exception)
            {
                Logger.Error("Error while adding new user: " + exception.Message + " " + exception.InnerException);
                return false;
            }
        }

        /// <inheritdoc/>
        public IList<User> GetAllUsers()
        {
            IList<User> users = new List<User>();
            users = this.context.Users.OrderBy((user) => user.Id).ToList();
            return users;
        }

        /// <inheritdoc/>
        public User GetUserById(int id)
        {
            return this.context.Users.Where((user) => user.Id == id).FirstOrDefault();
        }

        /// <inheritdoc/>
        public User GetUserByEmailAndPassword(string email, string password)
        {
            return this.context.Users.Where((user) => user.Email == email && user.Password == password).FirstOrDefault();
        }

        /// <inheritdoc/>
        public bool EmailAlreadyExists(string email)
        {
            User? user = null;

            if (this.context.Users != null)
            {
                user = this.context.Users.Where((user) => user.Email == email).FirstOrDefault();
            }

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UsernameAlreadyExists(string username)
        {
            User? user = null;

            if (this.context.Users != null)
            {
                user = this.context.Users.Where((user) => user.UserName == username).FirstOrDefault();
            }

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateUser(User user)
        {
            try
            {
                this.context.Users.Attach(user);
                this.context.Entry(user).State = EntityState.Modified;
                this.context.SaveChanges();
                Logger.Info("User updated successfully!");
                return true;
            }
            catch (Exception exception)
            {
                Logger.Warn("Error while updating user: " + exception.Message.ToString() + " " + exception.InnerException.ToString());
                return false;
            }
        }

        /// <inheritdoc/>
        public bool DeleteUser(User user)
        {
            try
            {
                this.context.Users.Attach(user);
                this.context.Users.Remove(user);
                this.context.SaveChanges();
                Logger.Info("User deleted successfully!");
                return true;
            }
            catch (Exception exception)
            {
                Logger.Warn("Error while deleting user: " + exception.Message.ToString() + " " + exception.InnerException.ToString());
                return false;
            }
        }
    }
}
