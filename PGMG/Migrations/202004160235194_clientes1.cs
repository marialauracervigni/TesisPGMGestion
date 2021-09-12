namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientes1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clientes", "EmpleadoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "EmpleadoId", c => c.Int(nullable: false));
        }
    }
}
