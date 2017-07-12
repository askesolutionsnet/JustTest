namespace BanquetSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerEvent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        EventId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.Event", t => t.EventId)
                .Index(t => t.CustomerId)
                .Index(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerEvent", "EventId", "dbo.Event");
            DropForeignKey("dbo.CustomerEvent", "CustomerId", "dbo.Customer");
            DropIndex("dbo.CustomerEvent", new[] { "EventId" });
            DropIndex("dbo.CustomerEvent", new[] { "CustomerId" });
            DropTable("dbo.CustomerEvent");
        }
    }
}
