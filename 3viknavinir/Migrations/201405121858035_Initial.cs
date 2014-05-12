namespace _3viknavinir.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        posterPath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Discussion",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        comment = c.String(),
                        dateAdded = c.DateTime(nullable: false),
                        userID = c.String(),
                        mediaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Upvote",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userID = c.String(),
                        translationID = c.Int(),
                        requestID = c.Int(),
                        discussionID = c.Int(),
                        Requests_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Discussion", t => t.discussionID)
                .ForeignKey("dbo.Requests", t => t.Requests_ID)
                .ForeignKey("dbo.Translation", t => t.translationID)
                .Index(t => t.translationID)
                .Index(t => t.discussionID)
                .Index(t => t.Requests_ID);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        dateOfRequest = c.DateTime(nullable: false),
                        title = c.String(),
                        yearOfRelease = c.Int(nullable: false),
                        imdbID = c.String(),
                        userID = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Translation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        finished = c.Boolean(nullable: false),
                        mediaID = c.Int(nullable: false),
                        languageID = c.Int(nullable: false),
                        userID = c.String(),
                        dateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Language", t => t.languageID)
                .ForeignKey("dbo.Media", t => t.mediaID, cascadeDelete: true)
                .Index(t => t.mediaID)
                .Index(t => t.languageID);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        yearOfRelease = c.Int(nullable: false),
                        description = c.String(),
                        posterPath = c.String(),
                        imdbID = c.String(),
                        categoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.categoryID, cascadeDelete: true)
                .Index(t => t.categoryID);
            
            CreateTable(
                "dbo.TranslationLines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        chapterNumber = c.Int(nullable: false),
                        startTime = c.String(),
                        endTime = c.String(),
                        subtitle = c.String(),
                        isEditing = c.Boolean(nullable: false),
                        dateOfSubmission = c.DateTime(nullable: false),
                        translationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Translation", t => t.translationID)
                .Index(t => t.translationID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Upvote", "translationID", "dbo.Translation");
            DropForeignKey("dbo.TranslationLines", "translationID", "dbo.Translation");
            DropForeignKey("dbo.Translation", "mediaID", "dbo.Media");
            DropForeignKey("dbo.Media", "categoryID", "dbo.Category");
            DropForeignKey("dbo.Translation", "languageID", "dbo.Language");
            DropForeignKey("dbo.Upvote", "Requests_ID", "dbo.Requests");
            DropForeignKey("dbo.Upvote", "discussionID", "dbo.Discussion");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.TranslationLines", new[] { "translationID" });
            DropIndex("dbo.Media", new[] { "categoryID" });
            DropIndex("dbo.Translation", new[] { "languageID" });
            DropIndex("dbo.Translation", new[] { "mediaID" });
            DropIndex("dbo.Upvote", new[] { "Requests_ID" });
            DropIndex("dbo.Upvote", new[] { "discussionID" });
            DropIndex("dbo.Upvote", new[] { "translationID" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TranslationLines");
            DropTable("dbo.Media");
            DropTable("dbo.Language");
            DropTable("dbo.Translation");
            DropTable("dbo.Requests");
            DropTable("dbo.Upvote");
            DropTable("dbo.Discussion");
            DropTable("dbo.Category");
        }
    }
}
