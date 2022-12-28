using System;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;

namespace Photino.Blazor.Sample
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            /* Photino seems to assume you're running the app from the same directory, so fix that. */
            Directory.SetCurrentDirectory(AppContext.BaseDirectory);

            var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);

            appBuilder.Services
                .AddLogging();

            // register root component and selector
            appBuilder.RootComponents.Add<App>("app");

            var app = appBuilder.Build();

            // customize window
            app.MainWindow
                .SetIconFile("favicon.ico")
                .SetTitle("Photino Blazor Sample");

            AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
            {
                app.MainWindow.OpenAlertWindow("Fatal exception", error.ExceptionObject.ToString());
            };

            app.Run();

        }
    }
}
