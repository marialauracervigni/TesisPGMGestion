namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class provincia1 : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.Provincias", "Cliente_ClienteId");
            
            DropColumn("dbo.Provincias", "Cliente_ClienteId");
            
        }
        
        public override void Down()
        {
        }
    }
}
