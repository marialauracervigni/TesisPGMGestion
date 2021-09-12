namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31082020 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Llamadas", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Llamadas", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Llamadas", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
            RenameColumn(table: "dbo.Llamadas", name: "ApplicationUser_Id", newName: "ApplicationUserId");
        }
    }
}
