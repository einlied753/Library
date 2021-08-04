namespace Library.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDateofBirth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DateofBirth", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DateofBirth");
        }
    }
}
