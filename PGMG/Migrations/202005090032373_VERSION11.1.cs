namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VERSION111 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Empleadoes", "ClienteId", "dbo.Clientes");
            //DropIndex("dbo.Empleadoes", new[] { "ClienteId" });
            RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId", newName: "ClienId");
            //AddColumn("dbo.Empleadoes", "ClienId", c => c.Int(nullable: false));
            //AlterColumn("dbo.Empleadoes", "Cliente_ClienteId", c => c.Int());
            //CreateIndex("dbo.Empleadoes", "Cliente_ClienteId");
            //AddForeignKey("dbo.Empleadoes", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Empleadoes", "Cliente_ClienteId", "dbo.Clientes");
            //DropIndex("dbo.Empleadoes", new[] { "Cliente_ClienteId" });
            //AlterColumn("dbo.Empleadoes", "Cliente_ClienteId", c => c.Int(nullable: false));
            //DropColumn("dbo.Empleadoes", "ClienId");
            //RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId", newName: "ClienteId");
            //CreateIndex("dbo.Empleadoes", "ClienteId");
            //AddForeignKey("dbo.Empleadoes", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
        }
    }
}
