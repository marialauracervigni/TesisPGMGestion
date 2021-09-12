namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _031020203 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LlamadaSolicitadas", "EstadoLlamada");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LlamadaSolicitadas", "EstadoLlamada", c => c.String());
        }
    }
}
