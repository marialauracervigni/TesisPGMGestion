namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _251020203 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Llamadas", "CodigoTareaId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Llamadas", "CodigoTareaId", c => c.Int(nullable: false));
        }
    }
}
