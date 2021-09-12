namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version101 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Empleadoes", "ClienteId", "dbo.Clientes");
            //DropIndex("dbo.Empleadoes", new[] { "ClienteId" });
            //RenameColumn(table: "dbo.Empleadoes", name: "ClClienteId", newName: "Cliente_ClienteId1");
            //AddColumn("dbo.Empleadoes", "Cliente_ClienteId1", c => c.Int(nullable: false));
            AlterColumn("dbo.Empleadoes", "Cliente_ClienteId", c => c.Int());
            //CreateIndex("dbo.Empleadoes", "Cliente_ClienteId");
            //AddForeignKey("dbo.Empleadoes", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
        }

        public override void Down()
        {
            //DropForeignKey("dbo.Empleadoes", "Cliente_ClienteId1", "dbo.Clientes");
            //DropIndex("dbo.Empleadoes", new[] { "Cliente_ClienteId1" });
            //AlterColumn("dbo.Empleadoes", "Cliente_ClienteId1", c => c.Int(nullable: false));
            //DropColumn("dbo.Empleadoes", "Cliente_ClienteId1");
            //RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId1", newName: "ClienteId");
            //CreateIndex("dbo.Empleadoes", "ClienteId");
            //AddForeignKey("dbo.Empleadoes", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
        }
    }
}
