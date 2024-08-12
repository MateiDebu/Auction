using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class User
    {
        public User(string firstName, string lastName, string userName, string phoneNumber, string email, string password)
        {

        }

        public User()
        {

        }

        public virtual int Id { get; private set; }

        [Required(ErrorMessage = "[FirstName] cannot be null.")]
        [StringLength(maximumLength:15, MinimumLength = 1, ErrorMessage = "[FirstName must be between 1 and 15 characters]")]
        [RegularExpression(@"[A-Z][a-z]+", ErrorMessage = "[FirstName] must be a valid firstname.")]

        public virtual string FirstName { get; set; }

        [Required(ErrorMessage = "[LastName] cannot be null.")]
        [StringLength(maximumLength: 15, MinimumLength = 1, ErrorMessage = "[LastName] must be between 1 and 15 characters.")]
        [RegularExpression(@"[A-Z][a-z]+", ErrorMessage = "[LastName] must be a valid lastname.")]
        public virtual string LastName { get; set; }

        [Required(ErrorMessage = "[UserName] cannot be null")]
        [StringLength(maximumLength:30, MinimumLength = 1, ErrorMessage = "[UserName] must be between 1 and 30 characters")]
        public virtual string UserName { get; set; }

        [Phone(ErrorMessage = "[PhoneNumber] is not a valid phone number.")]
        [StringLength(maximumLength:15, MinimumLength = 1, ErrorMessage = "[PhoneNumber] must have between 1 and 15 digits.")]
        public virtual string? PhoneNumber { get; set; }
    }
}
