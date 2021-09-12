namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _150220216 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Empleadoes", "Cliente_ClienteId1", "dbo.Clientes");
            DropForeignKey("dbo.Llamadas", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.LlamadaHists", "Empleado_EmpleadoId", "dbo.Empleadoes");
            DropIndex("dbo.Empleadoes", new[] { "Cliente_ClienteId1" });
            DropIndex("dbo.Llamadas", new[] { "EmpleadoId" });
            DropIndex("dbo.LlamadaHists", new[] { "Empleado_EmpleadoId" });
            CreateIndex("dbo.EmpleadosClientes", "ClienteId");
            AddForeignKey("dbo.EmpleadosClientes", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
            DropColumn("dbo.LlamadaHists", "Empleado_EmpleadoId");
            DropTable("dbo.Empleadoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        NombreCompleto = c.String(nullable: false),
                        Puesto = c.String(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Correo = c.String(),
                        Cliente_ClienteId = c.Int(nullable: false),
                        Cliente_ClienteId1 = c.Int(),
                    })
                .PrimaryKey(t => t.EmpleadoId);
            
            AddColumn("dbo.LlamadaHists", "Empleado_EmpleadoId", c => c.Int());
            DropForeignKey("dbo.EmpleadosClientes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.EmpleadosClientes", new[] { "ClienteId" });
            CreateIndex("dbo.LlamadaHists", "Empleado_EmpleadoId");
            CreateIndex("dbo.Llamadas", "EmpleadoId");
            CreateIndex("dbo.Empleadoes", "Cliente_ClienteId1");
            AddForeignKey("dbo.LlamadaHists", "Empleado_EmpleadoId", "dbo.Empleadoes", "EmpleadoId");
            AddForeignKey("dbo.Llamadas", "EmpleadoId", "dbo.Empleadoes", "EmpleadoId", cascadeDelete: true);
            AddForeignKey("dbo.Empleadoes", "Cliente_ClienteId1", "dbo.Clientes", "ClienteId");
        }
    }
}
