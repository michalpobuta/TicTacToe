using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Pages.MainMenu;
using TicTacToe.Pages.SingIn;
using TicTacToe.Pages.TicTacToe;
using TicTacToe.Popups;

namespace TicTacToe.Pages.Register;

public partial class RegisterView : ContentPage
{
    private readonly IServiceProvider serviceProvider;
	public RegisterView(IServiceProvider serviceProvider, RegisterViewModel registerViewModel)
	{
        this.serviceProvider = serviceProvider;
        BindingContext = registerViewModel;

        InitializeComponent();
	}

    private async void RegisterClicked(object sender, EventArgs e)
    {
        try
        {
            if (await (BindingContext as RegisterViewModel).Register())
                await App.Current.MainPage.Navigation.PushAsync(serviceProvider.GetService(typeof(MainMenuView)) as MainMenuView);
        }
        catch (Exception ex) 
        {
            await this.ShowPopupAsync(new InfoPopup() { InfoText= ex.Message });
        }
    }
    private async void BackClicked(object sender, EventArgs e)
    {
        await App.Current.MainPage.Navigation.PushAsync(serviceProvider.GetService(typeof(SingInView)) as SingInView);

    }
}