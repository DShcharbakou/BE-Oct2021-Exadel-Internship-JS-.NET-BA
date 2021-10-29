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
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public TopicService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void AddTopic(TopicDTO topicDto)
        {
            var topic = _mapper.Map<Topic>(topicDto);
            _db.Topics.Save(topic);
            _db.Save();
        }

        public void DeleteTopic(int id)
        {
            var topic = _db.Topics.Get(id);
            _db.Topics.Remove(topic);
            _db.Save();
        }

        public IEnumerable<TopicDTO> GetList()
        {
            return _mapper.Map<IEnumerable<Topic>, List<TopicDTO>>(_db.Topics.GetAll());
        }

        public TopicDTO GetTopicById(int id)
        {
            return _mapper.Map<Topic, TopicDTO>(_db.Topics.Get(id));
        }
    }
}
