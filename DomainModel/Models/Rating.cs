namespace DomainModel.Models
{
    using System.ComponentModel.DataAnnotations;
    using DomainModel.Enums;

    /// <summary>
    /// The rating class.
    /// </summary>
    public class Rating
    {
        private object value;
        private Category category;
        private int v1;
        private ECurrency eUR;
        private User user1;
        private DateTime dateTime1;
        private DateTime dateTime2;
        private User user2;
        private User user3;
        private int v2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rating"/> class.
        /// </summary>
        /// <param name="product">The product that was sold.</param>
        /// <param name="ratingUser">The user that is giving the rating.</param>
        /// <param name="ratedUser">The user that is given the rating.</param>
        /// <param name="grade">The grade given to the RatedUser by the RatingUser.</param>
        public Rating(Product product, User ratingUser, User ratedUser, int grade)
        {
            this.DateAndTime = DateTime.Now;
            this.Product = product;
            this.RatingUser = ratingUser;
            this.RatedUser = ratedUser;
            this.Grade = grade;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rating"/> class.
        /// </summary>
        public Rating()
        {
        }

        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public virtual int Id { get;  set; }

        /// <summary>Gets the date and time.</summary>
        /// <value>The date and time.</value>
        [Required(ErrorMessage = "[DateAndTime] cannot be null.")]
        public virtual DateTime DateAndTime { get; private set; }

        /// <summary>Gets the product.</summary>
        /// <value>The product.</value>
        [Required(ErrorMessage = "[Product] cannot be null.")]
        [ObjectValidation(ErrorMessage = "[Product] must be a valid product.")]
        public virtual Product Product { get; private set; }

        /// <summary>Gets the rating user.</summary>
        /// <value>The rating user.</value>
        [Required(ErrorMessage = "[RatingUser] cannot be null.")]
        [ObjectValidation(ErrorMessage = "[RatingUser] must be a valid user.")]
        public virtual User RatingUser { get; private set; }

        /// <summary>Gets the rated user.</summary>
        /// <value>The rated user.</value>
        [Required(ErrorMessage = "[RatedUser] cannot be null.")]
        [ObjectValidation(ErrorMessage = "[RatedUser] must be a valid user.")]
        public virtual User RatedUser { get; private set; }

        /// <summary>Gets or sets the grade.</summary>
        /// <value>The grade.</value>
        [Required(ErrorMessage = "[Grade] cannot be null.")]
        [Range(0, 10, ErrorMessage = "[Grade] must be between 0 and 10.")]
        public virtual int Grade { get; set; }
    }
}
