namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pr2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "ProvinciaId", "dbo.Provincias");
            DropIndex("dbo.Clientes", new[] { "ProvinciaId" });
            RenameColumn(table: "dbo.Clientes", name: "ProvinciaId", newName: "Provincia_ProvinciaId");
            AddColumn("dbo.Provincias", "Cliente_ClienteId", c => c.Int());
            AlterColumn("dbo.Clientes", "Provincia_ProvinciaId", c => c.Int());
            CreateIndex("dbo.Clientes", "Provincia_ProvinciaId");
            CreateIndex("dbo.Provincias", "Cliente_ClienteId");
            AddForeignKey("dbo.Provincias", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
            AddForeignKey("dbo.Clientes", "Provincia_ProvinciaId", "dbo.Provincias", "ProvinciaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "Provincia_ProvinciaId", "dbo.Provincias");
            DropForeignKey("dbo.Provincias", "Cliente_ClienteId", "dbo.Clientes");
            DropIndex("dbo.Provincias", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.Clientes", new[] { "Provincia_ProvinciaId" });
            AlterColumn("dbo.Clientes", "Provincia_ProvinciaId", c => c.Int(nullable: false));
            DropColumn("dbo.Provincias", "Cliente_ClienteId");
            RenameColumn(table: "dbo.Clientes", name: "Provincia_ProvinciaId", newName: "ProvinciaId");
            CreateIndex("dbo.Clientes", "ProvinciaId");
            AddForeignKey("dbo.Clientes", "ProvinciaId", "dbo.Provincias", "ProvinciaId", cascadeDelete: true);
        }
    }
}
