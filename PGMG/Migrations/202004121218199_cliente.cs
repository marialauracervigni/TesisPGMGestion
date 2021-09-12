namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cliente : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "EmpleadoId_EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Clientes", "CodigosModulos_ModuloId", "dbo.Moduloes");
            //DropForeignKey("dbo.Empleadoes", "Cliente_ClienteId1", "dbo.Clientes");
            //DropForeignKey("dbo.Empleadoes", "Cliente_ClienteId", "dbo.Clientes");
            DropIndex("dbo.Clientes", new[] { "CodigosModulos_ModuloId" });
            DropIndex("dbo.Clientes", new[] { "EmpleadoId_EmpleadoId" });
            //DropIndex("dbo.Empleadoes", new[] { "Cliente_ClienteId" });
            //DropIndex("dbo.Empleadoes", new[] { "Cliente_ClienteId1" });
            //DropColumn("dbo.Empleadoes", "ClienteId");
            //DropColumn("dbo.Empleadoes", "ClienteId");
            RenameColumn(table: "dbo.Clientes", name: "CodigosModulos_ModuloId", newName: "ModuloId");
            //RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId1", newName: "ClienteId");
            //RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId", newName: "ClienteId");
            AddColumn("dbo.Clientes", "EmpleadoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clientes", "ModuloId", c => c.Int(nullable: false));
            //lterColumn("dbo.Empleadoes", "ClienteId", c => c.Int(nullable: false));
            //AlterColumn("dbo.Empleadoes", "ClienteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clientes", "ModuloId");
            //CreateIndex("dbo.Empleadoes", "ClienteId");
            AddForeignKey("dbo.Clientes", "ModuloId", "dbo.Moduloes", "ModuloId", cascadeDelete: true);
            //AddForeignKey("dbo.Empleadoes", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
            DropColumn("dbo.Clientes", "EmpleadoId_EmpleadoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "EmpleadoId_EmpleadoId", c => c.Int());
            //DropForeignKey("dbo.Empleadoes", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "ModuloId", "dbo.Moduloes");
            //DropIndex("dbo.Empleadoes", new[] { "ClienteId" });
            DropIndex("dbo.Clientes", new[] { "ModuloId" });
            //AlterColumn("dbo.Empleadoes", "ClienteId", c => c.Int());
            //AlterColumn("dbo.Empleadoes", "ClienteId", c => c.Int());
            AlterColumn("dbo.Clientes", "ModuloId", c => c.Int());
            DropColumn("dbo.Clientes", "EmpleadoId");
            //RenameColumn(table: "dbo.Empleadoes", name: "ClienteId", newName: "Cliente_ClienteId");
            //RenameColumn(table: "dbo.Empleadoes", name: "ClienteId", newName: "Cliente_ClienteId1");
            RenameColumn(table: "dbo.Clientes", name: "ModuloId", newName: "CodigosModulos_ModuloId");
            //AddColumn("dbo.Empleadoes", "ClienteId", c => c.Int(nullable: false));
            //AddColumn("dbo.Empleadoes", "ClienteId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Empleadoes", "Cliente_ClienteId1");
            //CreateIndex("dbo.Empleadoes", "Cliente_ClienteId");
            CreateIndex("dbo.Clientes", "EmpleadoId_EmpleadoId");
            CreateIndex("dbo.Clientes", "CodigosModulos_ModuloId");
            //AddForeignKey("dbo.Empleadoes", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
            //AddForeignKey("dbo.Empleadoes", "Cliente_ClienteId1", "dbo.Clientes", "ClienteId");
            AddForeignKey("dbo.Clientes", "CodigosModulos_ModuloId", "dbo.Moduloes", "ModuloId");
            AddForeignKey("dbo.Clientes", "EmpleadoId_EmpleadoId", "dbo.Empleadoes", "EmpleadoId");
        }
    }
}
