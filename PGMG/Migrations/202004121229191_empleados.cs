namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empleados : DbMigration
    {
        public override void Up()
        {

            //CreateTable(
            //   "dbo.empleadoes",
            //   c => new
            //   {
            //       EmpleadoId = c.Int(nullable: false, identity: true),
            //       NombreCompleto = c.String(),
            //       ClienteId = c.Int(nullable: false),
            //       Puesto = c.String(),
            //       Telefono = c.Int(nullable: false),
            //       Correo = c.String(),
            //   })
            //   .PrimaryKey(t => t.EmpleadoId);

            AddForeignKey("dbo.empleadoes", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);

        }
        
        public override void Down()
        {
        }
    }
}
