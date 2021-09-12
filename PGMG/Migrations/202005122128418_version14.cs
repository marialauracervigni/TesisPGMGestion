namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version14 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.LlamadaSolicitadas", name: "ClienteId", newName: "Cliente_ClienteId");
            CreateIndex("dbo.LlamadaSolicitadas", "Cliente_ClienteId");
        }
        
        public override void Down()
        {
        }
    }
}
