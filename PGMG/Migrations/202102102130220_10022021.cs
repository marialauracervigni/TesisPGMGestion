namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10022021 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LlamadaSolicitadas", "UsuarioTelef", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LlamadaSolicitadas", "UsuarioTelef");
        }
    }
}
