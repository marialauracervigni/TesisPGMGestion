namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VERSION15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LlamadaSolicitadas", "Observaciones", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LlamadaSolicitadas", "Observaciones");
        }
    }
}
