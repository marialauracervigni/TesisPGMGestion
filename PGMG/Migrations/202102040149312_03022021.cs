namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03022021 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Empleadoes", "Cliente_ClienteId", "dbo.Clientes");
            //DropIndex("dbo.Empleadoes", new[] { "Cliente_ClienteId" });
            //AddColumn("dbo.Empleadoes", "Cliente_ClienteId1", c => c.Int());
            //AlterColumn("dbo.Empleadoes", "Cliente_ClienteId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Empleadoes", "Cliente_ClienteId1");
            //AddForeignKey("dbo.Empleadoes", "Cliente_ClienteId1", "dbo.Clientes", "ClienteId");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Empleadoes", "Cliente_ClienteId1", "dbo.Clientes");
            //DropIndex("dbo.Empleadoes", new[] { "Cliente_ClienteId1" });
            //AlterColumn("dbo.Empleadoes", "Cliente_ClienteId", c => c.Int());
            //DropColumn("dbo.Empleadoes", "Cliente_ClienteId1");
            //CreateIndex("dbo.Empleadoes", "Cliente_ClienteId");
            //AddForeignKey("dbo.Empleadoes", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
        }
    }
}
