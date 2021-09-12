namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12122020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viajes", "Confirmado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viajes", "Confirmado");
        }
    }
}
