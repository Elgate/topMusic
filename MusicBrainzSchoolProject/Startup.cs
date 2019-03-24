using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicBrainzSchoolProject.Startup))]
namespace MusicBrainzSchoolProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
