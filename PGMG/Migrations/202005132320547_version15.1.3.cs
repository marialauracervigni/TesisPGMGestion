namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1513 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LlamadaSolicitadas", "Cliente_ClienteId", "dbo.Clientes");
            DropIndex("dbo.LlamadaSolicitadas", new[] { "Cliente_ClienteId" });
        }
        
        public override void Down()
        {
        }
    }
}
