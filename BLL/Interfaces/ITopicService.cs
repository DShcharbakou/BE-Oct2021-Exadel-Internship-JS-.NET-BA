using BLL.DTO;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ITopicService
    {
        IEnumerable<TopicDTO> GetList();//возвращать topic или topicDTO?
        TopicDTO GetTopicById(int id);
        void AddTopic(TopicDTO topicDto);
        void DeleteTopic(int id);
    }
}
