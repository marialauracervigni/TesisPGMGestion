namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _150220212 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Llamadas", "LlamadaSolicitadaId", c => c.Int());
            DropColumn("dbo.Llamadas", "LlamadaEnCursoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Llamadas", "LlamadaEnCursoId", c => c.Int(nullable: false));
            DropColumn("dbo.Llamadas", "LlamadaSolicitadaId");
        }
    }
}
