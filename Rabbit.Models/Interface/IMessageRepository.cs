using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rabbit.Models.Entities;

namespace Rabbit.Models.Interface
{
    public interface IMessageRepository
    {
        void SendMessage(Message message);
    }
}