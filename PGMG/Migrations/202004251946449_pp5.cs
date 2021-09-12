namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pp5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "Provincia_ProvinciaId", "dbo.Provincias");
            DropIndex("dbo.Clientes", new[] { "Provincia_ProvinciaId" });
            DropColumn("dbo.Clientes", "Provincia_ProvinciaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Provincia_ProvinciaId", c => c.Int());
            CreateIndex("dbo.Clientes", "Provincia_ProvinciaId");
            AddForeignKey("dbo.Clientes", "Provincia_ProvinciaId", "dbo.Provincias", "ProvinciaId");
        }
    }
}
