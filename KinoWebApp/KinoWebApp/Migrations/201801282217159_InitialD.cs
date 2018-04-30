namespace KinoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        IDF = c.Int(nullable: false, identity: true),
                        TYTUL = c.String(nullable: false),
                        REZYSER = c.String(nullable: false),
                        DLUGOSC = c.Int(nullable: false),
                        ID_GAT = c.Int(),
                        IDK = c.Int(),
                    })
                .PrimaryKey(t => t.IDF)
                .ForeignKey("dbo.Gatuneks", t => t.ID_GAT)
                .ForeignKey("dbo.Kategorias", t => t.IDK)
                .Index(t => t.ID_GAT)
                .Index(t => t.IDK);
            
            CreateTable(
                "dbo.Gatuneks",
                c => new
                    {
                        ID_GAT = c.Int(nullable: false, identity: true),
                        NAZWA = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID_GAT);
            
            CreateTable(
                "dbo.Kategorias",
                c => new
                    {
                        IDK = c.Int(nullable: false, identity: true),
                        NAZWA = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDK);
            
            CreateTable(
                "dbo.Seanses",
                c => new
                    {
                        IDS = c.Int(nullable: false, identity: true),
                        IDF = c.Int(nullable: false),
                        NR_SALI = c.Int(nullable: false),
                        TERMIN = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDS)
                .ForeignKey("dbo.Films", t => t.IDF, cascadeDelete: true)
                .ForeignKey("dbo.Salas", t => t.NR_SALI, cascadeDelete: true)
                .Index(t => t.IDF)
                .Index(t => t.NR_SALI);
            
            CreateTable(
                "dbo.Salas",
                c => new
                    {
                        NR_SALI = c.Int(nullable: false, identity: true),
                        ILE_MIEJSC = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NR_SALI);
            
            CreateTable(
                "dbo.Miejsces",
                c => new
                    {
                        IDM = c.Int(nullable: false, identity: true),
                        NR_SALI = c.Int(nullable: false),
                        NR_MIEJSCA = c.Int(nullable: false),
                        CENA = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IDM)
                .ForeignKey("dbo.Salas", t => t.NR_SALI, cascadeDelete: true)
                .Index(t => t.NR_SALI);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seanses", "NR_SALI", "dbo.Salas");
            DropForeignKey("dbo.Miejsces", "NR_SALI", "dbo.Salas");
            DropForeignKey("dbo.Seanses", "IDF", "dbo.Films");
            DropForeignKey("dbo.Films", "IDK", "dbo.Kategorias");
            DropForeignKey("dbo.Films", "ID_GAT", "dbo.Gatuneks");
            DropIndex("dbo.Miejsces", new[] { "NR_SALI" });
            DropIndex("dbo.Seanses", new[] { "NR_SALI" });
            DropIndex("dbo.Seanses", new[] { "IDF" });
            DropIndex("dbo.Films", new[] { "IDK" });
            DropIndex("dbo.Films", new[] { "ID_GAT" });
            DropTable("dbo.Miejsces");
            DropTable("dbo.Salas");
            DropTable("dbo.Seanses");
            DropTable("dbo.Kategorias");
            DropTable("dbo.Gatuneks");
            DropTable("dbo.Films");
        }
    }
}
