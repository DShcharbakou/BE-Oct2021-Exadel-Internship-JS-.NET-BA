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
        private readonly IUnitOfWork _stackRep;
        public StackService(IUnitOfWork stack)
        {
            _stackRep = stack;
        }
        public void AddStack(StackDTO stackDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StackDTO, Stack>()).CreateMapper();
            var mapper = new Mapper((IConfigurationProvider)config);
            var stack = mapper.Map<Stack>(stackDto);
            _stackRep.Stacks.Save(stack);
            _stackRep.Save();
        }

        public void DeleteStack(int id)
        {
            var stack = _stackRep.Stacks.Get(id);
            _stackRep.Stacks.Remove(stack);
            _stackRep.Save();
        }

        public IEnumerable<StackDTO> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Stack, StackDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Stack>, List<StackDTO>>(_stackRep.Stacks.GetAll());
        }

        public StackDTO GetStackById(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Stack, StackDTO>()).CreateMapper();
            return mapper.Map<Stack, StackDTO>(_stackRep.Stacks.Get(id));
        }
    }
}
