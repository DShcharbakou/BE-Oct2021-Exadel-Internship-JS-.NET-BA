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
    public class StackService : IStackService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public StackService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public void AddStack(StackDTO stackDto)
        {
            var stack = _mapper.Map<Stack>(stackDto);
            _db.Stacks.Save(stack);
            _db.Save();
        }

        public void DeleteStack(int id)
        {
            var stack = _db.Stacks.Get(id);
            _db.Stacks.Remove(stack);
            _db.Save();
        }

        public IEnumerable<StackDTO> GetList()
        {
            return _mapper.Map<IEnumerable<Stack>, List<StackDTO>>(_db.Stacks.GetAll());
        }

        public StackDTO GetStackById(int id)
        {
            return _mapper.Map<Stack, StackDTO>(_db.Stacks.Get(id));
        }
    }
}
