using FluentMigrator;

namespace MShop.DataLayer.NHibernate.Migrations.Migrations
{
	[Migration(3)]
	public class _3_Alter : Migration
	{
		public override void Down()
		{
            Alter.Table("Departments").AlterColumn("ImageUrl").AsString().NotNullable();
        }

        public override void Up()
        {
            Alter.Table("Departments").AlterColumn("ImageUrl").AsString().Nullable();
        }
    }
}
