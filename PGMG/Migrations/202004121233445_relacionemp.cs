namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relacionemp : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.empleadoes", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);

        }

        public override void Down()
        {
        }
    }
}
