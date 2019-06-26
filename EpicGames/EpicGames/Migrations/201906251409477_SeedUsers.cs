namespace EpicGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4bd0f6d4-ddfd-46ab-b52c-512cc29a1e8b', N'admin@epicgames.com', 0, N'AL9/yhmkDyEPpWZ0IldT7C9f0kZ+k5lpDnOiqxL9r4XA2x4mGQJGzsVvpD25EZIQGQ==', N'5eedb202-71a1-4842-a9d7-e247708a35b6', NULL, 0, 0, NULL, 1, 0, N'admin@epicgames.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c931a539-e64d-4e64-b571-9f9ca08dcd5d', N'guest@epicgames.com', 0, N'AO4S/UTpnBNqUzQ/I68CIyFKkIxJT/3PzfzBPRtdwQDASeMG2EZaYYyFqkdh4Zl1cw==', N'92ce9838-121c-4b7f-ba5c-5a391773d2b9', NULL, 0, 0, NULL, 1, 0, N'guest@epicgames.com')

        
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'230d5920-ba6c-4821-8d42-e93948e41b90', N'CanManageAccounts')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4bd0f6d4-ddfd-46ab-b52c-512cc29a1e8b', N'230d5920-ba6c-4821-8d42-e93948e41b90')


        ");
        }
        
        public override void Down()
        {
        }
    }
}
