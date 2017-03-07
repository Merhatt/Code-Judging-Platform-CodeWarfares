namespace CodeWarfares.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Problems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 1000),
                        Description = c.String(),
                        MaxMemory = c.Long(nullable: false),
                        MaxTime = c.Double(nullable: false),
                        TestsCount = c.Int(nullable: false),
                        Xp = c.Int(nullable: false),
                        CoverImageUrl = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        Difficulty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Submitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LaungageId = c.Int(nullable: false),
                        Finished = c.Boolean(nullable: false),
                        Code = c.String(),
                        CanCompile = c.Boolean(nullable: false),
                        CompileMessage = c.String(),
                        SubmitionTime = c.DateTime(nullable: false),
                        ProblemId = c.Int(nullable: false),
                        AuthorId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Problems", t => t.ProblemId, cascadeDelete: true)
                .Index(t => t.ProblemId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TestCompleteds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Result = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        Time = c.Double(nullable: false),
                        Compiled = c.Boolean(nullable: false),
                        Memory = c.Long(nullable: false),
                        SendId = c.String(),
                        SubmitionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Submitions", t => t.SubmitionId, cascadeDelete: true)
                .Index(t => t.SubmitionId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestParameter = c.String(),
                        ResultId = c.String(),
                        CorrectAnswer = c.String(),
                        ProblemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Problems", t => t.ProblemId, cascadeDelete: true)
                .Index(t => t.ProblemId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserProblems",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Problem_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Problem_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Problems", t => t.Problem_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Problem_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Tests", "ProblemId", "dbo.Problems");
            DropForeignKey("dbo.Submitions", "ProblemId", "dbo.Problems");
            DropForeignKey("dbo.TestCompleteds", "SubmitionId", "dbo.Submitions");
            DropForeignKey("dbo.Submitions", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserProblems", "Problem_Id", "dbo.Problems");
            DropForeignKey("dbo.UserProblems", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserProblems", new[] { "Problem_Id" });
            DropIndex("dbo.UserProblems", new[] { "User_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Tests", new[] { "ProblemId" });
            DropIndex("dbo.TestCompleteds", new[] { "SubmitionId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Submitions", new[] { "AuthorId" });
            DropIndex("dbo.Submitions", new[] { "ProblemId" });
            DropIndex("dbo.Problems", new[] { "Name" });
            DropTable("dbo.UserProblems");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tests");
            DropTable("dbo.TestCompleteds");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Submitions");
            DropTable("dbo.Problems");
        }
    }
}
