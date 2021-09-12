namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _060220211 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId1", newName: "Cliente_ClienteId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId1", newName: "Cliente_ClienteId");
        }
    }
}
