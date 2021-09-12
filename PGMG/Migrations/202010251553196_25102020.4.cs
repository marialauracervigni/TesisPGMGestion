namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _251020204 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Llamadas", "EstadoId", "dbo.Estadoes");
            DropIndex("dbo.Llamadas", new[] { "EstadoId" });
            AlterColumn("dbo.Llamadas", "EstadoId", c => c.Int());
            CreateIndex("dbo.Llamadas", "EstadoId");
            AddForeignKey("dbo.Llamadas", "EstadoId", "dbo.Estadoes", "EstadoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Llamadas", "EstadoId", "dbo.Estadoes");
            DropIndex("dbo.Llamadas", new[] { "EstadoId" });
            AlterColumn("dbo.Llamadas", "EstadoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Llamadas", "EstadoId");
            AddForeignKey("dbo.Llamadas", "EstadoId", "dbo.Estadoes", "EstadoId", cascadeDelete: true);
        }
    }
}
