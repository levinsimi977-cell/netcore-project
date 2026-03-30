using MusicSimi.Middleware;

namespace MusicSimi
{
    public static class Extensions
    {
        public static IApplicationBuilder UseShabbatMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareShabat>();
        }

    }
}
