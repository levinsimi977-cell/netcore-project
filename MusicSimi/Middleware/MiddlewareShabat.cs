namespace MusicSimi.Middleware
{
    public class MiddlewareShabat
    {
        private readonly RequestDelegate _next;

        public MiddlewareShabat(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if (DayOfWeek.Friday == DateTime.Now.DayOfWeek|| DayOfWeek.Saturday == DateTime.Now.DayOfWeek)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "text/plain; charset=utf-8";
                await context.Response.WriteAsync("היום זהו יום חופשי , נסה ביום ראשון");
                return;
            }
            await _next(context);
        }
    }
}
