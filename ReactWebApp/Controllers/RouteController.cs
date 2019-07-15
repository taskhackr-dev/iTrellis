using Microsoft.AspNetCore.Mvc;
using MapsNavigation;

namespace ReactWebApp.Controllers
{
    [Route("api/[controller]")]
    public class RouteController : Controller
    {
        [HttpPost("[action]")]
        public int GetShortestRoute([FromBody]string directions)
        {
            var route = Route.Parse(directions);
            return route.GetShortestNumberOfBlocksToDestination();
        }
    }
}
