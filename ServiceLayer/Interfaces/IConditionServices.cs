// <copyright file="IConditionServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace ServiceLayer.Interfaces
{
    using DomainModel.Models;

    /// <summary>
    /// The conditions services.
    /// </summary>
    public interface IConditionServices
    {
        /// <summary>
        /// Adds the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns>bool.</returns>
        bool AddCondition(Condition condition);

        /// <summary>
        /// Gets all conditions.
        /// </summary>
        /// <returns>a list pf conditions.</returns>
        IList<Condition> GetAllConditions();

        /// <summary>
        /// Gets the condition by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a condition.</returns>
        Condition GetConditionById(int id);

        /// <summary>
        /// Gets the name of the condition by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>a condition.</returns>
        Condition GetConditionByName(string name);

        /// <summary>
        /// Updates the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns>bool.</returns>
        bool UpdateCondition(Condition condition);

        /// <summary>
        /// Deletes the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns>bool.</returns>
        bool DeleteCondition(Condition condition);
    }
}
