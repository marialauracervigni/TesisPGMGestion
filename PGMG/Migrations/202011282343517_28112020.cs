namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28112020 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LlamadaSolicitadas", "Telefono", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LlamadaSolicitadas", "Telefono", c => c.Int());
        }
    }
}
