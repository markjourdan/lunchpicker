namespace LunchPicker.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixStateMispelling : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.States", "Abbreviation", c => c.String());
            DropColumn("dbo.States", "Abreviation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.States", "Abreviation", c => c.String());
            DropColumn("dbo.States", "Abbreviation");
        }
    }
}
