namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _090220211 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ViajesViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ViajesViewModels",
                c => new
                    {
                        ViajesViewModelId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Observaciones = c.String(),
                        Confirmado = c.String(),
                        Realizado = c.String(),
                    })
                .PrimaryKey(t => t.ViajesViewModelId);
            
        }
    }
}
