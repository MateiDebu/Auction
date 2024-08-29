// <copyright file="202408281006406_AddDataBase.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace DataMapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// The AddBataBase class.
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class AddDataBase : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            this.CreateTable(
                "dbo.Bids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAndTime = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                        Buyer_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Buyer_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Buyer_Id)
                .Index(t => t.Product_Id);
            this.CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 15),
                        UserName = c.String(nullable: false, maxLength: 30),
                        PhoneNumber = c.String(maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 20),
                        AccountType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            this.CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(nullable: false, maxLength: 500),
                        StartingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TerminationDate = c.DateTime(nullable: false),
                        Category_Id = c.Int(nullable: false),
                        Seller_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Seller_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Seller_Id);
            this.CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ParentCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentCategory_Id)
                .Index(t => t.ParentCategory_Id);
            this.CreateTable(
                "dbo.Conditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                        Description = c.String(nullable: false, maxLength: 100),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            this.CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAndTime = c.DateTime(nullable: false),
                        Grade = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        RatedUser_Id = c.Int(nullable: false),
                        RatingUser_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.RatedUser_Id)
                .ForeignKey("dbo.Users", t => t.RatingUser_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.RatedUser_Id)
                .Index(t => t.RatingUser_Id);
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("dbo.Ratings", "RatingUser_Id", "dbo.Users");
            this.DropForeignKey("dbo.Ratings", "RatedUser_Id", "dbo.Users");
            this.DropForeignKey("dbo.Ratings", "Product_Id", "dbo.Products");
            this.DropForeignKey("dbo.Bids", "Product_Id", "dbo.Products");
            this.DropForeignKey("dbo.Products", "Seller_Id", "dbo.Users");
            this.DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            this.DropForeignKey("dbo.Categories", "ParentCategory_Id", "dbo.Categories");
            this.DropForeignKey("dbo.Bids", "Buyer_Id", "dbo.Users");
            this.DropIndex("dbo.Ratings", new[] { "RatingUser_Id" });
            this.DropIndex("dbo.Ratings", new[] { "RatedUser_Id" });
            this.DropIndex("dbo.Ratings", new[] { "Product_Id" });
            this.DropIndex("dbo.Categories", new[] { "ParentCategory_Id" });
            this.DropIndex("dbo.Products", new[] { "Seller_Id" });
            this.DropIndex("dbo.Products", new[] { "Category_Id" });
            this.DropIndex("dbo.Bids", new[] { "Product_Id" });
            this.DropIndex("dbo.Bids", new[] { "Buyer_Id" });
            this.DropTable("dbo.Ratings");
            this.DropTable("dbo.Conditions");
            this.DropTable("dbo.Categories");
            this.DropTable("dbo.Products");
            this.DropTable("dbo.Users");
            this.DropTable("dbo.Bids");
        }
    }
}
