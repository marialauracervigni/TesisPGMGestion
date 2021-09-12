namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Empleadoes", "Cliente_ClienteId", "dbo.Clientes");
            DropIndex("dbo.Empleadoes", new[] { "Cliente_ClienteId" });
            RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId", newName: "ClienteId");
            AlterColumn("dbo.Empleadoes", "ClienteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Empleadoes", "ClienteId");
            AddForeignKey("dbo.Empleadoes", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleadoes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Empleadoes", new[] { "ClienteId" });
            AlterColumn("dbo.Empleadoes", "ClienteId", c => c.Int());
            RenameColumn(table: "dbo.Empleadoes", name: "ClienteId", newName: "Cliente_ClienteId");
            CreateIndex("dbo.Empleadoes", "Cliente_ClienteId");
            AddForeignKey("dbo.Empleadoes", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
        }
    }
}
