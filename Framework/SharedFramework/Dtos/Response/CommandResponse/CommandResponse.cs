using System.Text.Json.Serialization;

namespace SharedFramework.Dtos.Response.CommandResponse
{
    public class CommandResponse
    {
        public bool IsSuccess { get; set; }
        public int AffectedRow { get; set; }
        public string? Message { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ErrorModel>? Errors { get; set; }
    }
}
