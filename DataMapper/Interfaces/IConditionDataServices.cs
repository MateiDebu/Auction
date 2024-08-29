// <copyright file="IConditionDataServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace DataMapper.Interfaces
{
    using DomainModel.Models;

    /// <summary>
    /// The condition data services.
    /// </summary>
    public interface IConditionDataServices
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
        /// <returns>a list of conditions.</returns>
        IList<Condition> GetAllConditions();

        /// <summary>
        /// Gets the condition by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a category.</returns>
        Condition GetConditionById(int id);

        /// <summary>
        /// Gets the name of the condition by.
        /// </summary>
        /// <param name="conditionName">Name of the condition.</param>
        /// <returns>a category.</returns>
        Condition GetConditionByName(string conditionName);

        /// <summary>
        /// Gets the k.
        /// </summary>
        /// <returns>k.</returns>
        int GetK();

        /// <summary>
        /// Gets the m.
        /// </summary>
        /// <returns>m.</returns>
        int GetM();

        /// <summary>
        /// Gets the s.
        /// </summary>
        /// <returns>s.</returns>
        int GetS();

        /// <summary>
        /// Gets the n.
        /// </summary>
        /// <returns>n.</returns>
        int GetN();

        /// <summary>
        /// Gets the t.
        /// </summary>
        /// <returns>t.</returns>
        int GetT();

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
