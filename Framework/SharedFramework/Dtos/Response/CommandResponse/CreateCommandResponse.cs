using SharedFramework.Constants;
using System.Text.Json.Serialization;

namespace SharedFramework.Dtos.Response.CommandResponse
{
    public class CreateCommandResponse
    {
        public CreateCommandResponse(bool isSuccess, int affectedRow, List<CreateCommandErrorModel> errors)
        {
            IsSuccess = isSuccess;
            AffectedRow = affectedRow;
            Message = CreateCommandMessageConstants.Error;
            Errors = errors;
        }

        public CreateCommandResponse(bool isSuccess, int affectedRow)
        {
            IsSuccess = isSuccess;
            AffectedRow = affectedRow;
            Message = IsSuccess == true ? CreateCommandMessageConstants.Success : CreateCommandMessageConstants.Error;
        }

        public bool IsSuccess { get; set; }
        public int AffectedRow { get; set; }
        public string Message { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public List<CreateCommandErrorModel>? Errors { get; set; }
    }

    public class CreateCommandErrorModel
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Field { get; set; }
        public string Message { get; set; }
        public CreateCommandErrorModel(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }
}
