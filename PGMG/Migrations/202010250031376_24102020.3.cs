namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _241020203 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LlamadasEnCursoes",
                c => new
                    {
                        LlamadasEnCursoId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        NombreEmpleado = c.String(),
                        FormaDeComunicacionId = c.Int(nullable: false),
                        Usuario = c.String(),
                    })
                .PrimaryKey(t => t.LlamadasEnCursoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LlamadasEnCursoes");
        }
    }
}
