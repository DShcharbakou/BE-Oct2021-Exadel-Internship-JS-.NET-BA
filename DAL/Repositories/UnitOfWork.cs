﻿using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InternshipDbContext internshipDbContext;

        private BaseRepository<Candidate> candidateRep;
        private BaseRepository<CandidateSandbox> candidateSandboxRep;
        private BaseRepository<Employee> employeeRep;
        private BaseRepository<InternshipTeam> internshipTeamsRep;
        private BaseRepository<Interview> interviewRep;
        private BaseRepository<Stack> stackRep;
        private BaseRepository<Topic> topicRep;
        private BaseRepository<TopicStack> topicStackRep;
        private BaseRepository<Specialization> specializationRep;
        private BaseRepository<EnglishLevel> englishLevelRep;
        private BaseRepository<Country> countryRep;
        private BaseRepository<City> cityRep;


        public UnitOfWork(DbContextOptions options)
        {
            internshipDbContext = new InternshipDbContext(options);
        }


        public BaseRepository<Candidate> Candidates
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

        public BaseRepository<Employee> Employees
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

        public BaseRepository<InternshipTeam> InternshipTeams
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
        public BaseRepository<Interview> Interviews
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

        public BaseRepository<Stack> Stacks
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

        public BaseRepository<Topic> Topics
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
        public BaseRepository<Specialization> SpecializationRep
        {
            get
            {

                if (this.specializationRep == null)
                {
                    this.specializationRep = new SpecializationRepository(internshipDbContext);
                }
                return specializationRep;
            }
        }
        public BaseRepository<EnglishLevel> EnglishLevelRep
        {
            get
            {

                if (this.englishLevelRep == null)
                {
                    this.englishLevelRep = new EnglishLevelRepository(internshipDbContext);
                }
                return englishLevelRep;
            }
        }
        public BaseRepository<Country> CountryRep
        {
            get
            {

                if (this.countryRep == null)
                {
                    this.countryRep = new CountryRepository(internshipDbContext);
                }
                return countryRep;
            }
        }
        public BaseRepository<City> CityRep
        {
            get
            {

                if (this.cityRep == null)
                {
                    this.cityRep = new CityRepository(internshipDbContext);
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
