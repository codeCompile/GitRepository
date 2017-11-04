using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment_Typeahead.Startup))]
namespace Assignment_Typeahead
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
