using FluentMigrator;

namespace Dotnet.Dapper.Postgres.Infrastructure.Migrations;

[Migration(202603310001)]
public sealed class InitialCustomerOrderSchema : Migration
{
    public override void Up()
    {
        Create.Table("customers")
            .WithColumn("customer_id").AsInt32().PrimaryKey().Identity()
            .WithColumn("first_name").AsString(50).NotNullable()
            .WithColumn("last_name").AsString(50).NotNullable()
            .WithColumn("email").AsString(100).Nullable().Unique()
            .WithColumn("phone").AsString(20).Nullable()
            .WithColumn("created_at").AsDateTimeOffset().NotNullable()
                .WithDefault(SystemMethods.CurrentUTCDateTime);

        Create.Table("orders")
            .WithColumn("order_id").AsInt32().PrimaryKey().Identity()
            .WithColumn("customer_id").AsInt32().NotNullable()
            .WithColumn("created_at").AsDateTimeOffset().NotNullable()
                .WithDefault(SystemMethods.CurrentUTCDateTime)
            .WithColumn("total_amount").AsDecimal(10, 2).NotNullable();

        Create.ForeignKey("fk_customer")
            .FromTable("orders").ForeignColumn("customer_id")
            .ToTable("customers").PrimaryColumn("customer_id")
            .OnDelete(System.Data.Rule.None)
            .OnUpdate(System.Data.Rule.Cascade);

        Create.Index("idx_orders_customer_id_created_at")
            .OnTable("orders")
            .OnColumn("customer_id").Ascending()
            .OnColumn("created_at").Ascending();
    }

    public override void Down()
    {
        Delete.Index("idx_orders_customer_id_created_at").OnTable("orders");
        Delete.ForeignKey("fk_customer").OnTable("orders");
        Delete.Table("orders");
        Delete.Table("customers");
    }
}

