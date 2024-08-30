// <copyright file="EndDateAfterStartDateAttribute.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace DomainModel
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using DomainModel.Models;

    /// <summary>
    /// The EndDataAflterDataAttribute.
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    [ExcludeFromCodeCoverage]
    public class EndDateAfterStartDateAttribute : ValidationAttribute
    {
        /// <summary>
        /// Checks whether the endDate is after the startDate or not.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>
        /// An instance of the <see cref="ValidationResult">ValidationResult</see> class.
        /// </returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("End date is required.");
            }

            DateTime endDate = (DateTime)value;
            Product product = (Product)validationContext.ObjectInstance;

            return (endDate > product.StartDate) ? ValidationResult.Success : new ValidationResult(null);
        }
    }
}
