using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CandidateSandboxService : ICandidateSandboxService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;

        public CandidateSandboxService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IEnumerable<CandidateSandboxDTO> GetList()
        {
            return _mapper.Map<IEnumerable<CandidateSandbox>, IEnumerable<CandidateSandboxDTO>>(_db.CandidatesSandboxes.GetAll());
        }

        public CandidateSandboxDTO GetCandidateSandboxById(int id)
        {
            return _mapper.Map<CandidateSandbox, CandidateSandboxDTO>(_db.CandidatesSandboxes.Get(id));
        }

        public void AddGradeAndComment(CandidateSandboxDTO dto)
        {
            var candidateSandbox = _db.CandidatesSandboxes.GetAll().Where(x => x.CandidateID == dto.CandidateID).FirstOrDefault();
            candidateSandbox.CandidateID = dto.CandidateID;
            candidateSandbox.Comment = dto.Comment;
            candidateSandbox.Grade = dto.Grade;
            _db.CandidatesSandboxes.Save(candidateSandbox);
            _db.Save();
        }

        public void SetStatusAfterHrInterview(HRInterviewDTOWithStatus hrInterviewDTOWithStatus)
        {
            var interview = _db.Interviews.FindWithSpecificationPattern(new InterviewStatusSpecification()).FirstOrDefault(x => x.CandidateID == hrInterviewDTOWithStatus.CandidateID);
            var cand = interview.Candidate.CandidateSandboxes.FirstOrDefault(x => x.CandidateID == interview.CandidateID);
            if (cand.StatusID == null)
            {
                cand.StatusID = hrInterviewDTOWithStatus.StatusID;
            }
            else
            {

            }
            _db.CandidatesSandboxes.Save(cand);
            _db.Save();
        }
        public CandidateSandboxDTO GetCandidateSandboxByCandidateId(int candidateId)
         {
           return _mapper.Map<CandidateSandboxDTO>(_db.CandidatesSandboxes.FindWithSpecificationPattern(new CandidateForHRSpecification()).Where(x => x.CandidateID == candidateId).FirstOrDefault());
         }

        public void AddCandidateSandbox(CandidateDTO candidateDto)
        {
            var sandboxDto = _mapper.Map<CandidateSandboxForSetDTO>(candidateDto);
            sandboxDto.SandboxID = _db.Sandboxes.FindWithSpecificationPattern(new SandboxForCandidateSandboxSpecification()).FirstOrDefault().Id;
            var sandbox = _mapper.Map<CandidateSandbox>(sandboxDto);
            _db.CandidatesSandboxes.Save(sandbox);
            _db.Save();
        }

        public void SetStatus(CandidateDTO candidateDto, int statusID)
        {
            var candidateSand = _db.CandidatesSandboxes.FindWithSpecificationPattern(new CandidateSandboxSpecification(candidateDto.ID)).FirstOrDefault();
            candidateSand.StatusID = statusID;
            _db.CandidatesSandboxes.Save(candidateSand);
            _db.Save();
        }
        
    }
    }