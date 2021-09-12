namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1512 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LlamadaSolicitadas", "Cliente_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.LlamadaSolicitadas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.LlamadaSolicitadas", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.LlamadaSolicitadas", new[] { "ClienteId" });
            AddColumn("dbo.LlamadaSolicitadas", "ClienteId", c => c.Int());
            //RenameColumn(table: "dbo.LlamadaSolicitadas", name: "Cliente_ClienteId", newName: "ClienteId");
            //AlterColumn("dbo.LlamadaSolicitadas", "ClienteId", c => c.Int(nullable: false));
            CreateIndex("dbo.LlamadaSolicitadas", "ClienteId");
            AddForeignKey("dbo.LlamadaSolicitadas", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
            DropColumn("dbo.LlamadaSolicitadas", "Cliente_ClienteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LlamadaSolicitadas", "Cliente_ClienteId", c => c.Int(nullable: false));
            DropForeignKey("dbo.LlamadaSolicitadas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.LlamadaSolicitadas", new[] { "ClienteId" });
            AlterColumn("dbo.LlamadaSolicitadas", "ClienteId", c => c.Int());
            RenameColumn(table: "dbo.LlamadaSolicitadas", name: "ClienteId", newName: "ClienteLlamadaSolic_ClienteId");
            CreateIndex("dbo.LlamadaSolicitadas", "ClienteLlamadaSolic_ClienteId");
            AddForeignKey("dbo.LlamadaSolicitadas", "ClienteLlamadaSolic_ClienteId", "dbo.Clientes", "ClienteId");
        }
    }
}
