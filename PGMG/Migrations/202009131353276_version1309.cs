namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1309 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Etiquetas", "Marcado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Etiquetas", "Marcado");
        }
    }
}
