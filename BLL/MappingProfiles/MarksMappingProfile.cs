using AutoMapper;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MappingProfiles
{
   public class MarksMappingProfile: Profile
    {
            public MarksMappingProfile()
            {
            CreateMap<InterviewMarksWithSkillIDDTO, SkillKnowledgeDTO>();
            CreateMap<IEnumerable<SkillKnowledgeWithMarksListDTO>, IEnumerable<SkillKnowledgeDTO>>()
                    .ConvertUsing((dtos, _, context) =>
                    {
                        return dtos
                            .GroupBy(dto => dto.InterviewID)
                            .Select(group => new SkillKnowledgeDTO
                            {
                                InterviewID = group.Key.InterviewID,
                                Level = group.Select(context.Mapper.Map<InterviewMarksWithSkillIDDTO.SkillLevel>).ToList(),
                                SkillID = group.Select(context.Mapper.Map<InterviewMarksWithSkillIDDTO>).ToList()
                            })
                            .ToList();
                    });
            }
        }
    }
}
