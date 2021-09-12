namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VERSION11 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId", newName: "ClienteId");
        }
        
        public override void Down()
        {
        }
    }
}
