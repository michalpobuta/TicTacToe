using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using TicTacToe.Common;
using TicTacToe.Database;
using TicTacToe.Database.Model;
using TicTacToe.Database.Repositories;
using TicTacToe.Pages.Register;
using TicTacToe.Pages.SingIn;
using TicTacToe.Pages.TicTacToe;
using TicTacToe.TicTacToeGame;
using TicTacToe.TicTacToeGame.Bot;

namespace TicTacToe
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCompatibility()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif  
            //Common
            builder.Services.AddTransient<ITicTacToeGame, TicTacToeGame.TicTacToeGame>();
            builder.Services.AddTransient<TicTacToeGameView>();
            builder.Services.AddSingleton<BotFactory>();
            builder.Services.AddSingleton<UserSession>();
            builder.Services.AddSingleton<IPath, DbPath>();
            builder.Services.AddSingleton<IHashService, HashService>();

            //Repositories
            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddSingleton<IBaseRepository<User>, UserRepository>();
            builder.Services.AddSingleton<IBaseRepository<Game>, GameRepository>();
            builder.Services.AddSingleton<IBaseRepository<GameMove>, GameMoveRepository>();

            //View
            builder.Services.AddTransient<SingInView>();
            builder.Services.AddTransient<TicTacToeView>();
            builder.Services.AddTransient<RegisterView>();

            //ViewModel
            builder.Services.AddTransient<SingInViewModel>();
            builder.Services.AddTransient<TicTacToeViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();
            return builder.Build();
        }
    }
}
