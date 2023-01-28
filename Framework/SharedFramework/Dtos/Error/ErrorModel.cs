using System.Text.Json.Serialization;

namespace SharedFramework.Dtos.Error
{
    public class ErrorModel
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Field { get; set; }
        public string Message { get; set; }
        public ErrorModel(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }
}
