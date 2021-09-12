namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31020200 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LlamadaSolicitadas", "EstadLlamada", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LlamadaSolicitadas", "EstadLlamada");
        }
    }
}
