namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02032021 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Llamadas", "CodigoTareaId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Llamadas", "CodigoTareaId", c => c.Int());
        }
    }
}
