namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigration04022021 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId", newName: "Cliente_ClienteId");
        }
        
        public override void Down()
        {
        }
    }
}
