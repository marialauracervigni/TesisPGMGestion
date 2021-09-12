namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _251020202 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LlamadasEnCursoes", "NombreCliente", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LlamadasEnCursoes", "NombreCliente");
        }
    }
}
