using Microsoft.EntityFrameworkCore;
using System;

namespace QandATest.DataAccess
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }

        public DbSet<QandATest.DomainEntities.Advertisement> Advertisement { get; set; }
        public DbSet<QandATest.DomainEntities.Question> Question { get; set; }
        public DbSet<QandATest.DomainEntities.QuestionType> QuestionType { get; set; }
        public DbSet<QandATest.DomainEntities.Skill> Skill { get; set; }
        public DbSet<QandATest.DomainEntities.Duty> Duty { get; set; }
        public DbSet<QandATest.DomainEntities.Questionnaire> Questionnaire { get; set; }
        public DbSet<QandATest.DomainEntities.Application> Application { get; set; }
        public DbSet<QandATest.DomainEntities.Answer> Answer { get; set; }
        public DbSet<QandATest.DomainEntities.AnswerType> AnswerType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
