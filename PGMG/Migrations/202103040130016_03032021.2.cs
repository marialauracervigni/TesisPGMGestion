namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _030320212 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CodigosEnLlamadas", "Seleccionado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CodigosEnLlamadas", "Seleccionado");
        }
    }
}
