namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23082020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Llamadas", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Llamadas", "ApplicationUserId");
            AddForeignKey("dbo.Llamadas", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Llamadas", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Llamadas", new[] { "ApplicationUserId" });
            DropColumn("dbo.Llamadas", "ApplicationUserId");
        }
    }
}
