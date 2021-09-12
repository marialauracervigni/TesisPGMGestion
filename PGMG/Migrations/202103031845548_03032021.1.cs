namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _030320211 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LlamadaHists", "Cerrado", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LlamadaHists", "Cerrado");
        }
    }
}
