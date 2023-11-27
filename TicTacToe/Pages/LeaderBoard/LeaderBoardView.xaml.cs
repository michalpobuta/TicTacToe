namespace TicTacToe.Pages.LeaderBoard;

public partial class LeaderBoardView : ContentPage
{

    public LeaderBoardView(LeaderBoardViewModel leaderBoardViewModel)
	{
		BindingContext =  leaderBoardViewModel;	
        InitializeComponent();
	}
}