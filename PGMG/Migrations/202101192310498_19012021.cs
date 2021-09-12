namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19012021 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Llamadas", "TiempoPostLlamado", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Llamadas", "TiempoPostLlamado", c => c.Int());
        }
    }
}
