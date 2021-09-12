namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _150220214 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "Localidad", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Localidad", c => c.String());
            AlterColumn("dbo.Clientes", "Nombre", c => c.String());
        }
    }
}
