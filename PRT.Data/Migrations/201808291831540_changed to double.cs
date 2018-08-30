namespace PRT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtodouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PrtScores", "NumPushups", c => c.Double(nullable: false));
            AlterColumn("dbo.PrtScores", "NumSitUps", c => c.Double(nullable: false));
            AlterColumn("dbo.PrtScores", "SS", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PrtScores", "SS", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PrtScores", "NumSitUps", c => c.Int(nullable: false));
            AlterColumn("dbo.PrtScores", "NumPushups", c => c.Int(nullable: false));
        }
    }
}
