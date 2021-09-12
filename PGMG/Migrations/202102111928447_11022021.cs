namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11022021 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "allDay", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "allDay");
        }
    }
}
