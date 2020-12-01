using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankManagementWebApp.Startup))]
namespace BankManagementWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
