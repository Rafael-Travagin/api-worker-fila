using Microsoft.AspNetCore.Mvc;
using Rabbit.Models.Entities;
using Rabbit.Services.Interfaces;

namespace Rabbit.Webapi.Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        
        public RabbitMessageController(IMessageService messageService)
        {
            _messageService = messageService;
            //_logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> SendMessage(Message message)
        {
            try
            {
                _messageService.SendMessage(message);
                return NoContent();

            }
            catch (Exception ex)
            {                
                return BadRequest(ex.Message);
            }
            
        }

    }
}
