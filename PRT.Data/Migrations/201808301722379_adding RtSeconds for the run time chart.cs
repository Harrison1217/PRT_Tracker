namespace PRT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingRtSecondsfortheruntimechart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PrtScores", "RtSeconds", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PrtScores", "RtSeconds");
        }
    }
}
