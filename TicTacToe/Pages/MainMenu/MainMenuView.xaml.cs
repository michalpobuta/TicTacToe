using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Pages.TicTacToe;
using TicTacToe.Popups;
using TicTacToe.TicTacToeGame.Bot;

namespace TicTacToe.Pages.MainMenu;

public partial class MainMenuView : ContentPage
{
    private readonly IServiceProvider serviceProvider;

    public MainMenuView(IServiceProvider serviceProvider, MainMenuViewModel mainMenuViewModel)
	{
        BindingContext = mainMenuViewModel;
        this.serviceProvider = serviceProvider;
		InitializeComponent();
	}

    private async void NewGameCliceked(object sender, EventArgs e)
    {
        var lvl = await DisplayPopup();
        if (lvl != BotLvL.None) 
        {
            var ticTacToeView = serviceProvider.GetService(typeof(TicTacToeView)) as TicTacToeView;
            ticTacToeView.InitTicTacToeGame(lvl);
            await App.Current.MainPage.Navigation.PushAsync(ticTacToeView);
        }
    }

    public async Task<BotLvL> DisplayPopup()
    {
        var popup = new PickLvLPopup();

        var result = await this.ShowPopupAsync(popup);

        if (result is BotLvL lvl)
        {
            return lvl;
        }
        return BotLvL.None;
    }

}