using CommunityToolkit.Maui.Views;
using TicTacToe.TicTacToeGame.Bot;

namespace TicTacToe.Popups;

public partial class PickLvLPopup : Popup
{
	public PickLvLPopup()
	{
		InitializeComponent();
	}


    async void EasyClicked(object? sender, EventArgs e) => await CloseAsync(BotLvL.Easy);
    async void MediumClicked(object? sender, EventArgs e) => await CloseAsync(BotLvL.Medium);
    async void HardClicked(object? sender, EventArgs e) => await CloseAsync(BotLvL.Hard);
    async void CancelClicked(object? sender, EventArgs e) => await CloseAsync(BotLvL.None);

}