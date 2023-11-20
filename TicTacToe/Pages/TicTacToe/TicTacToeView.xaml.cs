using TicTacToe.TicTacToeGame;
using TicTacToe.TicTacToeGame.Bot;

namespace TicTacToe.Pages.TicTacToe;

public partial class TicTacToeView : ContentPage
{
	private readonly ITicTacToeGame game;
    private readonly IBot bot;
    public TicTacToeView(TicTacToeViewModel ticTacToeViewModel, ITicTacToeGame game,BotFactory botFactory)
	{
		BindingContext = ticTacToeViewModel;
		this.game = game;
        this.bot = botFactory.CreateBot(BotLvL.Easy);
        InitializeComponent();
        InitTicTacToeGame();
    }


	private async void InitTicTacToeGame() 
	{
        var gameView = new TicTacToeGameView(game);
        gameGrid.Drawable = gameView;
        while (gameView.BoardScale < 1.0) 
        {
            gameView.BoardScale+= 0.05f;
            gameGrid.Invalidate();
            await Task.Delay(35);
        }
    }


    private async void Tapped(object sender, TappedEventArgs e)
    {
        var vm = BindingContext as TicTacToeViewModel;
        var pos = e.GetPosition(gameGrid);

        int col = (int)(pos.Value.X / gameGrid.Width * 3);
        int row = (int)(pos.Value.Y / gameGrid.Height * 3);

        if (game.MakeMove(row, col))
        {
            vm.SaveMove(row, col, 1);
            gameGrid.IsEnabled = false;

            await ElementAnimation();
            var result = game.CheckResult();
            if (result >= 0) 
            {
                await vm.SaveGame(1, BotLvL.Easy);
                gameGrid.IsEnabled = false;
                await DisplayAlert("Uwaga", GetResult(result), "OK");
                return;
            }
            game.ChangePlayer();
            if (game.MakeMoveForBot(bot)) 
            {
                vm.SaveMove(row, col, 1);
                await ElementAnimation();
                var result2 = game.CheckResult();
                if (result2 >= 0)
                {
                    await vm.SaveGame(2, BotLvL.Easy);
                    gameGrid.IsEnabled = false;
                    await DisplayAlert("Uwaga", GetResult(result2), "OK");
                    return;
                }
                game.ChangePlayer();
            }
            gameGrid.IsEnabled = true;
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as TicTacToeViewModel;
        game.Reset();
        vm.Reset();
        var gameView = gameGrid.Drawable as TicTacToeGameView;
        gameView.BoardScale = 0.0f;
        while (gameView.BoardScale < 1.0)
        {
            gameView.BoardScale+= 0.05f;
            gameGrid.Invalidate();
            await Task.Delay(35);
        }
        gameGrid.IsEnabled = true;
    }

    private async Task ElementAnimation() 
    {
        var gameView = gameGrid.Drawable as TicTacToeGameView;
        gameView.ElementScale = 0.0f;
        while (gameView.ElementScale <1.0)
        {
            gameView.ElementScale+= 0.05f;
            gameGrid.Invalidate();
            await Task.Delay(25);
        }
    }
    private string GetResult(int result) => result switch
    {
        0 => "REMIS",
        1 => "X WYGRYWA!!!",
        2 => "O WYGRYWA!!!",
        _ => "error"
    };

}