namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _181020202 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Llamadas", "seleccionado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Llamadas", "seleccionado", c => c.Boolean(nullable: false));
        }
    }
}
