namespace Social.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Happy')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'Shanky')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (3, 'Bob')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (4, 'Sean')");

        }

        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE Id is (1,2,3,4)");
        }
    }
}
