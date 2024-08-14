using DomainModel.Enums;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomainModel.TestData
{
    [ExcludeFromCodeCoverage]
    internal class UserTestData
    {
        private string validFirstName = "Matei";
        private string validLastName = "Debu";
        private string validUsername = "MateiDebu12";
        private string validPhoneNumber = "0770463123";
        private string validEmail = "mateidebu@yahoo.com";
        private string validPassword = "Matei&&1234";
        private string longName = 'X' + new string('x', 16);
        private string noUppercaseName = new string('x', 10);
        private string noLowercaseName = new string('X', 11);
        private string symbolInFirstName = "Mate!";
        private string numberInFirstName = "Mate1";
        private string symbolInLastName = "Deb!";
        private string numberInLastName = "Deb1";
        private string longUserName = new string('x', 31);
        private string longPhoneNumber = new string('1', 16);
        private string invalidPhoneNumber = "bbb";
        private string longEmail = new string('x', 30) + '@' + new string('x', 30);
        private string invalidEmail = "mateidebu";
        private string shortPassword = "a!12A";
        private string longPassword = "A1!" + new string('a', 20);
        private string noUppercasePassword = "matei12344@";
        private string noLowercasePassword = "P@SSWORD1234";
        private string noNumberPassword = "Mateidebu!";
        private string noSymbolPassword = "Mateidebu1234";

        public User GetValidUser()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword
                );
        }

        public User GetAnotherValidUser()
        {
            return new User("Popescu", "Vlad", "VladutP", "1234567891", "vlad.pope@hotmail.com", "VladPop123!");
        }

        public User GetEmptyUser()
        {
            return new User();
        }

        public User GetUserWithNullFirstName()
        {
            return new User(
                null,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

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

        public User GetUserWithNullLastName()
        {
            return new User(
                this.validFirstName,
                null,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

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

        public User GetUserWithNullUserName()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                null,
                this.validPhoneNumber,
                this.validEmail,
                this.validPassword);
        }

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

        public User GetUserWithNullPhoneNumber()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                null,
                this.validEmail,
                this.validPassword);
        }

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

        public User GetUserWithNullEmail()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                null,
                this.validPassword);
        }

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

        public User GetUserWithNullPassword()
        {
            return new User(
                this.validFirstName,
                this.validLastName,
                this.validUsername,
                this.validPhoneNumber,
                this.validEmail,
                null);
        }

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
