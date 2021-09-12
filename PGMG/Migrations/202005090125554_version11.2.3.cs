namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1123 : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.Empleadoes", new[] { "Cliente_ClienteId" });
            //DropColumn("dbo.Empleadoes", "Cliente_ClienteId1");
            RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId1", newName: "Cliente_ClienteId");
            //AlterColumn("dbo.Empleadoes", "Cliente_ClienteId1", c => c.Int());
            //AlterColumn("dbo.Empleadoes", "Cliente_ClienteId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Empleadoes", "Cliente_ClienteId");
        }
        
        public override void Down()
        {
            //DropIndex("dbo.Empleadoes", new[] { "Cliente_ClienteId1" });
            //AlterColumn("dbo.Empleadoes", "Cliente_ClienteId", c => c.Int());
            //AlterColumn("dbo.Empleadoes", "Cliente_ClienteId1", c => c.Int(nullable: false));
            //RenameColumn(table: "dbo.Empleadoes", name: "Cliente_ClienteId1", newName: "Cliente_ClienteId");
            //AddColumn("dbo.Empleadoes", "Cliente_ClienteId1", c => c.Int(nullable: false));
            //CreateIndex("dbo.Empleadoes", "Cliente_ClienteId");
        }
    }
}
