namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01032021 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LlamadaHists", "Inicial", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LlamadaHists", "Inicial");
        }
    }
}
