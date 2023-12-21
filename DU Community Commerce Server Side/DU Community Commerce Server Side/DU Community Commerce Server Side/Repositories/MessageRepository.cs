using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DU_Community_Commerce_Server_Side.Application_Context;
using DU_Community_Commerce_Server_Side.Models;

namespace DU_Community_Commerce_Server_Side.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationContext _applicationContext;

        public MessageRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public void SendMessage(Message message)
        {
             _applicationContext.Messages.Add(message);
            Save();
        }

        public IEnumerable<Message> GetAllMesseges(string userId)
        {
            var query = (from message in _applicationContext.Messages
                where message.UserId == userId
                select message).ToList();
            return query;
        }

        public void Save()
        {
            _applicationContext.SaveChanges();
        }
    }
}