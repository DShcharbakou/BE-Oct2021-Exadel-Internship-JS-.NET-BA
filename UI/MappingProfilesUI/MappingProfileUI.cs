using AutoMapper;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.MappingProfilesUI
{
    public class MappingProfileUI : Profile
    {
        public MappingProfileUI()
        {
            CreateMap<AssessmentModel, CandidateSandboxDTO>();

            CreateMap<HRInterviewResults, HRInterviewDTO>();
        }
    }
}
