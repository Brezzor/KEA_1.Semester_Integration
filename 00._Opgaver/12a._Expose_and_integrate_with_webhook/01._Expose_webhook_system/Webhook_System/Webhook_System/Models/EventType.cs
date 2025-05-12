using System.Text.Json.Serialization;

namespace Webhook_System.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter<EventType>))]
    public enum EventType
    {
        payment_received,
        payment_processed,
        invoice_processing,
        invoice_completed
    }
}
