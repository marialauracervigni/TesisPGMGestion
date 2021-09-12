namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _07112020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Llamadas", "Activo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Llamadas", "Activo");
        }
    }
}
