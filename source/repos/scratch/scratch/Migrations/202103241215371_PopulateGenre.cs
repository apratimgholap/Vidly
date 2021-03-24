namespace scratch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO GENRES (type) VALUES ('Comedy')");
            Sql("INSERT INTO GENRES (type) VALUES ('Action')");
            Sql("INSERT INTO GENRES (type) VALUES ('Family')");
            Sql("INSERT INTO GENRES (type) VALUES ('Romance')");

        }
        
        public override void Down()
        {
        }
    }
}
