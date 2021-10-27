using System.Collections.Generic;
using DAL.Repositories;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using DAL;
using DAL.Models;

namespace BLL.Services
{
    public class InternshipTeamService : IInternshipTeamService
    {
        private readonly IUnitOfWork _internshipTeamRep;

        public InternshipTeamService(IUnitOfWork team)
        {
            _internshipTeamRep = team;
        }

        public void AddInternshipTeam(InternshipTeamDTO teamDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InternshipTeamDTO, InternshipTeam>()).CreateMapper();
            var mapper = new Mapper((IConfigurationProvider)config);
            var team = mapper.Map<InternshipTeam>(teamDto);
            _internshipTeamRep.InternshipTeams.Save(team);
            _internshipTeamRep.Save();
        }

        public void DeleteInternshipTeam(int id)
        {
            var team = _internshipTeamRep.InternshipTeams.Get(id);
            _internshipTeamRep.InternshipTeams.Remove(team);
            _internshipTeamRep.Save();
        }

        public InternshipTeamDTO GetInternshipTeamById(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<InternshipTeam, InternshipTeamDTO>()).CreateMapper();
            return mapper.Map<InternshipTeam, InternshipTeamDTO>(_internshipTeamRep.InternshipTeams.Get(id));
        }

        public IEnumerable<InternshipTeamDTO> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<InternshipTeam, InternshipTeamDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<InternshipTeam>, List<InternshipTeamDTO>>(_internshipTeamRep.InternshipTeams.GetAll());
        }
    }
}
