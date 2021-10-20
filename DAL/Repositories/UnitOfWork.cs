using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private InternshipDbContext context;

        private BaseRepository<Candidate> candidateRep;
        private BaseRepository<CandidateTeam> candidateTeamsRep;
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
            context = new InternshipDbContext(options);
        }

        public BaseRepository<Candidate> CandidateRep
        {
            get
            {

                if (this.candidateRep == null)
                {
                    this.candidateRep = new CandidateRepository(context);
                }
                return candidateRep;
            }
        }
        public BaseRepository<CandidateTeam> CandidateTeamsRep
        {
            get
            {

                if (this.candidateTeamsRep == null)
                {
                    this.candidateTeamsRep = new CandidateTeamRepository(context);
                }
                return candidateTeamsRep;
            }
        }
        public BaseRepository<Employee> EmployeeRep
        {
            get
            {
                if (this.employeeRep == null)
                {
                    this.employeeRep = new EmployeeRepository(context);
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
                    this.employeeStacksRep = new EmployeeStackRepository(context);
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
                    this.internshipTeamsRep = new InternshipTeamRepository(context);
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
                    this.interviewRep = new InterviewRepository(context);
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
                    this.interviewResultRep = new InterviewResultsRepository(context);
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
                    this.stackRep = new StackRepository(context);
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
                    this.teamMentorRep = new TeamMentorRepository(context);
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
                    this.topicRep = new TopicRepository(context);
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
                    this.topicStackRep = new TopicStackRepository(context);
                }
                return topicStackRep;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
