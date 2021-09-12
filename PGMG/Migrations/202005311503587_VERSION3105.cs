namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VERSION3105 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LlamadaSolicitadas", "NombreUsuario", c => c.String());
            AddColumn("dbo.LlamadaSolicitadas", "NombreCliente", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LlamadaSolicitadas", "NombreCliente");
            DropColumn("dbo.LlamadaSolicitadas", "NombreUsuario");
        }
    }
}
