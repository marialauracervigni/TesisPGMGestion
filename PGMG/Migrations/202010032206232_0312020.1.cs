namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03120201 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LlamadaSolicitadas", "EstadoLlamada", c => c.String());
            DropColumn("dbo.LlamadaSolicitadas", "EstadLlamada");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LlamadaSolicitadas", "EstadLlamada", c => c.String());
            DropColumn("dbo.LlamadaSolicitadas", "EstadoLlamada");
        }
    }
}
