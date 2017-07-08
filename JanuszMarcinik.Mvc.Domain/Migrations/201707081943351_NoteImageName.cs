namespace JanuszMarcinik.Mvc.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoteImageName : DbMigration
    {
        public override void Up()
        {
            AddColumn("TurtleBarrel.NoteImages", "Name", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("TurtleBarrel.NoteImages", "Name");
        }
    }
}
