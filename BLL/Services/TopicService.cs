using System.Collections.Generic;
using DAL.Repositories;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using DAL.Models;

namespace BLL.Services
{
    public class TopicService : ITopicService
    {
        private readonly IUnitOfWork _topicRep;

        public TopicService(IUnitOfWork topic)
        {
            _topicRep = topic;
        }

        public void AddTopic(TopicDTO topicDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TopicDTO, Topic>()).CreateMapper();
            var mapper = new Mapper((IConfigurationProvider)config);
            var topic = mapper.Map<Topic>(topicDto);
            _topicRep.Topics.Save(topic);
            _topicRep.Save();
        }

        public void DeleteTopic(int id)
        {
            var topic = _topicRep.Topics.Get(id);
            _topicRep.Topics.Remove(topic);
            _topicRep.Save();
        }

        public IEnumerable<TopicDTO> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Topic, TopicDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Topic>, List<TopicDTO>>(_topicRep.Topics.GetAll());
        }

        public TopicDTO GetTopicById(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Topic, TopicDTO>()).CreateMapper();
            return mapper.Map<Topic, TopicDTO>(_topicRep.Topics.Get(id));
        }
    }
}
