namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDMIGRATION19102020 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Llamadas", "TiempoEnLlamado", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Llamadas", "TiempoEnLlamado", c => c.DateTime(nullable: false));
        }
    }
}
