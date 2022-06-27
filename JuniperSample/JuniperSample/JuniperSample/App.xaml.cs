using Xamarin.Forms;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace JuniperSample
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public App ()
        {
            InitializeComponent();

            var serviceProvider =
            new ServiceCollection()
                .ConfigureServices()
                .BuildServiceProvider();
            ServiceProvider = serviceProvider;

            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

