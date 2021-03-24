namespace scratch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Name_To_MembershipType_And_In_Sql : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
