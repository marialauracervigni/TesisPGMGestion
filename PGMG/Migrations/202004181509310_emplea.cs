namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emplea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.empleadoes", "Cliente_ClienteId", c => c.Int());
            AddForeignKey("dbo.empleadoes", "Cliente_ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
        }
        
        public override void Down()
        {
        }
    }
}
