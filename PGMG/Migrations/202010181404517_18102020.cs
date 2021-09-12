namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18102020 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Llamadas", "TiempoPostLlamado", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Llamadas", "TiempoPostLlamado", c => c.Int(nullable: false));
        }
    }
}
