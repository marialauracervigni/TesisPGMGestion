namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modific2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "ModuloId", "dbo.Moduloes");
            //DropForeignKey("dbo.Empleadoes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Clientes", new[] { "ModuloId" });
            //DropIndex("dbo.Empleadoes", new[] { "ClienteId" });
           // RenameColumn(table: "dbo.Empleadoes", name: "ClienteId", newName: "Cliente_ClienteId");
            AddColumn("dbo.Moduloes", "Cliente_ClienteId", c => c.Int());
            //AlterColumn("dbo.Empleadoes", "Cliente_ClienteId", c => c.Int());
            CreateIndex("dbo.Moduloes", "Cliente_ClienteId");
            //CreateIndex("dbo.Empleadoes", "Cliente_ClienteId");
            AddForeignKey("dbo.Moduloes", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
            //AddForeignKey("dbo.Empleadoes", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Empleadoes", "Cliente_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Moduloes", "Cliente_ClienteId", "dbo.Clientes");
           // DropIndex("dbo.Empleadoes", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.Moduloes", new[] { "Cliente_ClienteId" });
            //AlterColumn("dbo.Empleadoes", "Cliente_ClienteId", c => c.Int(nullable: false));
            DropColumn("dbo.Moduloes", "Cliente_ClienteId");
           // RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId", newName: "ClienteId");
           // CreateIndex("dbo.Empleadoes", "ClienteId");
            CreateIndex("dbo.Clientes", "ModuloId");
            //AddForeignKey("dbo.Empleadoes", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
            AddForeignKey("dbo.Clientes", "ModuloId", "dbo.Moduloes", "ModuloId", cascadeDelete: true);
        }
    }
}
