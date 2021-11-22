using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ISandboxService
    {
        IEnumerable<SandboxDTO> GetAllSandboxes();
        SandboxDTO GetSandboxById(int id);
        void AddSandbox(SandboxDTO sandboxDto);
        void DeleteSandbox(int id);
        int GetCurrentSandboxId();
    }
}
