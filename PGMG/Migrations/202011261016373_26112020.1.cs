namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _261120201 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "FechaFundacion", c => c.DateTime(nullable: true));
            AddColumn("dbo.Clientes", "FechaAlta", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "FechaAlta");
            DropColumn("dbo.Clientes", "FechaFundacion");
        }
    }
}
