namespace ServiceLayer.Implementation
{
    using System.ComponentModel.DataAnnotations;
    using DataMapper.Interfaces;
    using DomainModel.Models;
    using log4net;
    using ServiceLayer.Interfaces;

    /// <summary>
    /// The user services.
    /// </summary>
    /// <seealso cref="ServiceLayer.Interfaces.IUserServices" />
    public class UserServicesImplementation : IUserServices
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private ILog logger = LogManager.GetLogger(typeof(UserServicesImplementation));

        /// <summary>
        /// The user data services.
        /// </summary>
        private IUserDataServices userDataServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserServicesImplementation"/> class.
        /// </summary>
        /// <param name="userDataServices">The user data services.</param>
        public UserServicesImplementation(IUserDataServices userDataServices)
        {
            this.userDataServices = userDataServices;
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>true or false.</returns>
        public bool AddUser(User user)
        {
            if (user == null)
            {
                this.logger.Warn("Attempted to add a null user");
                return false;
            }

            var context = new ValidationContext(user, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                this.logger.Warn("Attempted to add an invalid user. " + String.Join(' ', results));
                return false;
            }

            if (this.userDataServices.EmailAlreadyExists(user.Email) || this.userDataServices.UsernameAlreadyExists(user.UserName))
            {
                this.logger.Warn("Attempted to add an already existing user.");
                return false;
            }

            return this.userDataServices.AddUser(user);
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>true or false.</returns>
        public bool DeleteUser(User user)
        {
           if (user == null)
            {
                this.logger.Warn("Attempted to delete a null user.");
                return false;
            }

           if (this.userDataServices.GetUserById(user.Id) != null)
            {
                this.logger.Warn("Attempted to delete a nonexisting user.");
                return false;
            }

           return this.userDataServices.DeleteUser(user);
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>all users.</returns>
        public IList<User> GetAllUsers()
        {
            return this.userDataServices.GetAllUsers();
        }

        /// <summary>
        /// Gets the user by email and password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>user with password and email.</returns>
        public User GetUserByEmailAndPassword(string email, string password)
        {
            return this.userDataServices.GetUserByEmailAndPassword(email, password);
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>user.</returns>
        public User GetUserById(int id)
        {
            return this.userDataServices.GetUserById(id);
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>true or false.</returns>
        public bool UpdateUser(User user)
        {
            if (user == null)
            {
                this.logger.Warn("Attempted to update a null user");
                return false;
            }

            var context = new ValidationContext(user, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                this.logger.Warn("Attempted to update an invalid user.");
                return false;
            }

            if (this.userDataServices.GetUserById(user.Id) == null)
            {
                this.logger.Warn("Attempted to update a nonexisting user.");
                return false;
            }

            return this.userDataServices.UpdateUser(user);
        }
    }
}
