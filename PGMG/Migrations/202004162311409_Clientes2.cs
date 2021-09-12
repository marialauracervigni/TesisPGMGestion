namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Clientes2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clientes", "ModuloId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "ModuloId", c => c.Int(nullable: false));
        }
    }
}
