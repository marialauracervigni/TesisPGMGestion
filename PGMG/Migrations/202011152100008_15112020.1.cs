namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _151120201 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Etiquetas", "Marcado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Etiquetas", "Marcado", c => c.Boolean(nullable: false));
        }
    }
}
