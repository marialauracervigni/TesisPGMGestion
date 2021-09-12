namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PRVI : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Provincias", "Cliente_ClienteId", "dbo.Clientes");
            //DropIndex("dbo.Provincias", new[] { "Cliente_ClienteId" });
            //AddColumn("dbo.Clientes", "ProvinciaId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Clientes", "ProvinciaId");
            //AddForeignKey("dbo.Clientes", "ProvinciaId", "dbo.Provincias", "ProvinciaId", cascadeDelete: true);
            //DropColumn("dbo.Provincias", "Cliente_ClienteId");

            AddForeignKey("dbo.Provincias", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Provincias", "Cliente_ClienteId", c => c.Int());
            //DropForeignKey("dbo.Clientes", "ProvinciaId", "dbo.Provincias");
            //DropIndex("dbo.Clientes", new[] { "ProvinciaId" });
            //DropColumn("dbo.Clientes", "ProvinciaId");
            //CreateIndex("dbo.Provincias", "Cliente_ClienteId");
            //AddForeignKey("dbo.Provincias", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
        }
    }
}
