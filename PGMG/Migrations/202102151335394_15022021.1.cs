namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _150220211 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LlamadaSolicitadas", "NombreCliente", c => c.String(nullable: false));
            AlterColumn("dbo.LlamadaSolicitadas", "NombreEmpleado", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LlamadaSolicitadas", "NombreEmpleado", c => c.String());
            AlterColumn("dbo.LlamadaSolicitadas", "NombreCliente", c => c.String());
        }
    }
}
