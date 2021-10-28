using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStackService
    {
        IEnumerable<StackDTO> GetList();
        StackDTO GetStackById(int id);
        void AddStack(StackDTO stackDto);
        void DeleteStack(int id);
    }
}
