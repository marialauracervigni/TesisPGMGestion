namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20022021 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Llamadas", "TiempoEnLlamado", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Llamadas", "TiempoPostLlamado", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LlamadaHists", "TiempoEnLlamado", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LlamadaHists", "TiempoPostLlamado", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LlamadaHists", "TiempoPostLlamado", c => c.String());
            AlterColumn("dbo.LlamadaHists", "TiempoEnLlamado", c => c.String());
            AlterColumn("dbo.Llamadas", "TiempoPostLlamado", c => c.String());
            AlterColumn("dbo.Llamadas", "TiempoEnLlamado", c => c.String());
        }
    }
}
