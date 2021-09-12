namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _140220212 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LlamadaSolicitadas", "Respuesta", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LlamadaSolicitadas", "Respuesta");
        }
    }
}
