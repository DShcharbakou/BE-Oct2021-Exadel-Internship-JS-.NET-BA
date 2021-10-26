using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public class InternshipDbContext : DbContext
    {
        public InternshipDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateSandbox> CandidatesSandboxes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeStack> EmployeesStacks { get; set; }
        public DbSet<InternshipTeam> InternshipTeams { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<InterviewResult> InterviewResults { get; set; }
        public DbSet<Stack> Stacks { get; set; }
        public DbSet<TeamMentor> TeamsMentors { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicStack> TopicsStacks { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<EnglishLevel> EnglishLevel { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }



    }
}