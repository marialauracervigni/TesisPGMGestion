namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _180820201 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Llamadas", "UsuarioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Llamadas", "UsuarioId", c => c.Int(nullable: false));
        }
    }
}
