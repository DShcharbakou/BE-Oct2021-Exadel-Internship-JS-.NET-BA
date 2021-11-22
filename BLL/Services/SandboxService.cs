using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SandboxService : ISandboxService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public SandboxService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void AddSandbox(SandboxDTO sandboxDto)
        {
            var sandbox = _mapper.Map<Sandbox>(sandboxDto);
            _db.Sandboxes.Save(sandbox);
            _db.Save();
        }

        public void DeleteSandbox(int id)
        {
            var sandbox = _db.Sandboxes.Get(id);
            _db.Sandboxes.Remove(sandbox);
            _db.Save();
        }

        public IEnumerable<SandboxDTO> GetAllSandboxes()
        {
            return _mapper.Map<IEnumerable<Sandbox>, List<SandboxDTO>>(_db.Sandboxes.GetAll());
        }

        public SandboxDTO GetSandboxById(int id)
        {
            return _mapper.Map<Sandbox, SandboxDTO>(_db.Sandboxes.Get(id));
        }

        public int GetCurrentSandboxId()
        {
            var sndbxDTO = _mapper.Map<Sandbox, SandboxDTO>(_db.Sandboxes.GetAll().LastOrDefault());
            return sndbxDTO.Id;
        }

    }
}