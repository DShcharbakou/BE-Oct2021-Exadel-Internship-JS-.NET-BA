using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
  public  class CandidateDTOForStatuses
    {
        public int ID { get; set; }
        public bool? IsInterviewedByHR { get; set; }
        public bool? IsInterviewedByTech { get; set; }
        public string Status { get; set; }
        public int SandboxCount { get; set; }

        public CandidateDTOForStatuses(int id)
        {
            ID = id;
        }

        public CandidateDTOForStatuses()
        { }

    }
}
