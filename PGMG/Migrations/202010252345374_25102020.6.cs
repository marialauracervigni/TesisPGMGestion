namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _251020206 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LlamadasEnCursoes", "Activo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LlamadasEnCursoes", "Activo");
        }
    }
}
