namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06022021 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId", newName: "Cliente_ClienteId1");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId", newName: "Cliente_ClienteId1");
        }
    }
}
