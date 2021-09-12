namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _251020205 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Llamadas", "LlamadaEnCursoId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Llamadas", "LlamadaEnCursoId");
        }
    }
}
