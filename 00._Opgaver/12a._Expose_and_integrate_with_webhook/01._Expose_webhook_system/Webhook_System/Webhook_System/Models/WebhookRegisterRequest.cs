#nullable disable
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Webhook_System.Models
{
    public class WebhookRegisterRequest
    {
        [Required]
        [StringLength(300)]
        public string Url { get; set; }

        [Required]
        public EventType EventType { get; set; }
    }
}
