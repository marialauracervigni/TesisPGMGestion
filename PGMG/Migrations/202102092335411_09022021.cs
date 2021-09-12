namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09022021 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ViajesViewModels", "Observaciones", c => c.String());
            AddColumn("dbo.ViajesViewModels", "Confirmado", c => c.String());
            AddColumn("dbo.ViajesViewModels", "Realizado", c => c.String());
            AlterColumn("dbo.ViajesViewModels", "Start", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ViajesViewModels", "End", c => c.DateTime(nullable: false));
            DropColumn("dbo.ViajesViewModels", "AllDay");
            DropColumn("dbo.ViajesViewModels", "Color");
            DropColumn("dbo.ViajesViewModels", "TextColor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ViajesViewModels", "TextColor", c => c.String());
            AddColumn("dbo.ViajesViewModels", "Color", c => c.String());
            AddColumn("dbo.ViajesViewModels", "AllDay", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ViajesViewModels", "End", c => c.String());
            AlterColumn("dbo.ViajesViewModels", "Start", c => c.String());
            DropColumn("dbo.ViajesViewModels", "Realizado");
            DropColumn("dbo.ViajesViewModels", "Confirmado");
            DropColumn("dbo.ViajesViewModels", "Observaciones");
        }
    }
}
