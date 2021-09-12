namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _150220215 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmpleadosClientes",
                c => new
                    {
                        EmpleadosClientesId = c.Int(nullable: false, identity: true),
                        NombreCompleto = c.String(nullable: false),
                        Puesto = c.String(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Correo = c.String(),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpleadosClientesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmpleadosClientes");
        }
    }
}
