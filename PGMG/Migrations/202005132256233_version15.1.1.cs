namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1511 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.LlamadaSolicitadas", "Cliente_ClienteId", "dbo.Clientes");
            //DropIndex("dbo.LlamadaSolicitadas", new[] { "Cliente_ClienteId" });
            //RenameColumn(table: "dbo.LlamadaSolicitadas", name: "Cliente_ClienteId", newName: "ClienteLlamadaSolic_ClienteId");
            //AddColumn("dbo.LlamadaSolicitadas", "Cliente_ClienteId", c => c.Int(nullable: false));
            //AlterColumn("dbo.LlamadaSolicitadas", "ClienteLlamadaSolic_ClienteId", c => c.Int());
            //CreateIndex("dbo.LlamadaSolicitadas", "ClienteLlamadaSolic_ClienteId");
            //AddForeignKey("dbo.LlamadaSolicitadas", "ClienteLlamadaSolic_ClienteId", "dbo.Clientes", "ClienteId");
        }

        public override void Down()
        {
            //DropForeignKey("dbo.LlamadaSolicitadas", "ClienteLlamadaSolic_ClienteId", "dbo.Clientes");
            //DropIndex("dbo.LlamadaSolicitadas", new[] { "ClienteLlamadaSolic_ClienteId" });
            //AlterColumn("dbo.LlamadaSolicitadas", "ClienteLlamadaSolic_ClienteId", c => c.Int(nullable: false));
            //DropColumn("dbo.LlamadaSolicitadas", "Cliente_ClienteId");
            //RenameColumn(table: "dbo.LlamadaSolicitadas", name: "ClienteLlamadaSolic_ClienteId", newName: "ClienteId");
            //CreateIndex("dbo.LlamadaSolicitadas", "ClienteId");
            //AddForeignKey("dbo.LlamadaSolicitadas", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
        }
    }
}
