namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _180820202 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LlamadaSolicitadas", "Usuario", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LlamadaSolicitadas", "Usuario");
        }
    }
}
