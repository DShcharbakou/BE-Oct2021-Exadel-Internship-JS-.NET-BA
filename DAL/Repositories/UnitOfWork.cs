using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InternshipDbContext internshipDbContext;

        private BaseRepository<Candidate> candidateRep;
        private BaseRepository<Employee> employeeRep;
        private BaseRepository<InternshipTeam> internshipTeamsRep;
        private BaseRepository<Interview> interviewRep;
        private BaseRepository<Skill> skillRep;
        private BaseRepository<Topic> topicRep;
        private BaseRepository<Specialization> specializationRep;
        private BaseRepository<EnglishLevel> englishLevelRep;
        private BaseRepository<Country> countryRep;
        private BaseRepository<City> cityRep;

        public UnitOfWork(DbContextOptions options)
        {
            internshipDbContext = new InternshipDbContext(options);
        }


        //---------------------------------------------
        public BaseRepository<Candidate> Candidates
        {
            get
            {

                if (this.candidateRep == null)
                {
                    this.candidateRep = new BaseRepository<Candidate>(internshipDbContext);
                }
                return candidateRep;
            }
        }
       
        public BaseRepository<Employee> Employees
        {
            get
            {
                if (this.employeeRep == null)
                {
                    this.employeeRep = new BaseRepository<Employee>(internshipDbContext);
                }
                return employeeRep;
            }
        }
        
        public BaseRepository<InternshipTeam> InternshipTeams
        {
            get
            {
                if (this.internshipTeamsRep == null)
                {
                    this.internshipTeamsRep = new BaseRepository<InternshipTeam>(internshipDbContext);
                }
                return internshipTeamsRep;
            }
        }
        public BaseRepository<Interview> Interviews
        {
            get
            {

                if (this.interviewRep == null)
                {
                    this.interviewRep = new BaseRepository<Interview>(internshipDbContext);
                }
                return interviewRep;
            }
        }
        
        public BaseRepository<Skill> Skills
        {
            get
            {

                if (this.skillRep == null)
                {
                    this.skillRep = new BaseRepository<Skill>(internshipDbContext);
                }
                return skillRep;
            }
        }
        public BaseRepository<Topic> Topics
        {
            get
            {

                if (this.topicRep == null)
                {
                    this.topicRep = new BaseRepository<Topic>(internshipDbContext);
                }
                return topicRep;
            }
        }
        public BaseRepository<Specialization> Specializations
        {
            get
            {

                if (this.specializationRep == null)
                {
                    this.specializationRep = new BaseRepository<Specialization>(internshipDbContext);
                }
                return specializationRep;
            }
        }
        public BaseRepository<EnglishLevel> EnglishLevels
        {
            get
            {

                if (this.englishLevelRep == null)
                {
                    this.englishLevelRep = new BaseRepository<EnglishLevel>(internshipDbContext);
                }
                return englishLevelRep;
            }
        }
        public BaseRepository<Country> Countries
        {
            get
            {

                if (this.countryRep == null)
                {
                    this.countryRep = new BaseRepository<Country>(internshipDbContext);
                }
                return countryRep;
            }
        }
        public BaseRepository<City> Cities
        {
            get
            {

                if (this.cityRep == null)
                {
                    this.cityRep = new BaseRepository<City>(internshipDbContext);
                }
                return cityRep;
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
