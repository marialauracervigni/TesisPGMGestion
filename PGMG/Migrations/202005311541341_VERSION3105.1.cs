namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VERSION31051 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CodigoTareas", "Seleccionado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CodigoTareas", "Seleccionado");
        }
    }
}
