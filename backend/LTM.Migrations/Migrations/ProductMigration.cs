using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Migrations.Migrations
{
    [Migration(2017092823121512)]
    public class ProductMigration : Migration
    {
        public override void Down()
        {
            Delete.Table("Products");
        }

        public override void Up()
        {
            Create.Table("Products")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsAnsiString(400)
                .WithColumn("Description").AsAnsiString(100)
                .WithColumn("Price").AsDecimal(12, 2);

            Insert.IntoTable("Products")
                .Row(new { Name = "Samsung Galaxy J5", Description = "Smartphone Samsung Galaxy J5", Price = 699.9 })
                .Row(new { Name = "Samsung Galaxy J7", Description = "Smartphone Samsung Galaxy J7", Price = 1299.9 })
                .Row(new { Name = "Moto G 5", Description = "Smartphone Moto G 5", Price = 999.9 })
                .Row(new { Name = "Lenovo Vibe K6", Description = "Smartphone Lenovo Vibe K6", Price = 649.9 })
                .Row(new { Name = "IPhone 7", Description = "Apple IPhone 7", Price = 2699.9 });
        }
    }
}
