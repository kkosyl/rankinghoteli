namespace RankingHoteli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hotel",
                c => new
                    {
                        HotelID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                        Descritpion = c.String(nullable: false, maxLength: 500),
                        Price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.HotelID);
            
            CreateTable(
                "dbo.Opinion",
                c => new
                    {
                        OpinionID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        HotelID = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        AddDate = c.DateTime(nullable: false, storeType: "date"),
                        LocationGrade = c.Int(nullable: false),
                        FoodGrade = c.Int(nullable: false),
                        ServiceGrade = c.Int(nullable: false),
                        RoomGrade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OpinionID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Nick = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        PictureID = c.Int(nullable: false, identity: true),
                        HotelID = c.Int(nullable: false),
                        Source = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PictureID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Opinion", "UserID", "dbo.User");
            DropIndex("dbo.Opinion", new[] { "UserID" });
            DropTable("dbo.Picture");
            DropTable("dbo.User");
            DropTable("dbo.Opinion");
            DropTable("dbo.Hotel");
        }
    }
}
