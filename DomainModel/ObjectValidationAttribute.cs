﻿// <copyright file="ObjectValidationAttribute.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace DomainModel
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The ObjectValidationAttribute.
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    public class ObjectValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// Checks whether the object is valid or not.
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
                return new ValidationResult(null);
            }

            var context = new ValidationContext(value, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(value, context, results, true))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(null);
            }
        }
    }
}
