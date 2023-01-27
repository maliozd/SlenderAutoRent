using SharedFramework.Dtos.Request;

namespace SharedFramework.Utilities
{
    public static class CommonUsedExtension
    {
        public static List<T> ToPagedList<T>(this IQueryable<T> source, PaginationRequest request)
        {
            return source.Skip(request.Skip).Take(request.PerPage).ToList();
        }
    }
}
