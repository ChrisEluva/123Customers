using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_123Customers.Startup))]
namespace _123Customers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
