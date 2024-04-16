using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rabbit.Models.Entities;

namespace Rabbit.Services.Interfaces
{
    public interface IMessageService
    {
        void SendMessage(Message message);
    }
}