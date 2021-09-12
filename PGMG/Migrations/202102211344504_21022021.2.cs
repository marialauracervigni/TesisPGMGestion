namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _210220212 : DbMigration
    {
        public override void Up()
        {
            RenameTable("dbo.CodigoPorLlamada", "CodigoPorLlamada");
        }
        
        public override void Down()
        {
            RenameTable("dbo.CodigoPorLlamada", "CodigoPorLlamada");
        }
    }
}
