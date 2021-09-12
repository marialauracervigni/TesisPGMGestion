namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _26112020 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clientes", "FechaAlta");
            DropColumn("dbo.Clientes", "FechaFundacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "FechaFundacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clientes", "FechaAlta", c => c.DateTime(nullable: false));
        }
    }
}
