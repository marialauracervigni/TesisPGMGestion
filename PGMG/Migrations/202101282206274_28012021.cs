namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28012021 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viajes", "Realizado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viajes", "Realizado");
        }
    }
}
