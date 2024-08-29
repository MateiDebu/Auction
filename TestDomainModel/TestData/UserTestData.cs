// <copyright file="UserTestData.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestDomainModel.TestData
{
    using System.Diagnostics.CodeAnalysis;
    using DomainModel.Enums;
    using DomainModel.Models;

    /// <summary>
    /// The UserTestData class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class UserTestData
    {
        /// <summary>
        /// The valid first name.
        /// </summary>
        private string validFirstName = "Matei";

        /// <summary>
        /// The valid last name.
        /// </summary>
        private string validLastName = "Debu";

        /// <summary>
        /// The valid username.
        /// </summary>
        private string validUsername = "MateiDebu12";

        /// <summary>
        /// The valid phone number.
        /// </summary>
        private string validPhoneNumber = "0770463123";

        /// <summary>
        /// The valid email.
        /// </summary>
        private string validEmail = "mateidebu@yahoo.com";

        /// <summary>
        /// The valid password.
        /// </summary>
        private string validPassword = "Matei&&1234";

        /// <summary>
        /// The long name.
        /// </summary>
        private string longName = 'X' + new string('x', 16);

        /// <summary>
        /// The no uppercase name.
        /// </summary>
        private string noUppercaseName = new string('x', 10);

        /// <summary>
        /// The no lowercase name.
        /// </summary>
        private string noLowercaseName = new string('X', 11);

        /// <summary>
        /// The symbol in first name.
        /// </summary>
        private string symbolInFirstName = "Mate!";

        /// <summary>
        /// The number in first name.
        /// </summary>
        private string numberInFirstName = "Mate1";

        /// <summary>
        /// The symbol in last name.
        /// </summary>
        private string symbolInLastName = "Deb!";

        /// <summary>
        /// The number in last name.
        /// </summary>
        private string numberInLastName = "Deb1";

        /// <summary>
        /// The long user name.
        /// </summary>
        private string longUserName = new string('x', 31);

        /// <summary>
        /// The long phone number.
        /// </summary>
        private string longPhoneNumber = new string('1', 16);

        /// <summary>
        /// The invalid phone number.
        /// </summary>
        private string invalidPhoneNumber = "bbb";

        /// <summary>
        /// The long email.
        /// </summary>
        private string longEmail = new string('x', 30) + '@' + new string('x', 30);

        /// <summary>
        /// The invalid email.
        /// </summary>
        private string invalidEmail = "mateidebu";

        /// <summary>
        /// The short password.
        /// </summary>
        private string shortPassword = "a!12A";

        /// <summary>
        /// The long password.
        /// </summary>
        private string longPassword = "A1!" + new string('a', 20);

        /// <summary>
        /// The no uppercase password.
        /// </summary>
        private string noUppercasePassword = "matei12344@";

        /// <summary>
        /// The no lowercase password.
        /// </summary>
        private string noLowercasePassword = "P@SSWORD1234";

        /// <summary>
        /// The no number password.
        /// </summary>
        private string noNumberPassword = "Mateidebu!";

        /// <summary>
        /// The no symbol password.
        /// </summary>
        private string noSymbolPassword = "Mateidebu1234";

        /// <summary>
        /// Gets the valid user.
        /// </summary>
        /// <returns>user.</returns>
        public User GetValidUser()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets another valid user.
        /// </summary>
        /// <returns>user.</returns>
        public User GetAnotherValidUser()
        {
            return new User("Popescu", "Vlad", "VladutP", "1234567891", "vlad.pope@hotmail.com", "VladPop123!");
        }

        /// <summary>
        /// Gets the empty user.
        /// </summary>
        /// <returns>user.</returns>
        public User GetEmptyUser()
        {
            return new User();
        }

        /// <summary>
        /// Gets the first name of the user with null.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithNullFirstName()
        {
            return new User(
                null!,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the first name of the user with empty.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithEmptyFirstName()
        {
            return new User(
                string.Empty,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the user with first name too long.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithFirstNameTooLong()
        {
            return new User(
                this.longName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the first name of the user with no uppercase letter in.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithNoUppercaseLetterInFirstName()
        {
            return new User(
                this.noUppercaseName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the first name of the user with no lowercase letter in.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithNoLowercaseLetterInFirstName()
        {
            return new User(
                this.noLowercaseName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the first name of the user with symbol in.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithSymbolInFirstName()
        {
            return new User(
                this.symbolInFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the first name of the user with number in.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithNumberInFirstName()
        {
            return new User(
                this.numberInFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the last name of the user with null.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithNullLastName()
        {
            return new User(
                this.validFirstName,
                null!,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the last name of the user with empty.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithEmptyLastName()
        {
            return new User(
                this.validFirstName,
                string.Empty,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the user with last name too long.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithLastNameTooLong()
        {
            return new User(
                this.validFirstName,
                this.longName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the last name of the user with no uppercase letter in.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithNoUppercaseLetterInLastName()
        {
            return new User(
                this.validFirstName,
                this.noUppercaseName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the last name of the user with no lowercase letter in.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithNoLowercaseLetterInLastName()
        {
            return new User(
                this.validFirstName,
                this.noLowercaseName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the last name of the user with symbol in.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithSymbolInLastName()
        {
            return new User(
                this.validFirstName,
                this.symbolInLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the last name of the user with number in.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithNumberInLastName()
        {
            return new User(
                this.validFirstName,
                this.numberInLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the name of the user with null user.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithNullUserName()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                null!,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the name of the user with empty user.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithEmptyUserName()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                string.Empty,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the user with user name too long.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithUserNameTooLong()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.longUserName,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the user with null phone number.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithNullPhoneNumber()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                null!,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the user with empty phone number.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithEmptyPhoneNumber()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                string.Empty,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the user with phone number too long.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithPhoneNumberTooLong()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.longPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the user with invalid phone number.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithInvalidPhoneNumber()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.invalidPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the user with null email.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithNullEmail()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                null!,
                this.validPassword);
        }

        /// <summary>
        /// Gets the user with empty email.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithEmptyEmail()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                string.Empty,
                this.validPassword);
        }

        /// <summary>
        /// Gets the user with email too long.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithEmailTooLong()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.longEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the user with invalid email.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithInvalidEmail()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.invalidEmail,
                this.validPassword);
        }

        /// <summary>
        /// Gets the user with null password.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithNullPassword()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                null!);
        }

        /// <summary>
        /// Gets the user with empty password.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithEmptyPassword()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                string.Empty);
        }

        /// <summary>
        /// Gets the user with password too short.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithPasswordTooShort()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.shortPassword);
        }

        /// <summary>
        /// Gets the user with password too long.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithPasswordTooLong()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.longPassword);
        }

        /// <summary>
        /// Gets the user with no uppercase letter in password.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithNoUppercaseLetterInPassword()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.noUppercasePassword);
        }

        /// <summary>
        /// Gets the user with no lowercase letter in password.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithNoLowercaseLetterInPassword()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.noLowercasePassword);
        }

        /// <summary>
        /// Gets the user with no number in password.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithNoNumberInPassword()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.noNumberPassword);
        }

        /// <summary>
        /// Gets the user with no symbol in password.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithNoSymbolInPassword()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.noSymbolPassword);
        }

        /// <summary>
        /// Gets the type of the user with unknown account.
        /// </summary>
        /// <returns>user.</returns>
        public User GetUserWithUnknownAccountType()
        {
            User user = new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);

            user.AccountType = EAccountType.Unknown;

            return user;
        }
    }
}
