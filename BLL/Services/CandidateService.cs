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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BLL.Services
{
    public class CandidateService : ICandidateService
    {
        public const string DocumentsUrlFolder = "/documents/";
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CandidateService(IUnitOfWork db, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public void AddCandidate(CandidateDTO formData)
        {
            var candidate = _mapper.Map<Candidate>(formData);
            candidate.RegDate = DateTime.Now;
            _db.Candidates.Save(candidate);
            _db.Save();
        }

        public async void SaveCV(AddFileDTO model)
        {
            var candidate = GetCandidateDALById(model.CandidateId);

            if (model.AddedFile != null)
            {
                var webPath = _webHostEnvironment.WebRootPath;

                var path = Path.Combine(webPath, "documents");
                if (Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var pathTo = Path.Combine(path, $"{model.CandidateId}.pdf");

                using (var fileStream = new FileStream(pathTo, FileMode.OpenOrCreate))
                {
                    await model.AddedFile.CopyToAsync(fileStream);
                }
                
                candidate.FileUrl = $"{DocumentsUrlFolder}{model.CandidateId}.pdf";
            }

            _db.Candidates.Save(candidate);
            _db.Save();
        }

        public string GetDocumentUrl(int candidateId)
        {
            var documentUrl = _db.Candidates.Get(candidateId)?.FileUrl;
            return !string.IsNullOrWhiteSpace(documentUrl)
                ? documentUrl
                : "";
        }

        public void DeleteCandidate(int id)
        {
            var candidate = _db.Candidates.Get(id);
            _db.Candidates.Remove(candidate);
            _db.Save();
        }

        public List<CandidateDTOForGetAll> GetAllCandidatesWithStatuses()
        {
            var result = GetAllCandidatesWithStatusesInformation().ToList();
            result.ForEach(x => x.SandboxCount = GetCountOfSandboxes(x.ID));
            return result;
        }

        public List<CandidateDTO> GetAllCandidates()
        {
            return _mapper.Map<List<Candidate>, List<CandidateDTO>>(_db.Candidates.GetAll().ToList());
        }

        public CandidateDTO GetCandidateByIdWithStatuses(int id)
        {
            var result = GetCandidatesWithStatusesInformation().FirstOrDefault(x => x.ID == id);
            result.SandboxCount = GetCountOfSandboxes(result.ID);
            return result;
        }
        public CandidateDTO GetCandidateById(int id)
        {
            return _mapper.Map<Candidate, CandidateDTO>(_db.Candidates.Get(id));
        }

        public Candidate GetCandidateDALById(int candidateId)
        {
            return _db.Candidates.Get(candidateId);
        }

        private int GetCountOfSandboxes(int candidateID)
        {
            return _db.CandidatesSandboxes.GetAll().Where(x => x.CandidateID == candidateID).Count();
        }

        private int GetCountOfInterviewes(int candidateID)
        {
            return _db.Interviews.GetAll().Where(interv => interv.CandidateID == candidateID).Count();
        }

        private IQueryable<CandidateDTO> GetCandidatesWithStatusesInformation()
        {
            return _db.CandidatesSandboxes.FindWithSpecificationPattern(new CandidateForHRSpecification())
                .Select(x => new CandidateDTO
                {
                    ID = x.CandidateID,
                    Status = x.Status.Name,
                    FirstName = x.Candidate.FirstName,
                    LastName = x.Candidate.LastName,
                    Email = x.Candidate.Email,
                    Phone = x.Candidate.Phone,
                    Skype = x.Candidate.Skype,
                    SpecializationID = x.Candidate.SpecializationID,
                    CityID = x.Candidate.CityID,
                    EnglishLevelID = x.Candidate.EnglishLevelID,
                    IsInterviewedByHR = x.Candidate.Interviews.Count() > 0,
                    IsInterviewedByTech = x.Candidate.Interviews.Count() > 1,
                });
        }

        private IQueryable<CandidateDTOForGetAll> GetAllCandidatesWithStatusesInformation()
        {
            return _db.CandidatesSandboxes.FindWithSpecificationPattern(new CandidateForHRSpecification())
                .Select(x => new CandidateDTOForGetAll
                {
                    ID = x.CandidateID,
                    Status = x.Status.Name,
                    FirstName = x.Candidate.FirstName,
                    LastName = x.Candidate.LastName,
                    IsInterviewedByHR = x.Candidate.Interviews.Count() > 0,
                    IsInterviewedByTech = x.Candidate.Interviews.Count() > 1,
                });
        }

        public IEnumerable<CandidateDTO> GetCandidatesFromTeam(int teamId)
        {
            return _mapper.Map<IEnumerable<Candidate>, IEnumerable<CandidateDTO>>(_db.Candidates.FindWithSpecificationPattern(new CandidatesForMentorSpecification(teamId)));
        }

        public IEnumerable<CandidateDTO> FindCandidates(string textSearch)
        {
            return _mapper.Map<IEnumerable<Candidate>, IEnumerable<CandidateDTO>>(_db.Candidates.FindWithSpecificationPattern(new CandidatesSearchByAdmin(textSearch)));
        }

        public IEnumerable<CandidateForTechDTO> GetAllCandidatesWithHrInterview()
        {
            return _db.CandidatesSandboxes.FindWithSpecificationPattern(new CandidateForHRSpecification())
                .Select(x => new CandidateForTechDTO
                {
                    Id = x.CandidateID,
                    FirstName = x.Candidate.FirstName,
                    LastName = x.Candidate.LastName,
                    IsInterviewedByHR = x.Candidate.Interviews.Count() > 0,
                    IsInterviewedByTech = x.Candidate.Interviews.Count() > 1,
                });
        }
    }
}