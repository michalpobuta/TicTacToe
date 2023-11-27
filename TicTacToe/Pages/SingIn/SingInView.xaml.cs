using CommunityToolkit.Maui.Views;
using TicTacToe.Pages.MainMenu;
using TicTacToe.Pages.Register;
using TicTacToe.Pages.TicTacToe;
using TicTacToe.Popups;

namespace TicTacToe.Pages.SingIn;

public partial class SingInView : ContentPage
{
    private readonly IServiceProvider serviceProvider;

    public SingInView(SingInViewModel singInViewModel,IServiceProvider serviceProvider)
	{
		InitializeComponent();
		BindingContext = singInViewModel;
        this.serviceProvider = serviceProvider;
    }

    private async void LoginClicked(object sender, EventArgs e)
    {
        try
        {
            if (await (BindingContext as SingInViewModel).Login())
                await App.Current.MainPage.Navigation.PushAsync(serviceProvider.GetService(typeof(MainMenuView)) as MainMenuView);
        }
        catch (Exception ex) 
        {
            await this.ShowPopupAsync(new InfoPopup() { InfoText= ex.Message });
        }
    }
    private async void RegisterClicked(object sender, EventArgs e)
    {
            await App.Current.MainPage.Navigation.PushAsync(serviceProvider.GetService(typeof(RegisterView)) as RegisterView);
    }
}