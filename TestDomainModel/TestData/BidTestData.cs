using DomainModel.Enums;
using DomainModel.Models;
using System.Diagnostics.CodeAnalysis;

namespace TestDomainModel.TestData
{
    /// <summary>
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class BidTestData
    {
        /// <summary>
        /// The product test data
        /// </summary>
        private ProductTestData productTestData = new ProductTestData();
        /// <summary>
        /// The user test data
        /// </summary>
        private UserTestData userTestData = new UserTestData();
        /// <summary>
        /// The valid amount
        /// </summary>
        private decimal validAmount = 1000m;
        /// <summary>
        /// The valid currency
        /// </summary>
        private ECurrency validCurrency = ECurrency.EUR;

        /// <summary>
        /// Gets the valid bid.
        /// </summary>
        /// <returns></returns>
        public Bid GetValidBid()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the empty bid.
        /// </summary>
        /// <returns></returns>
        public Bid GetEmptyBid()
        {
            return new Bid();
        }

        /// <summary>
        /// Gets the bid with null product.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNullProduct()
        {
            return new Bid(
                null,
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the name of the bid with null product.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNullProductName()
        {
            return new Bid(
                this.productTestData.GetProductWithNullName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the name of the bid with empty product.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithEmptyProductName()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptyName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with product name too long.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithProductNameTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithNameTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with null product description.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNullProductDescription()
        {
            return new Bid(
                this.productTestData.GetProductWithNullDescription(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with empty product description.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithEmptyProductDescription()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptyDescription(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with product description too long.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithProductDescriptionTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithDescriptionTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with null product category.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNullProductCategory()
        {
            return new Bid(
                this.productTestData.GetProductWithNullCategory(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the name of the bid with null product category.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNullProductCategoryName()
        {
            return new Bid(
                this.productTestData.GetProductWithNullCategoryName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the name of the bid with empty product category.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithEmptyProductCategoryName()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptyCategoryName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with product category name too long.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithProductCategoryNameTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithCategoryNameTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with negative product starting price.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNegativeProductStartingPrice()
        {
            return new Bid(
                this.productTestData.GetProductWithNegativeStartingPrice(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with null product seller.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNullProductSeller()
        {
            return new Bid(
                this.productTestData.GetProductWithNullSeller(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the first name of the bid with null product seller.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNullProductSellerFirstName()
        {
            return new Bid(
                this.productTestData.GetProductWithNullSellerFirstName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the first name of the bid with empty product seller.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithEmptyProductSellerFirstName()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptySellerFirstName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with product seller first name too long.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithProductSellerFirstNameTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithSellerFirstNameTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the first name of the bid with no uppercase in product seller.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNoUppercaseInProductSellerFirstName()
        {
            return new Bid(
                this.productTestData.GetProductWithNoUppercaseLetterInSellerFirstName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the first name of the bid with no lowercase in product seller.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNoLowercaseInProductSellerFirstName()
        {
            return new Bid(
                this.productTestData.GetProductWithNoLowercaseLetterInSellerFirstName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the first name of the bid with symbol in product seller.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithSymbolInProductSellerFirstName()
        {
            return new Bid(
                this.productTestData.GetProductWithSymbolInSellerFirstName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the first name of the bid with number in product seller.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNumberInProductSellerFirstName()
        {
            return new Bid(
                this.productTestData.GetProductWithNumberInSellerFirstName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the last name of the bid with null product seller.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNullProductSellerLastName()
        {
            return new Bid(
                this.productTestData.GetProductWithNullSellerLastName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the last name of the bid with empty product seller.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithEmptyProductSellerLastName()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptySellerLastName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with product seller last name too long.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithProductSellerLastNameTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithSellerLastNameTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the last name of the bid with no uppercase letter in product seller.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNoUppercaseLetterInProductSellerLastName()
        {
            return new Bid(
                this.productTestData.GetProductWithNoUppercaseLetterInSellerLastName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the last name of the bid with no lowercase letter in product seller.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNoLowercaseLetterInProductSellerLastName()
        {
            return new Bid(
                this.productTestData.GetProductWithNoLowercaseLetterInSellerLastName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the last name of the bid with symbol in product seller.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithSymbolInProductSellerLastName()
        {
            return new Bid(
                this.productTestData.GetProductWithSymbolInSellerLastName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the last name of the bid with number in product seller.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNumberInProductSellerLastName()
        {
            return new Bid(
                this.productTestData.GetProductWithNumberInSellerLastName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the name of the bid with null product seller user.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNullProductSellerUserName()
        {
            return new Bid(
                this.productTestData.GetProductWithNullSellerUserName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the name of the bid with empty product seller user.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithEmptyProductSellerUserName()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptySellerUserName(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with product seller user name too long.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithProductSellerUserNameTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithSellerUserNameTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with null product seller phone number.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNullProductSellerPhoneNumber()
        {
            return new Bid(
                this.productTestData.GetProductWithNullSellerPhoneNumber(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with empty product seller phone number.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithEmptyProductSellerPhoneNumber()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptySellerPhoneNumber(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with product seller phone number too long.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithProductSellerPhoneNumberTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithSellerPhoneNumberTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with invalid product seller phone number.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithInvalidProductSellerPhoneNumber()
        {
            return new Bid(
                this.productTestData.GetProductWithInvalidSellerPhoneNumber(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with null product seller email.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNullProductSellerEmail()
        {
            return new Bid(
                this.productTestData.GetProductWithNullSellerEmail(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with empty product seller email.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithEmptyProductSellerEmail()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptySellerEmail(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with product seller email too long.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithProductSellerEmailTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithSellerEmailTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with invalid product seller email.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithInvalidProductSellerEmail()
        {
            return new Bid(
                this.productTestData.GetProductWithInvalidSellerEmail(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with null product seller password.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNullProductSellerPassword()
        {
            return new Bid(
                this.productTestData.GetProductWithNullSellerPassword(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with empty product seller password.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithEmptyProductSellerPassword()
        {
            return new Bid(
                this.productTestData.GetProductWithEmptySellerPassword(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with product seller password too short.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithProductSellerPasswordTooShort()
        {
            return new Bid(
                this.productTestData.GetProductWithSellerPasswordTooShort(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with product seller password too long.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithProductSellerPasswordTooLong()
        {
            return new Bid(
                this.productTestData.GetProductWithSellerPasswordTooLong(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with no uppercase letter in product seller password.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNoUppercaseLetterInProductSellerPassword()
        {
            return new Bid(
                this.productTestData.GetProductWithNoUppercaseLetterInSellerPassword(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with no lowercase letter in product seller password.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNoLowercaseLetterInProductSellerPassword()
        {
            return new Bid(
                this.productTestData.GetProductWithNoLowercaseLetterInSellerPassword(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with no number in product seller password.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNoNumberInProductSellerPassword()
        {
            return new Bid(
                this.productTestData.GetProductWithNoNumberInSellerPassword(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with no symbol in product seller password.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNoSymbolInProductSellerPassword()
        {
            return new Bid(
                this.productTestData.GetProductWithNoSymbolInSellerPassword(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with end date before start date.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithEndDateBeforeStartDate()
        {
            return new Bid(
                this.productTestData.GetProductWithEndDateBeforeStartDate(),
                this.userTestData.GetAnotherValidUser(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with null buyer.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNullBuyer()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                null,
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the first name of the bid with null buyer.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNullBuyerFirstName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNullFirstName(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the first name of the bid with empty buyer.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithEmptyBuyerFirstName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithEmptyFirstName(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with buyer first name too long.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithBuyerFirstNameTooLong()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithFirstNameTooLong(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the first name of the bid with no uppercase letter in buyer.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNoUppercaseLetterInBuyerFirstName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNoUppercaseLetterInFirstName(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the first name of the bid with no lowercase letter in buyer.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNoLowercaseLetterInBuyerFirstName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNoLowercaseLetterInFirstName(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the first name of the bid with symbol in buyer.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithSymbolInBuyerFirstName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithSymbolInFirstName(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the first name of the bid with number in buyer.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNumberInBuyerFirstName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNumberInFirstName(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the last name of the bid with null buyer.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNullBuyerLastName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNullLastName(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the last name of the bid with empty buyer.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithEmptyBuyerLastName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithEmptyLastName(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the bid with buyer last name too long.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithBuyerLastNameTooLong()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithLastNameTooLong(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the last name of the bid with no uppercase letter in buyer.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNoUppercaseLetterInBuyerLastName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNoUppercaseLetterInLastName(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the last name of the bid with no lowercase letter in buyer.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNoLowercaseLetterInBuyerLastName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNoLowercaseLetterInLastName(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the last name of the bid with symbol in buyer.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithSymbolInBuyerLastName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithSymbolInLastName(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the last name of the bid with number in buyer.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNumberInBuyerLastName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNumberInLastName(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the name of the bid with null buyer user.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithNullBuyerUserName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithNullUserName(),
                this.validAmount,
                this.validCurrency);
        }

        /// <summary>
        /// Gets the name of the bid with empty buyer user.
        /// </summary>
        /// <returns></returns>
        public Bid GetBidWithEmptyBuyerUserName()
        {
            return new Bid(
                this.productTestData.GetValidProduct(),
                this.userTestData.GetUserWithEmptyUserName(),
                this.validAmount,
                this.validCurrency);
        }
    }
}
