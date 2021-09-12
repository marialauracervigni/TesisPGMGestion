namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _140220213 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Viajes", "NombreCliente", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Viajes", "NombreCliente", c => c.String());
        }
    }
}
