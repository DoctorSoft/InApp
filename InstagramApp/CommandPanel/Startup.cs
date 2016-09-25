using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CommandPanel.Startup))]
namespace CommandPanel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
