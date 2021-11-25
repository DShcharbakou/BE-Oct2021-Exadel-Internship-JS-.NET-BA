using System.Collections.Generic;
using DAL.Models;
using DAL.Repositories;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using System.Linq;
using System;
using System.Collections;
using System.Text.RegularExpressions;
using DAL.Repositories.Specifications;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BLL.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;

        public CandidateService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void AddCandidate(CandidateDTO formData)
        {
            var candidate = _mapper.Map<Candidate>(formData);
            _db.Candidates.Save(candidate);
            _db.Save();
        }

        public void DeleteCandidate(int id)
        {
            var candidate = _db.Candidates.Get(id);
            _db.Candidates.Remove(candidate);
            _db.Save();
        }

        public List<CandidateDTO> GetAllCandidates()
        {
            return GetCandidatesWithStatusesInformation();
        }

        public List<CandidateDTO> GetAllCandidatesWithoutStatuses()
        {
            return _mapper.Map<List<Candidate>, List<CandidateDTO>>(_db.Candidates.GetAll());
        }

        public CandidateDTO GetCandidateById(int id)
        {
            return GetCandidateWithStatusesInformation(id);
        }
        public CandidateDTO GetCandidateByIdWithoutStatuses(int id)
        {
            return _mapper.Map<Candidate, CandidateDTO>(_db.Candidates.Get(id));
        }

        public int GetCountOfSandboxes(int candidateID)
        {
            return _db.Candidates.Get(candidateID).CandidateSandboxes.Count();
        }
        public int GetCountOfInterviewes(int candidateID)
          {
              return _db.Interviews.GetAll().Where(interv => interv.CandidateID == candidateID).Count();
          }

        public List<CandidateDTO> GetCandidatesWithStatusesInformation()
        {
            return _db.CandidatesSandboxes.FindWithSpecificationPattern(new CandidateForHRSpecification(null)).GroupBy(x => new { x.CandidateID, x.StatusID })
                .Select(x => new CandidateDTO
                {
                    ID = x.Key.CandidateID,
                    Status = x.First().Status.Name,
                    FirstName = x.First().Candidate.FirstName,
                    LastName = x.First().Candidate.LastName,
                    Email = x.First().Candidate.Email,
                    Phone = x.First().Candidate.Phone,
                    Skype = x.First().Candidate.Skype,
                    SpecializationID = x.First().Candidate.SpecializationID,
                    CityID = x.First().Candidate.CityID,
                    EnglishLevelID = x.First().Candidate.EnglishLevelID,
                    IsInterviewedByHR = x.First().Candidate.Interviews.Count() > 0,
                    IsInterviewedByTech = x.First().Candidate.Interviews.Count() > 1,
                    SandboxCount = x.Count(),
                }).ToList();
        }

        public CandidateDTO GetCandidateWithStatusesInformation(int candidateId)
        {
            CandidateDTO result = _db.CandidatesSandboxes.FindWithSpecificationPattern(new CandidateForHRSpecification(candidateId)).GroupBy(x => new { x.CandidateID, x.StatusID })
                .Select(x => new CandidateDTO
                {
                    ID = x.Key.CandidateID,
                    Status = x.First().Status.Name,
                    FirstName = x.First().Candidate.FirstName,
                    LastName = x.First().Candidate.LastName,
                    Email = x.First().Candidate.Email,
                    Phone = x.First().Candidate.Phone,
                    Skype = x.First().Candidate.Skype,
                    SpecializationID = x.First().Candidate.SpecializationID,
                    CityID = x.First().Candidate.CityID,
                    EnglishLevelID = x.First().Candidate.EnglishLevelID,
                    IsInterviewedByHR = x.First().Candidate.Interviews.Count() > 0,
                    IsInterviewedByTech = x.First().Candidate.Interviews.Count() > 1,
                    SandboxCount = x.Count(),
                }).FirstOrDefault();
            return result;
        }

        public IEnumerable<CandidateDTO> GetCandidatesFromTeam(int teamId)
        {
            return _mapper.Map<IEnumerable<Candidate>, IEnumerable<CandidateDTO>>(_db.Candidates.FindWithSpecificationPattern(new CandidatesForMentorSpecification(teamId)));
        }

    }
}