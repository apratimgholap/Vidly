namespace scratch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Genre_Field_To_Movie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GenreId = c.Byte(nullable: false),
                        genre_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.genre_id)
                .Index(t => t.genre_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "genre_id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genre_id" });
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
        }
    }
}
