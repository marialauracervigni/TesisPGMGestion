namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Listas1 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Provincias", "Cliente_ClienteId", "dbo.Clientes");
            //DropIndex("dbo.Provincias", new[] { "Cliente_ClienteId" });
            //DropColumn("dbo.Clientes", "ProvinciaId");
            //RenameColumn(table: "dbo.Clientes", name: "Cliente_ClienteId", newName: "ProvinciaId");
            //CreateIndex("dbo.Clientes", "ProvinciaId");
            //AddForeignKey("dbo.Clientes", "ProvinciaId", "dbo.Provincias", "ProvinciaId", cascadeDelete: true);
            //DropColumn("dbo.Provincias", "Cliente_ClienteId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Provincias", "Cliente_ClienteId", c => c.Int());
            //DropForeignKey("dbo.Clientes", "ProvinciaId", "dbo.Provincias");
            //DropIndex("dbo.Clientes", new[] { "ProvinciaId" });
            //RenameColumn(table: "dbo.Clientes", name: "ProvinciaId", newName: "Cliente_ClienteId");
            //AddColumn("dbo.Clientes", "ProvinciaId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Provincias", "Cliente_ClienteId");
            //AddForeignKey("dbo.Provincias", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
        }
    }
}
