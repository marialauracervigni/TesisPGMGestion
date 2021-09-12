namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02112020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CodigoPorLlamadas", "CodigoTareaId", c => c.Int(nullable: false));
            DropColumn("dbo.CodigoPorLlamadas", "Codigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CodigoPorLlamadas", "Codigo", c => c.Int(nullable: false));
            DropColumn("dbo.CodigoPorLlamadas", "CodigoTareaId");
        }
    }
}
