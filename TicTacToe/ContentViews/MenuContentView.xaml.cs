using TicTacToe.Common;
using TicTacToe.Pages.Account;
using TicTacToe.Pages.LeaderBoard;
using TicTacToe.Pages.MainMenu;
using TicTacToe.Pages.SingIn;

namespace TicTacToe.ContentViews;

public partial class MenuContentView : ContentView
{

    private readonly IServiceProvider serviceProvider;

    public MenuContentView()
	{
        serviceProvider = StaticServiceProvider.GetService<IServiceProvider>();

        InitializeComponent();
	}

    private async void MainMenuClicked(object sender, EventArgs e) => await ChangePage(typeof(MainMenuView));
    private async void LeaderBoardClicked(object sender, EventArgs e) => await ChangePage(typeof(LeaderBoardView));
    private async void AccountClicked(object sender, EventArgs e) => await ChangePage(typeof(AccountView));
    private async void LogoutClicked(object sender, EventArgs e) => await ChangePage(typeof(SingInView));

    private async Task ChangePage(Type type) 
    {
        await App.Current.MainPage.Navigation.PushAsync(serviceProvider.GetService(type) as Page);
    }

}