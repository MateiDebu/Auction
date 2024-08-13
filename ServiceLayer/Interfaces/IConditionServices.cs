using DomainModel.Models;

namespace ServiceLayer.Interfaces
{
    /// <summary>
    /// The conditions services.
    /// </summary>
    public interface IConditionServices
    {
        /// <summary>
        /// Adds the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        bool AddCondition(Condition condition);
        /// <summary>
        /// Gets all conditions.
        /// </summary>
        /// <returns></returns>
        IList<Condition> GetAllConditions();
        /// <summary>
        /// Gets the condition by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Condition GetConditionById(int id);
        /// <summary>
        /// Gets the name of the condition by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        Condition GetConditionByName(string name);
        /// <summary>
        /// Updates the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        bool UpdateCondition(Condition condition);
        /// <summary>
        /// Deletes the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        bool DeleteCondition(Condition condition);  

    }
}
