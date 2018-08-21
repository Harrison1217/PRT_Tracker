namespace PRT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedruntimetoastring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PrtScores", "RunTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PrtScores", "RunTime", c => c.Time(nullable: false, precision: 7));
        }
    }
}
