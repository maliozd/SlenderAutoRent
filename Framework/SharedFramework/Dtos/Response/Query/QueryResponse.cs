namespace SharedFramework.Dtos.Response.QueryResponse
{
    public abstract class QueryResponse<T>
    {
        public T Data { get; set; }
    }
}
