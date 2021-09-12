namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _031020204 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LlamadaSolicitadas", "EstadoLlamada", c => c.String());
            AlterColumn("dbo.LlamadaSolicitadas", "Telefono", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LlamadaSolicitadas", "Telefono", c => c.Int(nullable: false));
            DropColumn("dbo.LlamadaSolicitadas", "EstadoLlamada");
        }
    }
}
