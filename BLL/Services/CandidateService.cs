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
           // var result = _mapper.Map(SetStatusInformationForCandidate(), _mapper.Map<Candidate, CandidateDTO>(_db.Candidates.GetAll()));
            return _mapper.Map<IEnumerable<Candidate>, List<CandidateDTO>>(_db.Candidates.GetAll());
        }

        public CandidateDTO GetCandidateById(int id)
        {
            return _mapper.Map<Candidate, CandidateDTO>(_db.Candidates.Get(id));
        }

        public int GetCountOfSandboxes(int candidateID)
        {
            return _db.Candidates.Get(candidateID).CandidateSandboxes.Count();
        }

        public bool IsIntervHR(int id)
        {
            if (this.GetCountOfInterviewes(id) >= 1)
            {
                return true;
            }
            return false;
        }

        public bool IsIntervTech(int id)
        {
            if (this.GetCountOfInterviewes(id) >= 2)
            {
                return true;
            }
            return false;
        }

        public string GetCandidateStatus(int candidateId)
        {
            var statuses = _db.Statuses.FindWithSpecificationPattern(new StatusForCandidateSpecification(candidateId));
            return statuses.FirstOrDefault().Name;
        }

        public int GetCountOfInterviewes(int candidateID)
        {
            return _db.Interviews.GetAll().Where(interv => interv.CandidateID == candidateID).Count();
        }

        public CandidateDTOForStatuses SetStatusInformationForCandidate(int candidateId)
        {
            var candidate = new CandidateDTOForStatuses(candidateId)
            {
                IsInterviewedByHR = this.IsIntervHR(candidateId),
                IsInterviewedByTech = this.IsIntervTech(candidateId),
                SandboxCount = this.GetCountOfSandboxes(candidateId),
                Status = this.GetCandidateStatus(candidateId)
            };
            return candidate;
        }

        public List<CandidateDTOForStatuses> GetCandidatesWithStatuses(int? teamId)
        {
            return _db.CandidatesSandboxes.FindWithSpecificationPattern(new CandidatesWithStatusesSpecification(teamId)).Select(x => new CandidateDTOForStatuses() { ID = x.CandidateID, StatusID = x.StatusID, FirstName = x.Candidate.FirstName }).ToList();

        }
        public IEnumerable<CandidateDTO> GetCandidatesFromTeam(int teamId)
        {
            return _mapper.Map<IEnumerable<Candidate>, IEnumerable<CandidateDTO>>(_db.Candidates.FindWithSpecificationPattern(new CandidatesForMentorSpecification(teamId)));
        }

    }
}