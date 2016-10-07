namespace NoobApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        AttendanceStartDateTime = c.DateTime(nullable: false),
                        AttendanceEndDateTime = c.DateTime(nullable: false),
                        AttendanceAttendanceTypeRef_AttendanceTypeId = c.Int(),
                        AttendanceEventRef_EventId = c.Int(),
                        AttendanceUserRef_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.AttendanceTypes", t => t.AttendanceAttendanceTypeRef_AttendanceTypeId)
                .ForeignKey("dbo.Events", t => t.AttendanceEventRef_EventId)
                .ForeignKey("dbo.Users", t => t.AttendanceUserRef_UserId)
                .Index(t => t.AttendanceAttendanceTypeRef_AttendanceTypeId)
                .Index(t => t.AttendanceEventRef_EventId)
                .Index(t => t.AttendanceUserRef_UserId);
            
            CreateTable(
                "dbo.AttendanceTypes",
                c => new
                    {
                        AttendanceTypeId = c.Int(nullable: false, identity: true),
                        AttendanceTypeName = c.String(),
                    })
                .PrimaryKey(t => t.AttendanceTypeId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        EventStartDate = c.DateTime(nullable: false),
                        EventEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserFirstName = c.String(),
                        UserLastName = c.String(),
                        UserDisplayName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.EventInventories",
                c => new
                    {
                        EventInventoryId = c.Int(nullable: false, identity: true),
                        EventInventoryPrice = c.Single(nullable: false),
                        EventIntenvotryItemRef_ItemId = c.Int(),
                        EventInventoryEventRef_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.EventInventoryId)
                .ForeignKey("dbo.Items", t => t.EventIntenvotryItemRef_ItemId)
                .ForeignKey("dbo.Events", t => t.EventInventoryEventRef_EventId)
                .Index(t => t.EventIntenvotryItemRef_ItemId)
                .Index(t => t.EventInventoryEventRef_EventId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.EventPrices",
                c => new
                    {
                        EventPriceId = c.Int(nullable: false, identity: true),
                        EventPriceValue = c.Single(nullable: false),
                        EventPriceAttendanceTypeRef_AttendanceTypeId = c.Int(),
                        EventPriceEventRef_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.EventPriceId)
                .ForeignKey("dbo.AttendanceTypes", t => t.EventPriceAttendanceTypeRef_AttendanceTypeId)
                .ForeignKey("dbo.Events", t => t.EventPriceEventRef_EventId)
                .Index(t => t.EventPriceAttendanceTypeRef_AttendanceTypeId)
                .Index(t => t.EventPriceEventRef_EventId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        PurchaseBilled = c.Boolean(nullable: false),
                        PurchaseEventInventoryRef_EventInventoryId = c.Int(),
                        PurchaseUserRef_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.EventInventories", t => t.PurchaseEventInventoryRef_EventInventoryId)
                .ForeignKey("dbo.Users", t => t.PurchaseUserRef_UserId)
                .Index(t => t.PurchaseEventInventoryRef_EventInventoryId)
                .Index(t => t.PurchaseUserRef_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "PurchaseUserRef_UserId", "dbo.Users");
            DropForeignKey("dbo.Purchases", "PurchaseEventInventoryRef_EventInventoryId", "dbo.EventInventories");
            DropForeignKey("dbo.EventPrices", "EventPriceEventRef_EventId", "dbo.Events");
            DropForeignKey("dbo.EventPrices", "EventPriceAttendanceTypeRef_AttendanceTypeId", "dbo.AttendanceTypes");
            DropForeignKey("dbo.EventInventories", "EventInventoryEventRef_EventId", "dbo.Events");
            DropForeignKey("dbo.EventInventories", "EventIntenvotryItemRef_ItemId", "dbo.Items");
            DropForeignKey("dbo.Attendances", "AttendanceUserRef_UserId", "dbo.Users");
            DropForeignKey("dbo.Attendances", "AttendanceEventRef_EventId", "dbo.Events");
            DropForeignKey("dbo.Attendances", "AttendanceAttendanceTypeRef_AttendanceTypeId", "dbo.AttendanceTypes");
            DropIndex("dbo.Purchases", new[] { "PurchaseUserRef_UserId" });
            DropIndex("dbo.Purchases", new[] { "PurchaseEventInventoryRef_EventInventoryId" });
            DropIndex("dbo.EventPrices", new[] { "EventPriceEventRef_EventId" });
            DropIndex("dbo.EventPrices", new[] { "EventPriceAttendanceTypeRef_AttendanceTypeId" });
            DropIndex("dbo.EventInventories", new[] { "EventInventoryEventRef_EventId" });
            DropIndex("dbo.EventInventories", new[] { "EventIntenvotryItemRef_ItemId" });
            DropIndex("dbo.Attendances", new[] { "AttendanceUserRef_UserId" });
            DropIndex("dbo.Attendances", new[] { "AttendanceEventRef_EventId" });
            DropIndex("dbo.Attendances", new[] { "AttendanceAttendanceTypeRef_AttendanceTypeId" });
            DropTable("dbo.Purchases");
            DropTable("dbo.EventPrices");
            DropTable("dbo.Items");
            DropTable("dbo.EventInventories");
            DropTable("dbo.Users");
            DropTable("dbo.Events");
            DropTable("dbo.AttendanceTypes");
            DropTable("dbo.Attendances");
        }
    }
}
