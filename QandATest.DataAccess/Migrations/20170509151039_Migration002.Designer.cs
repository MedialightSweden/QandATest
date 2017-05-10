using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using QandATest.DataAccess;

namespace QandATest.DataAccess.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20170509151039_Migration002")]
    partial class Migration002
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QandATest.DomainEntities.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdTitle")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("CooperationType")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("Deadline");

                    b.Property<string>("DutyDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("EmployerAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("EmployerCompany")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("EmployerDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("EmployerEmail")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("EmployerPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("EmployerWebsite")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SkillDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("Id");

                    b.ToTable("Advertisement","dbo");
                });

            modelBuilder.Entity("QandATest.DomainEntities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerText")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("AnswerTypeId");

                    b.Property<int>("NextQuestion");

                    b.Property<int>("QuestionnaireId");

                    b.HasKey("Id");

                    b.HasIndex("AnswerTypeId");

                    b.HasIndex("QuestionnaireId");

                    b.ToTable("Answer","dbo");
                });

            modelBuilder.Entity("QandATest.DomainEntities.AnswerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerTypeText")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AnswerType","dbo");
                });

            modelBuilder.Entity("QandATest.DomainEntities.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdId");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.ToTable("Application","dbo");
                });

            modelBuilder.Entity("QandATest.DomainEntities.Duty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdId");

                    b.Property<string>("DutyTitle")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.ToTable("Duty","dbo");
                });

            modelBuilder.Entity("QandATest.DomainEntities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDependent");

                    b.Property<int>("QTypeId");

                    b.Property<string>("QuestionTitle")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.HasIndex("QTypeId");

                    b.ToTable("Question","dbo");
                });

            modelBuilder.Entity("QandATest.DomainEntities.Questionnaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdId");

                    b.Property<short>("Order");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Questionnaire","dbo");
                });

            modelBuilder.Entity("QandATest.DomainEntities.QuestionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("QTypeTitle")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("QuestionType","dbo");
                });

            modelBuilder.Entity("QandATest.DomainEntities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdId");

                    b.Property<string>("SkillTitle")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.ToTable("Skill","dbo");
                });

            modelBuilder.Entity("QandATest.DomainEntities.Answer", b =>
                {
                    b.HasOne("QandATest.DomainEntities.AnswerType", "AnswerType")
                        .WithMany()
                        .HasForeignKey("AnswerTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QandATest.DomainEntities.Questionnaire", "Questionnaire")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionnaireId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QandATest.DomainEntities.Application", b =>
                {
                    b.HasOne("QandATest.DomainEntities.Advertisement", "Advertisement")
                        .WithMany()
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QandATest.DomainEntities.Duty", b =>
                {
                    b.HasOne("QandATest.DomainEntities.Advertisement", "Ad")
                        .WithMany()
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QandATest.DomainEntities.Question", b =>
                {
                    b.HasOne("QandATest.DomainEntities.QuestionType", "QType")
                        .WithMany()
                        .HasForeignKey("QTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QandATest.DomainEntities.Questionnaire", b =>
                {
                    b.HasOne("QandATest.DomainEntities.Advertisement", "Advertisement")
                        .WithMany()
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QandATest.DomainEntities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QandATest.DomainEntities.Skill", b =>
                {
                    b.HasOne("QandATest.DomainEntities.Advertisement", "Ad")
                        .WithMany()
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
