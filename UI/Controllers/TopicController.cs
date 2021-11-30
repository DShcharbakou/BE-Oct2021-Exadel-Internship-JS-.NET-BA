using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet("get-all-topics")]
        public List<TopicDTO> GetAllTopics()
        {
            return _topicService.GetList().ToList();
        }

        [HttpGet("{id}/get-topic-by-id")]
        public TopicDTO GetTopicById(int id)
        {
            return _topicService.GetTopicById(id);
        }
    }
}
