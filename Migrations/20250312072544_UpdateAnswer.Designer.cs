﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace QuizAPI.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    [Migration("20250312072544_UpdateAnswer")]
    partial class UpdateAnswer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Answer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ChoiceId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RecordID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("RecordID");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("QuestionTopic", b =>
                {
                    b.Property<Guid>("QuestionsID")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TopicsID")
                        .HasColumnType("char(36)");

                    b.HasKey("QuestionsID", "TopicsID");

                    b.HasIndex("TopicsID");

                    b.ToTable("QuestionTopic");
                });

            modelBuilder.Entity("QuizAPI.Entities.Choice", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("QuestionID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Choice");
                });

            modelBuilder.Entity("QuizAPI.Entities.Question", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("CorrectChoiceID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("QuizAPI.Entities.Record", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<Guid>("TopicID")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("TopicID");

                    b.ToTable("Record");
                });

            modelBuilder.Entity("QuizAPI.Entities.Topic", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("Answer", b =>
                {
                    b.HasOne("QuizAPI.Entities.Record", "Record")
                        .WithMany("Answers")
                        .HasForeignKey("RecordID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Record");
                });

            modelBuilder.Entity("QuestionTopic", b =>
                {
                    b.HasOne("QuizAPI.Entities.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizAPI.Entities.Topic", null)
                        .WithMany()
                        .HasForeignKey("TopicsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuizAPI.Entities.Choice", b =>
                {
                    b.HasOne("QuizAPI.Entities.Question", "Question")
                        .WithMany("Choices")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizAPI.Entities.Record", b =>
                {
                    b.HasOne("QuizAPI.Entities.Topic", "Topic")
                        .WithMany("Records")
                        .HasForeignKey("TopicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("QuizAPI.Entities.Question", b =>
                {
                    b.Navigation("Choices");
                });

            modelBuilder.Entity("QuizAPI.Entities.Record", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("QuizAPI.Entities.Topic", b =>
                {
                    b.Navigation("Records");
                });
#pragma warning restore 612, 618
        }
    }
}
