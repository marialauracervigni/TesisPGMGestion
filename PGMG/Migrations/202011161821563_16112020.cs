namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16112020 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FormaDeComunicacions", "Seleccionado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FormaDeComunicacions", "Seleccionado", c => c.Boolean(nullable: false));
        }
    }
}
