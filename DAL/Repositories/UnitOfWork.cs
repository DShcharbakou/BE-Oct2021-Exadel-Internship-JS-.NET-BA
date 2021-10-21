using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly InternshipDbContext internshipDbContext;

        private BaseRepository<Candidate> candidateRep;
        private BaseRepository<CandidateSandbox> candidateSandboxRep;
        private BaseRepository<Employee> employeeRep;
        private BaseRepository<EmployeeStack> employeeStacksRep;
        private BaseRepository<InternshipTeam> internshipTeamsRep;
        private BaseRepository<Interview> interviewRep;
        private BaseRepository<InterviewResult> interviewResultRep;
        private BaseRepository<Stack> stackRep;
        private BaseRepository<TeamMentor> teamMentorRep;
        private BaseRepository<Topic> topicRep;
        private BaseRepository<TopicStack> topicStackRep;


        public UnitOfWork(DbContextOptions options)
        {
            internshipDbContext = new InternshipDbContext(options);
        }

        public BaseRepository<Candidate> CandidateRep
        {
            get
            {

                if (this.candidateRep == null)
                {
                    this.candidateRep = new CandidateRepository(internshipDbContext);
                }
                return candidateRep;
            }
        }
        public BaseRepository<CandidateSandbox> CandidateTeamsRep
        {
            get
            {

                if (this.candidateSandboxRep == null)
                {
                    this.candidateSandboxRep = new CandidateSandboxRepository(internshipDbContext);
                }
                return candidateSandboxRep;
            }
        }
        public BaseRepository<Employee> EmployeeRep
        {
            get
            {
                if (this.employeeRep == null)
                {
                    this.employeeRep = new EmployeeRepository(internshipDbContext);
                }
                return employeeRep;
            }
        }
        public BaseRepository<EmployeeStack> EmployeeStacksRep
        {
            get
            {

                if (this.employeeStacksRep == null)
                {
                    this.employeeStacksRep = new EmployeeStackRepository(internshipDbContext);
                }
                return employeeStacksRep;
            }
        }
        public BaseRepository<InternshipTeam> InternshipTeamsRep
        {
            get
            {
                if (this.internshipTeamsRep == null)
                {
                    this.internshipTeamsRep = new InternshipTeamRepository(internshipDbContext);
                }
                return internshipTeamsRep;
            }
        }
        public BaseRepository<Interview> InterviewRep
        {
            get
            {

                if (this.interviewRep == null)
                {
                    this.interviewRep = new InterviewRepository(internshipDbContext);
                }
                return interviewRep;
            }
        }
        public BaseRepository<InterviewResult> InterviewResultRep
        {
            get
            {

                if (this.interviewResultRep == null)
                {
                    this.interviewResultRep = new InterviewResultsRepository(internshipDbContext);
                }
                return interviewResultRep;
            }
        }
        public BaseRepository<Stack> StackRep
        {
            get
            {

                if (this.stackRep == null)
                {
                    this.stackRep = new StackRepository(internshipDbContext);
                }
                return stackRep;
            }
        }
        public BaseRepository<TeamMentor> TeamMentorRep
        {
            get
            {

                if (this.teamMentorRep == null)
                {
                    this.teamMentorRep = new TeamMentorRepository(internshipDbContext);
                }
                return teamMentorRep;
            }
        }
        public BaseRepository<Topic> TopicRep
        {
            get
            {

                if (this.topicRep == null)
                {
                    this.topicRep = new TopicRepository(internshipDbContext);
                }
                return topicRep;
            }
        }
        public BaseRepository<TopicStack> TopicStackRep
        {
            get
            {

                if (this.topicStackRep == null)
                {
                    this.topicStackRep = new TopicStackRepository(internshipDbContext);
                }
                return topicStackRep;
            }
        }
        public void Save()
        {
            internshipDbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    internshipDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
