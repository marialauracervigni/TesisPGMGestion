namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Llamada2805 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Llamadas", "NombreCliente", c => c.String());
            AddColumn("dbo.Llamadas", "NombreEmpleado", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Llamadas", "NombreEmpleado");
            DropColumn("dbo.Llamadas", "NombreCliente");
        }
    }
}
