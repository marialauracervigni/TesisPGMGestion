namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22112020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LlamadaSolicitadas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.LlamadaSolicitadas", new[] { "ClienteId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.LlamadaSolicitadas", "ClienteId");
            AddForeignKey("dbo.LlamadaSolicitadas", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
        }
    }
}
