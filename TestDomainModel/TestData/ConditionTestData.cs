using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomainModel.TestData
{

    /// <summary>
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class ConditionTestData
    {
        /// <summary>
        /// The valid name
        /// </summary>
        private string validName = "x";
        /// <summary>
        /// The long name
        /// </summary>
        private string longName = new string('x', 16);
        /// <summary>
        /// The valid description
        /// </summary>
        private string validDescription = "description";
        /// <summary>
        /// The long description
        /// </summary>
        private string longDescription = new string('x', 101);
        /// <summary>
        /// The valid value
        /// </summary>
        private int validValue = 10;

        /// <summary>
        /// Gets the valid condition.
        /// </summary>
        /// <returns></returns>
        public Condition GetValidCondition()
        {
            return new Condition(this.validName, this.validDescription, this.validValue);
        }

        /// <summary>
        /// Gets the empty condition.
        /// </summary>
        /// <returns></returns>
        public Condition GetEmptyCondition()
        {
            return new Condition();
        }

        /// <summary>
        /// Gets the name of the condition with null.
        /// </summary>
        /// <returns></returns>
        public Condition GetConditionWithNullName()
        {
            return new Condition(null, this.validDescription, this.validValue);
        }

        /// <summary>
        /// Gets the empty name of the condition with.
        /// </summary>
        /// <returns></returns>
        public Condition GetConditionWithEmptyName()
        {
            return new Condition(string.Empty, this.validDescription, this.validValue);
        }

        /// <summary>
        /// Gets the condition with name too long.
        /// </summary>
        /// <returns></returns>
        public Condition GetConditionWithNameTooLong()
        {
            return new Condition(this.longName, this.validDescription, this.validValue);
        }

        /// <summary>
        /// Gets the condition with null description.
        /// </summary>
        /// <returns></returns>
        public Condition GetConditionWithNullDescription()
        {
            return new Condition(this.validName, null, this.validValue);
        }

        /// <summary>
        /// Gets the condition with empty description.
        /// </summary>
        /// <returns></returns>
        public Condition GetConditionWithEmptyDescription()
        {
            return new Condition(this.validName, string.Empty, this.validValue);
        }

        /// <summary>
        /// Gets the condition with description too long.
        /// </summary>
        /// <returns></returns>
        public Condition GetConditionWithDescriptionTooLong()
        {
            return new Condition(this.validName, this.longDescription, this.validValue);
        }
    }
}
