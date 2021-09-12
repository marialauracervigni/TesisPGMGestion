namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class provinci : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Provincias", "Cliente_ClienteId", "dbo.Clientes");
            //DropColumn("dbo.Provincias", "Cliente_ClienteId");
            //AddForeignKey("dbo.Provincias", "Cliente_ClienteId", "dbo.Clientes", "ProvinciaId", cascadeDelete: true);
            //DropForeignKey("dbo.Clientes", "ProvinciaId", "dbo.Provincias");
            //DropIndex("dbo.Clientes", new[] { "ProvinciaId" });
            AddColumn("dbo.Provincias", "Cliente_ClienteId", c => c.Int());
            CreateIndex("dbo.Provincias", "Cliente_ClienteId");
            AddForeignKey("dbo.Provincias", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
        }

        public override void Down()
        {
        }
    }
}
