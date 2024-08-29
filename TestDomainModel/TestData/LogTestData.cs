// <copyright file="LogTestData.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestDomainModel.TestData
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The LogTestData.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class LogTestData
    {
        // BID

        /// <summary>
        /// Null product log message.
        /// </summary>
        internal const string LogBidWithNullProduct = "[Product] cannot be null.";

        /// <summary>
        /// Invalid product log message.
        /// </summary>
        internal const string LogBidWithInvalidProduct = "[Product] must be a valid product.";

        /// <summary>
        /// Null buyer log message.
        /// </summary>
        internal const string LogBidWithNullBuyer = "[Buyer] cannot be null.";

        /// <summary>
        /// Invalid buyer log message.
        /// </summary>
        internal const string LogBidWithInvalidBuyer = "[Buyer] must be a valid user.";

        /// <summary>
        /// Negative amount log message.
        /// </summary>
        internal const string LogBidWithNegativeAmount = "[Amount] must be greater than zero.";

        // CATEGORY

        /// <summary>
        /// Null name log message.
        /// </summary>
        internal const string LogCategoryWithNullName = "[Name] cannot be null.";

        /// <summary>
        /// Too long name log message.
        /// </summary>
        internal const string LogCategoryWithNameTooLong = "[Name] must be between 1 and 100 characters.";

        // CONDITION

        /// <summary>
        /// Null name log message.
        /// </summary>
        internal const string LogConditionWithNullName = "[Name] cannot be null.";

        /// <summary>
        /// Too long name log message.
        /// </summary>
        internal const string LogConditionWithNameTooLong = "[Name] must be between 1 and 15 characters.";

        /// <summary>
        /// Null description log message.
        /// </summary>
        internal const string LogConditionWithNullDescription = "[Description] cannot be null.";

        /// <summary>
        /// Too long description log message.
        /// </summary>
        internal const string LogConditionWithDescriptionTooLong = "[Description] must be between 1 and 100 characters.";

        // PRODUCT

        /// <summary>
        /// Null name log message.
        /// </summary>
        internal const string LogProductWithNullName = "[Name] cannot be null.";

        /// <summary>
        /// Too long name log message.
        /// </summary>
        internal const string LogProductWithNameTooLong = "[Name] must be between 1 and 250 characters.";

        /// <summary>
        /// Null description log message.
        /// </summary>
        internal const string LogProductWithNullDescription = "[Description] cannot be null.";

        /// <summary>
        /// Too long description log message.
        /// </summary>
        internal const string LogProductWithDescriptionTooLong = "[Description] must be between 1 and 500 characters.";

        /// <summary>
        /// Null category log message.
        /// </summary>
        internal const string LogProductWithNullCategory = "[Category] cannot be null.";

        /// <summary>
        /// Invalid category log message.
        /// </summary>
        internal const string LogProductWithInvalidCategory = "[Category] must be a valid category.";

        /// <summary>
        /// Null seller log message.
        /// </summary>
        internal const string LogProductWithNullSeller = "[Seller] cannot be null.";

        /// <summary>
        /// Invalid seller log message.
        /// </summary>
        internal const string LogProductWithInvalidSeller = "[Seller] must be a valid user.";

        /// <summary>
        /// End date before start date log message.
        /// </summary>
        internal const string LogProductWithEndDateBeforeStartDate = "[EndDate] cannot be before [StartDate].";

        /// <summary>
        /// Negative starting price log message.
        /// </summary>
        internal const string LogProductWithNegativeStartingPrice = "[StartingPrice] cannot be negative.";

        // RATING

        /// <summary>
        /// Null product log message.
        /// </summary>
        internal const string LogRatingWithNullProduct = "[Product] cannot be null.";

        /// <summary>
        /// Invalid product log message.
        /// </summary>
        internal const string LogRatingWithInvalidProduct = "[Product] must be a valid product.";

        /// <summary>
        /// Null rating user log message.
        /// </summary>
        internal const string LogRatingWithNullRatingUser = "[RatingUser] cannot be null.";

        /// <summary>
        /// Invalid rating user log message.
        /// </summary>
        internal const string LogRatingWithInvalidRatingUser = "[RatingUser] must be a valid user.";

        /// <summary>
        /// Null rated user log message.
        /// </summary>
        internal const string LogRatingWithNullRatedUser = "[RatedUser] cannot be null.";

        /// <summary>
        /// Invalid rated user log message.
        /// </summary>
        internal const string LogRatingWithInvalidRatedUser = "[RatedUser] must be a valid user.";

        /// <summary>
        /// Invalid grade log message.
        /// </summary>
        internal const string LogRatingWithInvalidGrade = "[Grade] must be between 0 and 10.";

        /// <summary>
        /// The log rating with null grade.
        /// </summary>
        internal const string LogRatingWithNullGrade = "[Grade] cannot be null.";

        // USER

        /// <summary>
        /// Null first name log message.
        /// </summary>
        internal const string LogUserWithNullFirstName = "[FirstName] cannot be null.";

        /// <summary>
        /// Too long first name log message.
        /// </summary>
        internal const string LogUserWithFirstNameTooLong = "[FirstName] must be between 1 and 15 characters.";

        /// <summary>
        /// Invalid first name log message.
        /// </summary>
        internal const string LogUserWithInvalidFirstName = "[FirstName] must be a valid firstname.";

        /// <summary>
        /// Null last name log message.
        /// </summary>
        internal const string LogUserWithNullLastName = "[LastName] cannot be null.";

        /// <summary>
        /// Invalid last name log message.
        /// </summary>
        internal const string LogUserWithInvalidLastName = "[LastName] must be a valid lastname.";

        /// <summary>
        /// Too long last name log message.
        /// </summary>
        internal const string LogUserWithLastNameTooLong = "[LastName] must be between 1 and 15 characters.";

        /// <summary>
        /// Null username log message.
        /// </summary>
        internal const string LogUserWithNullUserName = "[UserName] cannot be null.";

        /// <summary>
        /// Too long username log message.
        /// </summary>
        internal const string LogUserWithUserNameTooLong = "[UserName] must be between 1 and 30 characters.";

        /// <summary>
        /// Too long phone number log message.
        /// </summary>
        internal const string LogUserWithPhoneNumberTooLong = "[PhoneNumber] must have between 1 and 15 digits.";

        /// <summary>
        /// Invalid phone number log message.
        /// </summary>
        internal const string LogUserWithInvalidPhoneNumber = "[PhoneNumber] is not a valid phone number.";

        /// <summary>
        /// Null email log message.
        /// </summary>
        internal const string LogUserWithNullEmail = "[Email] cannot be null.";

        /// <summary>
        /// Too long email log message.
        /// </summary>
        internal const string LogUserWithEmailTooLong = "[Email] must have between 5 and 50 digits.";

        /// <summary>
        /// Invalid email log message.
        /// </summary>
        internal const string LogUserWithInvalidEmail = "[Email] is not a valid email address.";

        /// <summary>
        /// Null password log message.
        /// </summary>
        internal const string LogUserWithNullPassword = "[Password] cannot be null.";

        /// <summary>
        /// Too short or too long password log message.
        /// </summary>
        internal const string LogUserWithPasswordTooLongOrTooShort = "[Password] must be between 8 and 20 characters.";

        /// <summary>
        /// Invalid password log message.
        /// </summary>
        internal const string LogUserWithInvalidPassword = "[Password] must contain at least one number, one uppercase letter, one lowercase letter and one symbol.";

        /// <summary>
        /// Unknown account type log message.
        /// </summary>
        internal const string LogUserWithUnknownAccountType = "[AccountType] must be specified.";
    }
}
