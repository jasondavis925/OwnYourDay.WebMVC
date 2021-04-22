namespace OwnYourDay.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class indexViews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AirCraft",
                c => new
                    {
                        AirCraftId = c.Int(nullable: false, identity: true),
                        ProspectId = c.Int(),
                        OwnerId = c.Guid(nullable: false),
                        OccupancyCount = c.Int(nullable: false),
                        VehicleMake = c.String(nullable: false),
                        VehicleModel = c.String(nullable: false),
                        Pilot = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AirCraftId)
                .ForeignKey("dbo.Person", t => t.ProspectId)
                .Index(t => t.ProspectId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        AdultCount = c.Int(nullable: false),
                        ChildCount = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Destination = c.String(nullable: false),
                        TravelMode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Land",
                c => new
                    {
                        LandId = c.Int(nullable: false, identity: true),
                        ProspectId = c.Int(),
                        OwnerId = c.Guid(nullable: false),
                        PropertyDescription = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        Occupancy = c.String(nullable: false),
                        Activities = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LandId)
                .ForeignKey("dbo.Person", t => t.ProspectId)
                .Index(t => t.ProspectId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.WaterCraft",
                c => new
                    {
                        WaterCraftId = c.Int(nullable: false, identity: true),
                        ProspectId = c.Int(),
                        OwnerId = c.Guid(nullable: false),
                        OccupancyCount = c.Int(nullable: false),
                        VehicleMake = c.String(nullable: false),
                        VehicleModel = c.String(nullable: false),
                        Captain = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.WaterCraftId)
                .ForeignKey("dbo.Person", t => t.ProspectId)
                .Index(t => t.ProspectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WaterCraft", "ProspectId", "dbo.Person");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Land", "ProspectId", "dbo.Person");
            DropForeignKey("dbo.AirCraft", "ProspectId", "dbo.Person");
            DropIndex("dbo.WaterCraft", new[] { "ProspectId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Land", new[] { "ProspectId" });
            DropIndex("dbo.AirCraft", new[] { "ProspectId" });
            DropTable("dbo.WaterCraft");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Land");
            DropTable("dbo.Person");
            DropTable("dbo.AirCraft");
        }
    }
}
