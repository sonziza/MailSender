﻿// <auto-generated />
using System;
using MailSender.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MailSender.Migrations
{
    [DbContext(typeof(MailSenderDBContext))]
    partial class MailSenderDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MailSender.lib.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MailSender.lib.Models.Recipient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShedulerTaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShedulerTaskId");

                    b.ToTable("Recipients");
                });

            modelBuilder.Entity("MailSender.lib.Models.Sender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Senders");
                });

            modelBuilder.Entity("MailSender.lib.Models.Server", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<bool>("UseSSL")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("MailSender.lib.Models.ShedulerTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("MessageId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.Property<int?>("ServerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.HasIndex("SenderId");

                    b.HasIndex("ServerId");

                    b.ToTable("ShedulerTasks");
                });

            modelBuilder.Entity("MailSender.lib.Models.Recipient", b =>
                {
                    b.HasOne("MailSender.lib.Models.ShedulerTask", null)
                        .WithMany("Recipients")
                        .HasForeignKey("ShedulerTaskId");
                });

            modelBuilder.Entity("MailSender.lib.Models.ShedulerTask", b =>
                {
                    b.HasOne("MailSender.lib.Models.Message", "Message")
                        .WithMany()
                        .HasForeignKey("MessageId");

                    b.HasOne("MailSender.lib.Models.Sender", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.HasOne("MailSender.lib.Models.Server", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId");

                    b.Navigation("Message");

                    b.Navigation("Sender");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("MailSender.lib.Models.ShedulerTask", b =>
                {
                    b.Navigation("Recipients");
                });
#pragma warning restore 612, 618
        }
    }
}
