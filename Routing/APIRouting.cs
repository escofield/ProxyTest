using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace RequestIntercessor.Routing
{
    public class APIRouting : IRouter
    {
        private readonly IRouter _defaultRouter;
        private readonly IConfiguration _configuration;

        public APIRouting(IRouter defaultRouter, IConfiguration configuration)
        {
            _defaultRouter = defaultRouter;
            _configuration = configuration;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return _defaultRouter.GetVirtualPath(context);
        }

        public async Task RouteAsync(RouteContext context)
        {
            var path = context.HttpContext.Request.Path.Value.Split('/');

                var routeData = new RouteData();
                routeData.Values["controller"] = "CatchTest";
                routeData.Values["action"] = "Catch";
                context.RouteData = routeData;
            
            await _defaultRouter.RouteAsync(context);
        }
    }
}