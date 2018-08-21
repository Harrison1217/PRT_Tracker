namespace PRT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mmandsschangevaluetype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PrtScores", "MM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PrtScores", "SS", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PrtScores", "RunTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PrtScores", "RunTime", c => c.String(nullable: false));
            AlterColumn("dbo.PrtScores", "SS", c => c.Double(nullable: false));
            AlterColumn("dbo.PrtScores", "MM", c => c.Double(nullable: false));
        }
    }
}
