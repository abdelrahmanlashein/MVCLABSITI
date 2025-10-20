using Serilog;

namespace MVCLABSITI.MiddleWares
{
    public class SerilogMiddleware
    {
        private readonly RequestDelegate _next;
        public SerilogMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Log.Information("Handling request: {Method} {Url}", context.Request.Method, context.Request.Path);
            await _next(context);
            Log.Information("Finished handling request.");
        }
    }
}
