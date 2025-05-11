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
        public IActionResult Get()
        {
            return Ok(_context.Webhooks);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Webhook reg)
        {
            await _context.Webhooks.AddAsync(reg);
            await _context.SaveChangesAsync();
            return Ok(reg);
        }

        [HttpPost("unregister")]
        public async Task<IActionResult> Unregister([FromBody] Guid id)
        {
            var webhook = await _context.Webhooks.FindAsync(id);
            if (webhook == null)
            {
                return NotFound();
            }
            _context.Webhooks.Remove(webhook);
            await _context.SaveChangesAsync();
            return Ok();
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
            return Ok("Ping sent to all registered webhooks.");
        }
    }
}
