using CommunityToolkit.Maui.Views;
using TicTacToe.Popups;

namespace TicTacToe.Pages.Account;

public partial class AccountView : ContentPage
{
	public AccountView( AccountViewModel accountViewModel)
	{
		BindingContext = accountViewModel;
		InitializeComponent();
	}

    private async void SaveUserClicked(object sender, EventArgs e)
    {
		try
		{
			await (BindingContext as AccountViewModel)?.SaveUser();
		}
		catch (Exception ex)
		{
            await this.ShowPopupAsync(new InfoPopup() { InfoText= ex.Message });
        }
    }
}