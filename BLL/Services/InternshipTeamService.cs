using System.Collections.Generic;
using DAL.Repositories;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using DAL.Models;
using DAL.Repositories.Specifications;
using System.Linq;

namespace BLL.Services
{
    public class InternshipTeamService : IInternshipTeamService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public InternshipTeamService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void AddInternshipTeam(InternshipTeamDTO teamDto)
        {
            var team = _mapper.Map<InternshipTeam>(teamDto);
            _db.InternshipTeams.Save(team);
            _db.Save();
        }

        public void DeleteInternshipTeam(int id)
        {
            var team = _db.InternshipTeams.Get(id);
            _db.InternshipTeams.Remove(team);
            _db.Save();
        }

        public InternshipTeamDTO GetInternshipTeamById(int id)
        {
            return _mapper.Map<InternshipTeam, InternshipTeamDTO>(_db.InternshipTeams.Get(id));
        }

        public IEnumerable<InternshipTeamDTO> GetList()
        {
            return _mapper.Map<IEnumerable<InternshipTeam>, List<InternshipTeamDTO>>(_db.InternshipTeams.GetAll());
        }

        public InternshipTeamDTO GetInternshipTeamByEmployeeId(int employeeid)
        {
            return _mapper.Map<InternshipTeam, InternshipTeamDTO>(_db.InternshipTeams.FindWithSpecificationPattern(new InternshipSpecification(employeeid)).LastOrDefault());
        }
    }
}
