namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15022021 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LlamadaSolicitadas", "LlamadaId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LlamadaSolicitadas", "LlamadaId");
        }
    }
}
