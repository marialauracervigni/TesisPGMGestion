namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _041020201 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LlamadaHists", "LlamadaId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LlamadaHists", "LlamadaId");
        }
    }
}
