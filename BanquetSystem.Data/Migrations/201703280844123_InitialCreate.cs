namespace BanquetSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(),
                        CityName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerTypeId = c.Int(),
                        UserId = c.String(maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 75),
                        Phone = c.String(nullable: false, maxLength: 25),
                        Mobile = c.String(nullable: false, maxLength: 25),
                        AddressLine1 = c.String(maxLength: 50),
                        AddressLine2 = c.String(maxLength: 50),
                        AddressLine3 = c.String(maxLength: 50),
                        PostCode = c.String(maxLength: 50),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.CustomerType", t => t.CustomerTypeId)
                .Index(t => t.CustomerTypeId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.CustomerEventDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        EventId = c.Int(nullable: false),
                        CostPerHead = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        Image = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.CustomerType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Theme",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThemeName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "CustomerTypeId", "dbo.CustomerType");
            DropForeignKey("dbo.CustomerImage", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.CustomerEventDetail", "EventId", "dbo.Event");
            DropForeignKey("dbo.CustomerEventDetail", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Customer", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Customer", "CityId", "dbo.City");
            DropForeignKey("dbo.City", "CountryId", "dbo.Country");
            DropIndex("dbo.CustomerImage", new[] { "CustomerId" });
            DropIndex("dbo.CustomerEventDetail", new[] { "EventId" });
            DropIndex("dbo.CustomerEventDetail", new[] { "CustomerId" });
            DropIndex("dbo.Customer", new[] { "CityId" });
            DropIndex("dbo.Customer", new[] { "CountryId" });
            DropIndex("dbo.Customer", new[] { "CustomerTypeId" });
            DropIndex("dbo.City", new[] { "CountryId" });
            DropTable("dbo.Theme");
            DropTable("dbo.CustomerType");
            DropTable("dbo.CustomerImage");
            DropTable("dbo.Event");
            DropTable("dbo.CustomerEventDetail");
            DropTable("dbo.Customer");
            DropTable("dbo.Country");
            DropTable("dbo.City");
        }
    }
}
