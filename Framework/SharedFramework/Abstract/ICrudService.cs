using SharedFramework.Dtos.Request;
using SharedFramework.Dtos.Response.CommandResponse;
using SharedFramework.Dtos.Response.QueryResponse;

namespace SharedFramework.Abstract
{
    public interface ICrudService<TQueryDto, TCommandDto> where TQueryDto : class where TCommandDto : class
    {
        Task<PaginationQueryResponse<ICollection<TQueryDto>>> GetPagedAsync(PaginationRequest request);
        Task<QueryResponse<ICollection<TQueryDto>>> GetAllAsync();
        Task<QueryResponse<TQueryDto>> GetByIdAsync(Guid id);
        Task<CommandResponse> InsertAsync(TCommandDto commandDto);
        Task<CommandResponse> UpdateAsync(TCommandDto commandDto);
        Task<CommandResponse> DeleteByIdAsync(Guid id);
        Task<CommandResponse> DeleteAsync(TCommandDto commandDto);
    }
}
