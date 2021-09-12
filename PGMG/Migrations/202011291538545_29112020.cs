namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _29112020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CodigoPorLlamadas", "Seleccionado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CodigoPorLlamadas", "Seleccionado");
        }
    }
}
