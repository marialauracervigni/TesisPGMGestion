namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VERSION12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.empleadoes", "Cliente_ClienteId1", "dbo.Clientes");
            DropIndex("dbo.empleadoes", new[] { "Cliente_ClienteId1" });
            DropColumn("dbo.empleadoes", "Cliente_ClienteId");
            //RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId1", newName: "Cliente_ClienteId");
            //AlterColumn("dbo.Empleadoes", "Cliente_ClienteId", c => c.Int());
            AddColumn("dbo.empleadoes", "Cliente_ClienteId", c => c.Int());
            CreateIndex("dbo.empleadoes", "Cliente_ClienteId");
            //DropForeignKey("dbo.empleadoes", "Cliente_ClienteId1", "dbo.Clientes", "ClienteId");
            AddForeignKey("dbo.empleadoes", "Cliente_ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);

        }
        
        public override void Down()
        {
            //DropIndex("dbo.Empleadoes", new[] { "Cliente_ClienteId" });
            //AlterColumn("dbo.Empleadoes", "Cliente_ClienteId", c => c.Int(nullable: false));
            //RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId", newName: "Cliente_ClienteId1");
            //AddColumn("dbo.Empleadoes", "Cliente_ClienteId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Empleadoes", "Cliente_ClienteId1");
        }
    }
}
