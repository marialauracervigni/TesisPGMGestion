namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _29102020 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LlamadasEnCursoes", "NombreCliente", c => c.String(nullable: false));
            AlterColumn("dbo.LlamadasEnCursoes", "NombreEmpleado", c => c.String(nullable: false));
            AlterColumn("dbo.LlamadasEnCursoes", "Usuario", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LlamadasEnCursoes", "Usuario", c => c.String());
            AlterColumn("dbo.LlamadasEnCursoes", "NombreEmpleado", c => c.String());
            AlterColumn("dbo.LlamadasEnCursoes", "NombreCliente", c => c.String());
        }
    }
}
