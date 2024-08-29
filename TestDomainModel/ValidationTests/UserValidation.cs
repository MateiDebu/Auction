// <copyright file="UserValidation.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestDomainModel.ValidationTests
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using DomainModel.Models;
    using NUnit.Framework;
    using TestDomainModel.TestData;

    /// <summary>
    /// The UserValidation class.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class UserValidation
    {
        /// <summary>
        /// The user test data.
        /// </summary>
        private UserTestData userTestData;

        /// <summary>
        /// The results.
        /// </summary>
        private List<ValidationResult> results = new List<ValidationResult>();

        /// <summary>
        /// Determines whether [is valid user] [the specified user].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        ///   <c>true</c> if [is valid user] [the specified user]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValidUser(User user)
        {
            var context = new ValidationContext(user, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            bool validationResult = Validator.TryValidateObject(user, context, results, true);
            this.results.AddRange(results);
            return validationResult;
        }

        /// <summary>
        /// Called when [time set up].
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.userTestData = new UserTestData();
        }

        /// <summary>
        /// Sets up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.results = new List<ValidationResult>();
        }

        /// <summary>
        /// Valids the user.
        /// </summary>
        [Test]
        public void ValidUser()
        {
            Assert.IsTrue(this.IsValidUser(this.userTestData.GetValidUser()));
            Assert.That(this.results.Count, Is.EqualTo(0));
        }

        /// <summary>
        /// Invalids the user empty user.
        /// </summary>
        [Test]
        public void InvalidUser_EmptyUser()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetEmptyUser()));
            Assert.That(this.results.Count, Is.EqualTo(6));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithNullFirstName));
            Assert.That(this.results[1].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithNullLastName));
            Assert.That(this.results[2].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithNullUserName));
            Assert.That(this.results[3].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithNullEmail));
            Assert.That(this.results[4].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithNullPassword));
            Assert.That(this.results[5].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithUnknownAccountType));
        }

        /// <summary>
        /// Test for invalid user (user with null first name).
        /// </summary>
        [Test]
        public void InvalidUser_FirstName_Null()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithNullFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithNullFirstName));
        }

        /// <summary>
        /// Test for invalid user (user with empty first name).
        /// </summary>
        [Test]
        public void InvalidUser_FirstName_Empty()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithEmptyFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithNullFirstName));
        }

        /// <summary>
        /// Test for invalid user (user with first name too long).
        /// </summary>
        [Test]
        public void InvalidUser_FirstName_TooLong()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithFirstNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithFirstNameTooLong));
        }

        /// <summary>
        /// Test for invalid user (user with first name that doesn't start with an uppercase letter).
        /// </summary>
        [Test]
        public void InvalidUser_FirstName_NoUpperCaseLetter()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithNoUppercaseLetterInFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithInvalidFirstName));
        }

        /// <summary>
        /// Test for invalid user (user with first name that only has uppercase letters).
        /// </summary>
        [Test]
        public void InvalidUser_FirstName_NoLowerCaseLetters()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithNoLowercaseLetterInFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithInvalidFirstName));
        }

        /// <summary>
        /// Test for invalid user (user with first name that contains symbols).
        /// </summary>
        [Test]
        public void InvalidUser_FirstName_ContainsSymbol()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithSymbolInFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithInvalidFirstName));
        }

        /// <summary>
        /// Test for invalid user (user with first name that contains numbers).
        /// </summary>
        [Test]
        public void InvalidUser_FirstName_ContainsNumber()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithNumberInFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithInvalidFirstName));
        }

        /// <summary>
        /// Test for invalid user (user with null last name).
        /// </summary>
        [Test]
        public void InvalidUser_LastName_Null()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithNullLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithNullLastName));
        }

        /// <summary>
        /// Test for invalid user (user with empty last name).
        /// </summary>
        [Test]
        public void InvalidUser_LastName_Empty()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithEmptyLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithNullLastName));
        }

        /// <summary>
        /// Test for invalid user (user with last name too long).
        /// </summary>
        [Test]
        public void InvalidUser_LastName_TooLong()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithLastNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithLastNameTooLong));
        }

        /// <summary>
        /// Test for invalid user (user with last name that doesn't start with an uppercase letter).
        /// </summary>
        [Test]
        public void InvalidUser_LastName_NoUpperCaseLetter()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithNoUppercaseLetterInLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithInvalidLastName));
        }

        /// <summary>
        /// Test for invalid user (user with last name that only has uppercase letters).
        /// </summary>
        [Test]
        public void InvalidUser_LastName_NoLowerCaseLetters()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithNoLowercaseLetterInLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithInvalidLastName));
        }

        /// <summary>
        /// Test for invalid user (user with last name that contains symbols).
        /// </summary>
        [Test]
        public void InvalidUser_LastName_ContainsSymbol()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithSymbolInLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithInvalidLastName));
        }

        /// <summary>
        /// Test for invalid user (user with last name that contains numbers).
        /// </summary>
        [Test]
        public void InvalidUser_LastName_ContainsNumber()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithNumberInLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithInvalidLastName));
        }

        /// <summary>
        /// Test for invalid user (user with null username).
        /// </summary>
        [Test]
        public void InvalidUser_UserName_Null()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithNullUserName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithNullUserName));
        }

        /// <summary>
        /// Test for invalid user (user with empty username).
        /// </summary>
        [Test]
        public void InvalidUser_UserName_Empty()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithEmptyUserName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithNullUserName));
        }

        /// <summary>
        /// Test for invalid user (user with username too long).
        /// </summary>
        [Test]
        public void InvalidUser_UserName_TooLong()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithUserNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithUserNameTooLong));
        }

        /// <summary>
        /// Test for valid user (user with null phone number).
        /// </summary>
        [Test]
        public void ValidUser_PhoneNumber_Null()
        {
            Assert.IsTrue(this.IsValidUser(this.userTestData.GetUserWithNullPhoneNumber()));
            Assert.That(this.results.Count, Is.EqualTo(0));
        }

        /// <summary>
        /// Test for invalid user (user with empty phone number).
        /// </summary>
        [Test]
        public void InvalidUser_UserValidation_PhoneNumber_Empty()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithEmptyPhoneNumber()));
            Assert.That(this.results.Count, Is.EqualTo(2));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithInvalidPhoneNumber));
            Assert.That(this.results[1].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithPhoneNumberTooLong));
        }

        /// <summary>
        /// Test for invalid user (user with phone number too long).
        /// </summary>
        [Test]
        public void InvalidUser_PhoneNumber_TooLong()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithPhoneNumberTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithPhoneNumberTooLong));
        }

        /// <summary>
        /// Test for invalid user (user with invalid phone number).
        /// </summary>
        [Test]
        public void InvalidUser_PhoneNumber_Invalid()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithInvalidPhoneNumber()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithInvalidPhoneNumber));
        }

        /// <summary>
        /// Test for invalid user (user with null email address).
        /// </summary>
        [Test]
        public void InvalidUser_Email_Null()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithNullEmail()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithNullEmail));
        }

        /// <summary>
        /// Test for invalid user (user with empty email address).
        /// </summary>
        [Test]
        public void InvalidUser_Email_Empty()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithEmptyEmail()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithNullEmail));
        }

        /// <summary>
        /// Test for invalid user (user with email address too long).
        /// </summary>
        [Test]
        public void InvalidUser_Email_TooLong()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithEmailTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithEmailTooLong));
        }

        /// <summary>
        /// Test for invalid user (user with invalid email address).
        /// </summary>
        [Test]
        public void InvalidUser_Email_Invalid()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithInvalidEmail()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithInvalidEmail));
        }

        /// <summary>
        /// Test for invalid user (user with null password).
        /// </summary>
        [Test]
        public void InvalidUser_Password_Null()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithNullPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithNullPassword));
        }

        /// <summary>
        /// Test for invalid user (user with empty password).
        /// </summary>
        [Test]
        public void InvalidUser_Password_Empty()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithEmptyPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithNullPassword));
        }

        /// <summary>
        /// Test for invalid user (user with password too short).
        /// </summary>
        [Test]
        public void InvalidUser_Password_TooShort()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithPasswordTooShort()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithPasswordTooLongOrTooShort));
        }

        /// <summary>
        /// Test for invalid user (user with password too long).
        /// </summary>
        [Test]
        public void InvalidUser_Password_TooLong()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithPasswordTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithPasswordTooLongOrTooShort));
        }

        /// <summary>
        /// Test for invalid user (user with password that doesn't contain uppercase letters).
        /// </summary>
        [Test]
        public void InvalidUser_Password_MissingUpperCaseLetter()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithNoUppercaseLetterInPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithInvalidPassword));
        }

        /// <summary>
        /// Test for invalid user (user with password that doesn't contain lowercase letters).
        /// </summary>
        [Test]
        public void InvalidUser_Password_MissingLowerCaseLetter()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithNoLowercaseLetterInPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithInvalidPassword));
        }

        /// <summary>
        /// Test for invalid user (user with password that doesn't contain numbers).
        /// </summary>
        [Test]
        public void InvalidUser_Password_MissingNumber()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithNoNumberInPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithInvalidPassword));
        }

        /// <summary>
        /// Test for invalid user (user with password that doesn't contain symbols).
        /// </summary>
        [Test]
        public void InvalidUser_Password_MissingSymbol()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithNoSymbolInPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithInvalidPassword));
        }

        /// <summary>
        /// Test for invalid user (user with unknown account type).
        /// </summary>
        [Test]
        public void InvalidUser_AccountType_Unknown()
        {
            Assert.IsFalse(this.IsValidUser(this.userTestData.GetUserWithUnknownAccountType()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogUserWithUnknownAccountType));
        }
    }
}
