namespace scratch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAttributesToMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NoOfStockAvailable", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NoOfStockAvailable");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
