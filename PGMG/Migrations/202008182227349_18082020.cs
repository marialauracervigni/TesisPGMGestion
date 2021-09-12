namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18082020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Llamadas", "UsuarioId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Llamadas", "UsuarioId");
        }
    }
}
