using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestaurantJISH_Part2.Startup))]
namespace RestaurantJISH_Part2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
