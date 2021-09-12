namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03102020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LlamadaSolicitadas", "NombreEmpleado", c => c.String());
            DropColumn("dbo.LlamadaSolicitadas", "UsuarioId");
            DropColumn("dbo.LlamadaSolicitadas", "NombreUsuario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LlamadaSolicitadas", "NombreUsuario", c => c.String());
            AddColumn("dbo.LlamadaSolicitadas", "UsuarioId", c => c.Int(nullable: false));
            DropColumn("dbo.LlamadaSolicitadas", "NombreEmpleado");
        }
    }
}
