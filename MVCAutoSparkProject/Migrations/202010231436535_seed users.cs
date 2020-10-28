namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'10543688-ac3b-4dfe-9b14-29aad220ba68', N'guestuser@gmail.com', 0, N'AIvj6nIAIdtn6UhwwfX58irTbJKDYz4spPcXrwSiBDHoOCdFCk0Q5CfmXVYuti3qUA==', N'99bedc21-0203-40a9-b934-99f8b881e3f7', NULL, 0, 0, NULL, 1, 0, N'guestuser@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'18dc8ffc-4047-4f83-9cfa-0c8cfa279436', N'adminuser@gmail.com', 0, N'AIX0KmQ651LiTqy/doVq9hLAMAvFseCG9N3S0ed5/tWDLDnF5MlgXvJfWGqzpV4P+w==', N'993149a9-cc5f-41d4-8dc0-b84e89724480', NULL, 0, 0, NULL, 1, 0, N'adminuser@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b576c81a-a849-444c-975f-9be10a14c888', N'CanManageCustomers')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'18dc8ffc-4047-4f83-9cfa-0c8cfa279436', N'b576c81a-a849-444c-975f-9be10a14c888')

");
        }
        
        public override void Down()
        {
        }
    }
}
