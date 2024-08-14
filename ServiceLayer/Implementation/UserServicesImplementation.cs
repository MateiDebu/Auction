using DataMapper.Interfaces;
using DomainModel.Models;
using log4net;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementation
{
    public class UserServicesImplementation : IUserServices
    {
        private ILog logger = LogManager.GetLogger(typeof(UserServicesImplementation));
        private IUserDataServices userDataServices;

        public UserServicesImplementation(IUserDataServices userDataServices)
        {
            this.userDataServices = userDataServices;
        }

        public bool AddUser(User user)
        {
            if(user == null)
            {
                this.logger.Warn("Attempted to add a null user");
                return false;
            }

            var context = new ValidationContext(user, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            if(!Validator.TryValidateObject(user, context, results, true))
            {
                this.logger.Warn("Attempted to add an invalid user. " + String.Join(' ', results));
                return false;
            }

            if(this.userDataServices.EmailAlreadyExists(user.Email) || this.userDataServices.UsernameAlreadyExists(user.UserName))
            {
                this.logger.Warn("Attempted to add an already existing user.");
                return false;
            }

            return this.userDataServices.AddUser(user);
        }

        public bool DeleteUser(User user)
        {
           if(user == null)
            {
                this.logger.Warn("Attempted to delete a null user.");
                return false;
            }

           if(this.userDataServices.GetUserById(user.Id) != null)
            {
                this.logger.Warn("Attempted to delete a nonexisting user.");
                return false;
            }

            return this.userDataServices.DeleteUser(user);
        }

        public IList<User> GetAllUsers()
        {
            return this.userDataServices.GetAllUsers();
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return this.userDataServices.GetUserByEmailAndPassword(email, password);
        }

        public User GetUserById(int id)
        {
            return this.userDataServices.GetUserById(id);
        }

        public bool UpdateUser(User user)
        {
            if(user == null)
            {
                this.logger.Warn("Attempted to update a null user");
                return false;
            }

            var context = new ValidationContext(user, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            if(!Validator.TryValidateObject(user, context, results, true))
            {
                this.logger.Warn("Attempted to update an invalid user.");
                return false;
            }

            if(this.userDataServices.GetUserById(user.Id) == null)
            {
                this.logger.Warn("Attempted to update a nonexisting user.");
                return false;
            }

            return this.userDataServices.UpdateUser(user);
        }
    }
}
