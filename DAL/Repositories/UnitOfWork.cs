using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly InternshipDbContext internshipDbContext;

        private BaseRepository<Candidate> candidateRep;
        private BaseRepository<Employee> employeeRep;
        private BaseRepository<InternshipTeam> internshipTeamsRep;
        private BaseRepository<Interview> interviewRep;
        private BaseRepository<Stack> stackRep;
        private BaseRepository<Topic> topicRep;


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
