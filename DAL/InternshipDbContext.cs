using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL
{
    public class InternshipDbContext : IdentityDbContext<User>
    {
        public InternshipDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateSandbox> CandidatesSandboxes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSkill> EmployeesSkills { get; set; }
        public DbSet<InternshipTeam> InternshipTeams { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<SkillKnowledge> SkillKnowledges { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<TeamMentor> TeamsMentors { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicSkill> TopicsSkills { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<EnglishLevel> EnglishLevel { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InternshipDbContext).Assembly);
        }
    }
}