﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Subscription_service.Data;

#nullable disable

namespace subscription.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Subscription_service.Models.GatewayRawEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("EventPayload")
                        .HasColumnType("text");

                    b.Property<string>("EventType")
                        .HasColumnType("text");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("gateway_raw_event", (string)null);
                });

            modelBuilder.Entity("Subscription_service.Models.PaymentGateway", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("payment_gateway", (string)null);
                });

            modelBuilder.Entity("Subscription_service.Models.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("Currency")
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("GatewaySubscriptionId")
                        .HasColumnType("text");

                    b.Property<Guid>("PaymentTransactionId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("SubscriptionPlanId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTransactionId")
                        .IsUnique();

                    b.HasIndex("SubscriptionPlanId");

                    b.ToTable("subscription", (string)null);
                });

            modelBuilder.Entity("Subscription_service.Models.SubscriptionPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("CostDisplay")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("FeaturedImage")
                        .HasColumnType("text");

                    b.Property<Guid>("Gateways")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Gateways");

                    b.ToTable("subscription_plan", (string)null);
                });

            modelBuilder.Entity("Subscription_service.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("Currency")
                        .HasColumnType("text");

                    b.Property<string>("ErrorMessage")
                        .HasColumnType("text");

                    b.Property<string>("GatewayOrderId")
                        .HasColumnType("text");

                    b.Property<Guid>("GatewayRawEventId")
                        .HasColumnType("uuid");

                    b.Property<string>("GatewayRefCode")
                        .HasColumnType("text");

                    b.Property<string>("GatewayState")
                        .HasColumnType("text");

                    b.Property<string>("GatewayTransactionId")
                        .HasColumnType("text");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("GatewayRawEventId")
                        .IsUnique();

                    b.ToTable("transaction", (string)null);
                });

            modelBuilder.Entity("Subscription_service.Models.Subscription", b =>
                {
                    b.HasOne("Subscription_service.Models.Transaction", "Transaction")
                        .WithOne("Subscription")
                        .HasForeignKey("Subscription_service.Models.Subscription", "PaymentTransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Subscription_service.Models.SubscriptionPlan", "SubscriptionPlan")
                        .WithMany("Subscriptions")
                        .HasForeignKey("SubscriptionPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubscriptionPlan");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("Subscription_service.Models.SubscriptionPlan", b =>
                {
                    b.HasOne("Subscription_service.Models.PaymentGateway", "PaymentGateway")
                        .WithMany("SubscriptionPlans")
                        .HasForeignKey("Gateways")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentGateway");
                });

            modelBuilder.Entity("Subscription_service.Models.Transaction", b =>
                {
                    b.HasOne("Subscription_service.Models.GatewayRawEvent", "GatewayRawEvent")
                        .WithOne("Transaction")
                        .HasForeignKey("Subscription_service.Models.Transaction", "GatewayRawEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GatewayRawEvent");
                });

            modelBuilder.Entity("Subscription_service.Models.GatewayRawEvent", b =>
                {
                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("Subscription_service.Models.PaymentGateway", b =>
                {
                    b.Navigation("SubscriptionPlans");
                });

            modelBuilder.Entity("Subscription_service.Models.SubscriptionPlan", b =>
                {
                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("Subscription_service.Models.Transaction", b =>
                {
                    b.Navigation("Subscription");
                });
#pragma warning restore 612, 618
        }
    }
}
