namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VERSION1111 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId", newName: "ClienId");
        }
        
        public override void Down()
        {
        }
    }
}
