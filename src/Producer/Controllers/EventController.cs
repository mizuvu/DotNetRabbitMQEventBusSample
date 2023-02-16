using EventBus.Abstractions;
using EventBusRabbitMQ.example;
using Microsoft.AspNetCore.Mvc;

namespace Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventBus _eventProducer;

        public EventController(IEventBus eventProducer)
        {
            _eventProducer = eventProducer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = new EventData();
            data.Message = "Message from ID:" + data.Id;

            _eventProducer.Publish(MessageQueue.Queue, data);

            return Ok();
        }
    }
}