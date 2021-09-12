namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version22062020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Llamadas", "seleccionado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Llamadas", "seleccionado");
        }
    }
}
