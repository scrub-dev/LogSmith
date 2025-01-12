using logsmith.TagParsers;
using logsmith.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;


namespace logsmith
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            string x = "[BUILD : {{date hh:mm:ss}}] - A Build Happened - {{loremipsum (10,15)}}";

            Parser.ParseTemplateString(ref x);
            Trace.WriteLine("__________________");
            Trace.WriteLine(x);
            Trace.WriteLine("__________________");

            _host = Host.CreateDefaultBuilder().ConfigureServices(services => {
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainWindowViewModel>(),
                });
            }).Build();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
