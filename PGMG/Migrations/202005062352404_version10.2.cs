namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version102 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Empleadoes", "Cliente_ClienteId", "dbo.Clientes");
            //DropIndex("dbo.Empleadoes", new[] { "Cliente_ClienteId" });
            //RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId", newName: "ClienteId");
            //AlterColumn("dbo.Empleadoes", "ClienteId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Empleadoes", "ClienteId");
            //AddForeignKey("dbo.Empleadoes", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
            //DropColumn("dbo.Empleadoes", "Cliente_ClienteId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Empleadoes", "Cliente_ClienteId", c => c.Int(nullable: false));
            //DropForeignKey("dbo.Empleadoes", "ClienteId", "dbo.Clientes");
            //DropIndex("dbo.Empleadoes", new[] { "ClienteId" });
            //AlterColumn("dbo.Empleadoes", "ClienteId", c => c.Int());
            //RenameColumn(table: "dbo.Empleadoes", name: "ClienteId", newName: "Cliente_ClienteId1");
            //CreateIndex("dbo.Empleadoes", "Cliente_ClienteId1");
            //AddForeignKey("dbo.Empleadoes", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
        }
    }
}
