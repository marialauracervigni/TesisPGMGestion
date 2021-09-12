namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _040220211 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LlamadaHists", "TiempoPostLlamado", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LlamadaHists", "TiempoPostLlamado", c => c.Int());
        }
    }
}
