using DataMapper.Interfaces;
using DomainModel.Models;
using log4net;
using ServiceLayer.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Implementation
{
    /// <summary>
    /// The condition services.
    /// </summary>
    /// <seealso cref="ServiceLayer.Interfaces.IConditionServices" />
    public class ConditionServicesImplementation : IConditionServices
    {
        /// <summary>
        /// The logger
        /// </summary>
        private ILog logger = LogManager.GetLogger(typeof(UserServicesImplementation));
        /// <summary>
        /// The condition data services
        /// </summary>
        private IConditionDataServices conditionDataServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionServicesImplementation"/> class.
        /// </summary>
        /// <param name="conditionDataServices">The condition data services.</param>
        public ConditionServicesImplementation(IConditionDataServices conditionDataServices)
        {
            this.conditionDataServices = conditionDataServices;
        }

        /// <summary>
        /// Adds the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        public bool AddCondition(Condition condition)
        {
            if(condition == null)
            {
                this.logger.Warn("Attemped to add a null condition.");
                return false;
            }
            var context = new ValidationContext(condition, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            if(!Validator.TryValidateObject(condition, context, results, true))
            {
                this.logger.Warn("Attemped to add an invalid condition. " + String.Join(' ', results));
                return false;
            }

            if(this.conditionDataServices.GetConditionByName(condition.Name) != null)
            {
                this.logger.Warn("Attemped to add an already existing condition.");
                return false;
            }

            return this.conditionDataServices.AddCondition(condition);
        }

        /// <summary>
        /// Deletes the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        public bool DeleteCondition(Condition condition)
        {
            if(condition == null)
            {
                this.logger.Warn("Attemped to delete a null condition.");
                return false;
            }

            if(this.conditionDataServices.GetConditionById(condition.Id) == null)
            {
                this.logger.Warn("Attemped to delete a nonexisting condition.");
            }

            return this.conditionDataServices.DeleteCondition(condition);
        }

        /// <summary>
        /// Gets all conditions.
        /// </summary>
        /// <returns></returns>
        public IList<Condition> GetAllConditions()
        {
            return this.conditionDataServices.GetAllConditions();
        }

        /// <summary>
        /// Gets the condition by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Condition GetConditionById(int id)
        {
            return this.conditionDataServices.GetConditionById(id);
        }

        /// <summary>
        /// Gets the name of the condition by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Condition GetConditionByName(string name)
        {
            return this.conditionDataServices.GetConditionByName(name);
        }

        /// <summary>
        /// Updates the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        public bool UpdateCondition(Condition condition)
        {
            if(condition == null)
            {
                this.logger.Warn("Attempted to update a null condition.");
                return false;
            }
            var context = new ValidationContext(condition, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            if(!Validator.TryValidateObject(condition, context, results, true))
            {
                this.logger.Warn("Attempted to update an invalid condition. " + String.Join(' ', results));
                return false;
            }

            if(conditionDataServices.GetConditionById(condition.Id) == null)
            {
                this.logger.Warn("Attemped to update a nonexisting condition.");
                return false;
            }

            if(condition.Name != this.conditionDataServices.GetConditionById(condition.Id).Name && this.conditionDataServices.GetConditionByName(condition.Name) != null)
            {
                this.logger.Warn("Attemped to update a condition by changing the name to an existing condtion name.");
                return false;
            }

            return this.conditionDataServices.UpdateCondition(condition);
        }
    }
}
