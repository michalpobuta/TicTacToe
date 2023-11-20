using TicTacToe.Pages.Register;
using TicTacToe.Pages.TicTacToe;

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
        if (await (BindingContext as SingInViewModel).Login())
            await App.Current.MainPage.Navigation.PushAsync(serviceProvider.GetService(typeof(TicTacToeView)) as TicTacToeView);
    }
    private async void RegisterClicked(object sender, EventArgs e)
    {
            await App.Current.MainPage.Navigation.PushAsync(serviceProvider.GetService(typeof(RegisterView)) as RegisterView);
    }
}