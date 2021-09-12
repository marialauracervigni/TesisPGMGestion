namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _150220213 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Empleadoes", "NombreCompleto", c => c.String(nullable: false));
            AlterColumn("dbo.Empleadoes", "Puesto", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empleadoes", "Puesto", c => c.String());
            AlterColumn("dbo.Empleadoes", "NombreCompleto", c => c.String());
        }
    }
}
