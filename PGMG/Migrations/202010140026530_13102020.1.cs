namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _131020201 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodigoPorLlamadas",
                c => new
                    {
                        CodigoPorLlamadaId = c.Int(nullable: false, identity: true),
                        LlamadaId = c.Int(nullable: false),
                        CodigoTareaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoPorLlamadaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CodigoPorLlamadas");
        }
    }
}
