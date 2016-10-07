namespace NoobApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v01 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Attendances", "AttendanceStartDateTime");
            DropColumn("dbo.Attendances", "AttendanceEndDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "AttendanceEndDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Attendances", "AttendanceStartDateTime", c => c.DateTime(nullable: false));
        }
    }
}
