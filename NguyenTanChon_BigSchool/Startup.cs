using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NguyenTanChon_BigSchool.Startup))]
namespace NguyenTanChon_BigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
