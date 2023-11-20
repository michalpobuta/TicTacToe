using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Database;
using TicTacToe.Pages.SingIn;
using TicTacToe.Pages.TicTacToe;

namespace TicTacToe
{
    public partial class App : Application
    {

        public static IServiceProvider Services;
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            Services = serviceProvider;
            InitializeDatabase(serviceProvider).Wait();


            MainPage = new NavigationPage((SingInView)serviceProvider.GetService(typeof(SingInView)));
        }

        private async Task InitializeDatabase(IServiceProvider serviceProvider)
        {
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                await using var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await appContext.Database.EnsureCreatedAsync();
            }
        }
    }
}
