namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _210220215 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Llamadas", "NombreCliente", c => c.String(nullable: false));
            AlterColumn("dbo.Llamadas", "NombreEmpleado", c => c.String(nullable: false));
            AlterColumn("dbo.Llamadas", "Tema", c => c.String(nullable: false));
            AlterColumn("dbo.Llamadas", "Descripcion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Llamadas", "Descripcion", c => c.String());
            AlterColumn("dbo.Llamadas", "Tema", c => c.String());
            AlterColumn("dbo.Llamadas", "NombreEmpleado", c => c.String());
            AlterColumn("dbo.Llamadas", "NombreCliente", c => c.String());
        }
    }
}
