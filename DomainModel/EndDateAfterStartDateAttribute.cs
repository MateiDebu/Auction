using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [ExcludeFromCodeCoverage]
    public class EndDateAfterStartDateAttribute : ValidationAttribute
    {
        /// <summary>Checks whether the endDate is after the startDate or not.</summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>An instance of the <see cref="ValidationResult">ValidationResult</see> class.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime endDate = (DateTime)value;
            Product product = (Product)validationContext.ObjectInstance;

            return (endDate > product.StartDate) ? ValidationResult.Success : new ValidationResult(null);
        }
    }
}
