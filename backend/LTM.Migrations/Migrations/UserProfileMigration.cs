using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Migrations.Migrations
{
    [Migration(20170928221520)]
    public class UserProfileMigration : Migration
    {
        public override void Down()
        {
            Delete.Table("UserProfile");
        }

        public override void Up()
        {
            Create.Table("UserProfile")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsAnsiString(255).NotNullable()
                .WithColumn("Login").AsAnsiString(80).NotNullable()
                .WithColumn("Password").AsAnsiString(1000).NotNullable()
                .WithColumn("Token").AsAnsiString(4000).Nullable()
                .WithColumn("ExpiresOn").AsDateTime().Nullable();


            Insert.IntoTable("UserProfile")
                .Row(new { Name = "Tiago dos Santos", Login = "Tiago", Password = "Tiago" });
        }
    }
}
