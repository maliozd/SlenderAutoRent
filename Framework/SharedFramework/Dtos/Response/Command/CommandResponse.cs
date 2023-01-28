using SharedFramework.Dtos.Error;
using System.Text.Json.Serialization;

namespace SharedFramework.Dtos.Response.Command
{
    public class CommandResponse<T> where T : class
    {
        public CommandResponse(bool isSuccess, string errorMessage)
        {
            IsSuccess = isSuccess;
            Message = errorMessage;
        }
        public CommandResponse(bool isSuccess, int affectedRow, string message, T affectedData)
        {
            AffectedRow = affectedRow;
            AffectedData = affectedData;
            Message = message;
            IsSuccess = isSuccess;
        }
        public CommandResponse(bool isSuccess, int affectedRow, T? affectedData, string? message, List<ErrorModel>? errors)
        {
            IsSuccess = isSuccess;
            AffectedRow = affectedRow;
            AffectedData = affectedData;
            Message = message;
            Errors = errors;
        }
        public CommandResponse(bool isSuccess, string message, T affectedData)
        {
            IsSuccess = isSuccess;
            Message = message;
            AffectedData = affectedData;
        }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public int AffectedRow { get; set; }
        public T? AffectedData { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ErrorModel>? Errors { get; set; }
    }
}
