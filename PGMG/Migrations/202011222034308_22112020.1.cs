namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _221120201 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.LlamadaSolicitadas", "ClienteId");
            AddForeignKey("dbo.LlamadaSolicitadas", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LlamadaSolicitadas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.LlamadaSolicitadas", new[] { "ClienteId" });
        }
    }
}
