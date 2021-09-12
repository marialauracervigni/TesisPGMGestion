namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Listas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "ProvinciaId", "dbo.Provincias");
            DropIndex("dbo.Clientes", new[] { "ProvinciaId" });
            AddColumn("dbo.Provincias", "Cliente_ClienteId", c => c.Int());
            CreateIndex("dbo.Provincias", "Cliente_ClienteId");
            AddForeignKey("dbo.Provincias", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Provincias", "Cliente_ClienteId", "dbo.Clientes");
            DropIndex("dbo.Provincias", new[] { "Cliente_ClienteId" });
            DropColumn("dbo.Provincias", "Cliente_ClienteId");
            CreateIndex("dbo.Clientes", "ProvinciaId");
            AddForeignKey("dbo.Clientes", "ProvinciaId", "dbo.Provincias", "ProvinciaId", cascadeDelete: true);
        }
    }
}
