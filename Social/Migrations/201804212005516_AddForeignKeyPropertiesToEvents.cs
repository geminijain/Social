namespace Social.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToEvents : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Events", name: "Organizer_Id", newName: "OrganizerId");
            RenameIndex(table: "dbo.Events", name: "IX_Organizer_Id", newName: "IX_OrganizerId");
            RenameIndex(table: "dbo.Events", name: "IX_Category_Id", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameIndex(table: "dbo.Events", name: "IX_OrganizerId", newName: "IX_Organizer_Id");
            RenameColumn(table: "dbo.Events", name: "OrganizerId", newName: "Organizer_Id");
            RenameColumn(table: "dbo.Events", name: "CategoryId", newName: "Category_Id");
        }
    }
}
