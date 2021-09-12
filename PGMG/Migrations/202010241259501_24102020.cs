namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _24102020 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Llamadas", "TiempoEnLlamado", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Llamadas", "TiempoEnLlamado", c => c.Int(nullable: false));
        }
    }
}
