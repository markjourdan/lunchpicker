namespace LunchPicker.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clique",
                c => new
                    {
                        CliqueId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        FriendlyKey = c.Guid(nullable: false),
                        LastUpdatedBy = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        LastUpdatedDateUtc = c.DateTime(nullable: false),
                        CreatedDateUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CliqueId);
            
            CreateTable(
                "dbo.Restaurant",
                c => new
                    {
                        RestaurantId = c.Long(nullable: false, identity: true),
                        CliqueId = c.Long(nullable: false),
                        Name = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        StateId = c.Int(),
                        Zip = c.String(),
                        Phone = c.String(),
                        LastUpdatedBy = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        LastUpdatedDateUtc = c.DateTime(nullable: false),
                        CreatedDateUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantId)
                .ForeignKey("dbo.States", t => t.StateId)
                .ForeignKey("dbo.Clique", t => t.CliqueId, cascadeDelete: true)
                .Index(t => t.StateId)
                .Index(t => t.CliqueId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Abreviation = c.String(),
                        LastUpdatedBy = c.String(),
                        CreatedBy = c.String(),
                        LastUpdatedDateUtc = c.DateTime(nullable: false),
                        CreatedDateUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.RestaurantRatings",
                c => new
                    {
                        RestaurantRatingId = c.Long(nullable: false, identity: true),
                        RestaurantId = c.Long(nullable: false),
                        RatingId = c.Long(nullable: false),
                        LastUpdatedBy = c.String(),
                        CreatedBy = c.String(),
                        LastUpdatedDateUtc = c.DateTime(nullable: false),
                        CreatedDateUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantRatingId)
                .ForeignKey("dbo.Ratings", t => t.RatingId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RatingId)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Long(nullable: false, identity: true),
                        Description = c.Int(nullable: false),
                        Message = c.String(),
                        UserId = c.Guid(),
                        LastUpdatedBy = c.String(),
                        CreatedBy = c.String(),
                        LastUpdatedDateUtc = c.DateTime(nullable: false),
                        CreatedDateUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        LastUpdatedBy = c.String(),
                        CreatedBy = c.String(),
                        LastUpdatedDateUtc = c.DateTime(nullable: false),
                        CreatedDateUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        ISOCode = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        Name = c.String(),
                        LastUpdatedBy = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        LastUpdatedDateUtc = c.DateTime(nullable: false),
                        CreatedDateUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "dbo.UserCliques",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Clique_CliqueId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Clique_CliqueId })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Clique", t => t.Clique_CliqueId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Clique_CliqueId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserCliques", new[] { "Clique_CliqueId" });
            DropIndex("dbo.UserCliques", new[] { "User_UserId" });
            DropIndex("dbo.RestaurantRatings", new[] { "RestaurantId" });
            DropIndex("dbo.RestaurantRatings", new[] { "RatingId" });
            DropIndex("dbo.Restaurant", new[] { "CliqueId" });
            DropIndex("dbo.Restaurant", new[] { "StateId" });
            DropForeignKey("dbo.UserCliques", "Clique_CliqueId", "dbo.Clique");
            DropForeignKey("dbo.UserCliques", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.RestaurantRatings", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.RestaurantRatings", "RatingId", "dbo.Ratings");
            DropForeignKey("dbo.Restaurant", "CliqueId", "dbo.Clique");
            DropForeignKey("dbo.Restaurant", "StateId", "dbo.States");
            DropTable("dbo.UserCliques");
            DropTable("dbo.Language");
            DropTable("dbo.Users");
            DropTable("dbo.Ratings");
            DropTable("dbo.RestaurantRatings");
            DropTable("dbo.States");
            DropTable("dbo.Restaurant");
            DropTable("dbo.Clique");
        }
    }
}
