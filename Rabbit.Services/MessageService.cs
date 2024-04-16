using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rabbit.Models.Entities;
using Rabbit.Models.Interface;
using Rabbit.Services.Interfaces;

namespace Rabbit.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void SendMessage(Message message)
        {
            _messageRepository.SendMessage(message);
        }
    }
}