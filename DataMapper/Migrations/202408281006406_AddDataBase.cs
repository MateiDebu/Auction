// <copyright file="202408281006406_AddDataBase.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace DataMapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
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
            
            CreateTable(
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
            
            CreateTable(
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
            
            CreateTable(
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
            
            CreateTable(
                "dbo.Conditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                        Description = c.String(nullable: false, maxLength: 100),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
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
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "RatingUser_Id", "dbo.Users");
            DropForeignKey("dbo.Ratings", "RatedUser_Id", "dbo.Users");
            DropForeignKey("dbo.Ratings", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Bids", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Seller_Id", "dbo.Users");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentCategory_Id", "dbo.Categories");
            DropForeignKey("dbo.Bids", "Buyer_Id", "dbo.Users");
            DropIndex("dbo.Ratings", new[] { "RatingUser_Id" });
            DropIndex("dbo.Ratings", new[] { "RatedUser_Id" });
            DropIndex("dbo.Ratings", new[] { "Product_Id" });
            DropIndex("dbo.Categories", new[] { "ParentCategory_Id" });
            DropIndex("dbo.Products", new[] { "Seller_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Bids", new[] { "Product_Id" });
            DropIndex("dbo.Bids", new[] { "Buyer_Id" });
            DropTable("dbo.Ratings");
            DropTable("dbo.Conditions");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Users");
            DropTable("dbo.Bids");
        }
    }
}
