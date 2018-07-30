using FluentMigrator;

namespace MShop.DataLayer.NHibernate.Migrations.Migrations
{
	[Migration(2)]
	public class _2_Update : Migration
	{
		public override void Down()
		{
            Alter.Table("Polls").AlterColumn("IsArchived").AsBoolean().NotNullable();
        }

        public override void Up()
        {
            Alter.Table("Polls").AlterColumn("IsArchived").AsBoolean().Nullable();
        }
	}
}
