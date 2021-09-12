namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _251020201 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Llamadas", "EstadoId", "dbo.Estadoes");
            DropIndex("dbo.Llamadas", new[] { "EstadoId" });
            AddColumn("dbo.FormaDeComunicacions", "LlamadasEnCurso_LlamadasEnCursoId", c => c.Int());
            AddColumn("dbo.LlamadasEnCursoes", "EmpleadoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Llamadas", "EstadoId", c => c.Int(nullable: false));
            CreateIndex("dbo.FormaDeComunicacions", "LlamadasEnCurso_LlamadasEnCursoId");
            CreateIndex("dbo.Llamadas", "EstadoId");
            CreateIndex("dbo.LlamadasEnCursoes", "ClienteId");
            AddForeignKey("dbo.LlamadasEnCursoes", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
            AddForeignKey("dbo.FormaDeComunicacions", "LlamadasEnCurso_LlamadasEnCursoId", "dbo.LlamadasEnCursoes", "LlamadasEnCursoId");
            AddForeignKey("dbo.Llamadas", "EstadoId", "dbo.Estadoes", "EstadoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Llamadas", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.FormaDeComunicacions", "LlamadasEnCurso_LlamadasEnCursoId", "dbo.LlamadasEnCursoes");
            DropForeignKey("dbo.LlamadasEnCursoes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.LlamadasEnCursoes", new[] { "ClienteId" });
            DropIndex("dbo.Llamadas", new[] { "EstadoId" });
            DropIndex("dbo.FormaDeComunicacions", new[] { "LlamadasEnCurso_LlamadasEnCursoId" });
            AlterColumn("dbo.Llamadas", "EstadoId", c => c.Int());
            DropColumn("dbo.LlamadasEnCursoes", "EmpleadoId");
            DropColumn("dbo.FormaDeComunicacions", "LlamadasEnCurso_LlamadasEnCursoId");
            CreateIndex("dbo.Llamadas", "EstadoId");
            AddForeignKey("dbo.Llamadas", "EstadoId", "dbo.Estadoes", "EstadoId");
        }
    }
}
