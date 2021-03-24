namespace scratch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populate_NameField_For_MembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' Where ID = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' Where ID = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' Where ID = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Annual' Where ID = 4");
        }
        
        public override void Down()
        {
        }
    }
}
