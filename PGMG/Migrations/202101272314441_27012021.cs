namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _27012021 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ViajesViewModels",
                c => new
                    {
                        ViajesViewModelId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Start = c.String(),
                        End = c.String(),
                        AllDay = c.Boolean(nullable: false),
                        Color = c.String(),
                        TextColor = c.String(),
                    })
                .PrimaryKey(t => t.ViajesViewModelId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ViajesViewModels");
        }
    }
}
