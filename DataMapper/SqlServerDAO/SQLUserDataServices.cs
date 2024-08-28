using DataMapper.Interfaces;
using DomainModel.Models;
using log4net;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;

namespace DataMapper.SqlServerDAO
{
    /// <summary>
    /// The user data services.
    /// </summary>
    /// <seealso cref="DataMapper.Interfaces.IUserDataServices" />
    [ExcludeFromCodeCoverage]
    public class SQLUserDataServices : IUserDataServices
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly AuctionContext context;
        private static readonly ILog Logger = LogManager.GetLogger(Environment.MachineName);

        /// <inheritdoc/>
        
        public SQLUserDataServices(AuctionContext context = null)
        {
            this.context = context ?? new AuctionContext();
        }
        public bool AddUser(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
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
            users = context.Users.OrderBy((user) => user.Id).ToList();
            return users;
        }

        /// <inheritdoc/>
        public User GetUserById(int id)
        {
            return context.Users.Where((user) => user.Id == id).FirstOrDefault();   
        }

        /// <inheritdoc/>
        public User GetUserByEmailAndPassword(string email, string password)
        {
            return context.Users.Where((user) => user.Email == email && user.Password == password).FirstOrDefault();
        }

        /// <inheritdoc/>
        public bool EmailAlreadyExists(string email)
        {
            User user = null;

            user = context.Users.Where((user) => user.Email == email).FirstOrDefault();
           
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
            User user = null;

            user = context.Users.Where((user) => user.UserName == username).FirstOrDefault();
            
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
                context.Users.Attach(user);
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
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
                context.Users.Attach(user);
                context.Users.Remove(user);
                context.SaveChanges();
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
