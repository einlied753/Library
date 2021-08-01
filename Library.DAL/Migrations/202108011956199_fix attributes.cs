namespace Library.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixattributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Surname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Patronymic", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "DateofBirth", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "DateofBirth", c => c.String(maxLength: 10));
            AlterColumn("dbo.Users", "Patronymic", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Surname", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Books", "Author", c => c.String(maxLength: 50));
            AlterColumn("dbo.Books", "Name", c => c.String(maxLength: 50));
        }
    }
}
