using Topshelf;

namespace NginxService
{
	public class Program
	{
		public static int Main(string[] args)
		{
			var host = HostFactory.New(x =>
			{
				x.Service<NginxController>(s => 
				{
					s.ConstructUsing(name => new NginxController());
                    s.WhenStarted(tc => tc.Start());
					s.WhenStopped(tc => tc.Stop());
				});
	
				x.RunAsNetworkService();
				x.StartAutomatically();

				x.SetDescription("Nginx web server");
				x.SetDisplayName("nginx");
				x.SetServiceName("nginx");
			});
		    return (int) host.Run();
		}	
	}
}
