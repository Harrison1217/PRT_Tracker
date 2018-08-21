namespace PRT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeMMtodouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PrtScores", "MM", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PrtScores", "MM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
