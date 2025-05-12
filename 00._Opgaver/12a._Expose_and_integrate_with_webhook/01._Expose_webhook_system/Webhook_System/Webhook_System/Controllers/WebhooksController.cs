using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using Webhook_System.Models;

namespace Webhook_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebhooksController : ControllerBase
    {
        private readonly WebhooksDBContext _context;

        public WebhooksController(WebhooksDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Webhook>> Get()
        {
            return Ok(_context.Webhooks);
        }

        [HttpPost("register")]
        public async Task<ActionResult<Webhook>> Register([FromBody] WebhookRegisterRequest reg)
        {
            Webhook webhook = new Webhook
            {
                Url = reg.Url,
                EventType = reg.EventType.ToString()
            };
            await _context.Webhooks.AddAsync(webhook);
            await _context.SaveChangesAsync();
            return Ok(webhook);
        }

        [HttpDelete("unregister/{id}")]
        public async Task<IActionResult> Unregister([FromRoute] Guid id)
        {
            var webhook = await _context.Webhooks.FindAsync(id);
            if (webhook == null)
            {
                return NotFound();
            }
            _context.Webhooks.Remove(webhook);
            await _context.SaveChangesAsync();
            return Ok("Successfully unregistered webhook!");
        }

        [HttpPost("ping")]
        public async Task<IActionResult> Ping()
        {
            var webhooks = _context.Webhooks.ToList();
            foreach (var webhook in webhooks)
            {
                var payload = new
                {
                    message = "Ping",
                    timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds(),
                    webhook.EventType,
                    webhook.Url
                };

                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync(webhook.Url, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        return BadRequest(webhook.Url);
                    }
                }
            }
            return Ok("Ping sent to all registered webhooks!");
        }

        [HttpPost]
        [Route("ping/{eventType}")]
        public async Task<IActionResult> PingByEventType([FromRoute] EventType eventType)
        {
            string eventTypeString = eventType.ToString();
            var webhooks = _context.Webhooks.Where(hook => hook.EventType == eventTypeString);
            foreach (var webhook in webhooks)
            {
                var payload = new
                {
                    message = "Ping",
                    timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds(),
                    webhook.EventType,
                    webhook.Url
                };

                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync(webhook.Url, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        return BadRequest(webhook.Url);
                    }
                }
            }
            return Ok($"Ping sent to all registered webhooks with EventType: '{eventTypeString}'!");
        }

        [HttpPost]
        [Route("ping/{id:guid}")]
        public async Task<IActionResult> PingById([FromRoute] Guid id)
        {
            var webhooks = _context.Webhooks.Where(hook => hook.Id == id);
            foreach (var webhook in webhooks)
            {
                var payload = new
                {
                    message = "Ping",
                    timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds(),
                    webhook.EventType,
                    webhook.Url
                };

                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync(webhook.Url, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        return BadRequest(webhook.Url);
                    }
                }
            }
            return Ok($"Ping sent to webhook with id: '{id}'!");
        }
    }
}
