using Microsoft.AspNetCore.Mvc.Filters;

namespace SharedFramework.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Where(x => x.Value.Errors.Any()).
                    ToDictionary(e => e.Key, x => x.Value.Errors.
                    Select(e => e.ErrorMessage)).ToArray();
                //todo --> finish - create customObjectResult ??
            }
        }
    }
}
