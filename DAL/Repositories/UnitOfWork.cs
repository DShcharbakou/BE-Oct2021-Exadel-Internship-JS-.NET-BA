using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InternshipDbContext internshipDbContext;

        private IBaseRepository<Candidate> candidateRep;
        private IBaseRepository<Employee> employeeRep;
        private IBaseRepository<InternshipTeam> internshipTeamsRep;
        private IBaseRepository<Interview> interviewRep;
        private IBaseRepository<Skill> skillRep;
        private IBaseRepository<Topic> topicRep;
        private IBaseRepository<Specialization> specializationRep;
        private IBaseRepository<EnglishLevel> englishLevelRep;
        private IBaseRepository<Country> countryRep;
        private IBaseRepository<City> cityRep;

        public UnitOfWork(DbContextOptions options)
        {
            internshipDbContext = new InternshipDbContext(options);
        }


        //---------------------------------------------
        public IBaseRepository<Candidate> Candidates
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

        public IBaseRepository<Employee> Employees
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

        public IBaseRepository<InternshipTeam> InternshipTeams
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
        public IBaseRepository<Interview> Interviews
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

        public IBaseRepository<Skill> Skills
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
        public IBaseRepository<Topic> Topics
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
        public IBaseRepository<Specialization> Specializations
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
        public IBaseRepository<EnglishLevel> EnglishLevels
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
        public IBaseRepository<Country> Countries
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
        public IBaseRepository<City> Cities
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