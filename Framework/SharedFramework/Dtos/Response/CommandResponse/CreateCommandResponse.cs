using SharedFramework.Constants;
using System.Text.Json.Serialization;

namespace SharedFramework.Dtos.Response.CommandResponse
{
    public class CreateCommandResponse : CommandResponse
    {
        public CreateCommandResponse(bool isSuccess, int affectedRow)
        {
            IsSuccess = isSuccess;
            AffectedRow = affectedRow;
            Message = IsSuccess == true ? CreateCommandMessageConstants.Success : CreateCommandMessageConstants.Error;
        }

        public CreateCommandResponse(List<ErrorModel> errors)
        {
            Message = CreateCommandMessageConstants.Error;
            Errors = errors;
        }
    }
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
