using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Pages.TicTacToe;

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
        if (await(BindingContext as RegisterViewModel).Register())
            await App.Current.MainPage.Navigation.PushAsync(serviceProvider.GetService(typeof(TicTacToeView)) as TicTacToeView);
    }
    private async void BackClicked(object sender, EventArgs e)
    {
        await App.Current.MainPage.Navigation.PushAsync(serviceProvider.GetService(typeof(RegisterView)) as RegisterView);

    }
}