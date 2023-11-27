using CommunityToolkit.Maui.Views;
using TicTacToe.Popups;
using TicTacToe.TicTacToeGame;
using TicTacToe.TicTacToeGame.Bot;

namespace TicTacToe.Pages.TicTacToe;

public partial class TicTacToeView : ContentPage
{
	private readonly ITicTacToeGame game;
    private Bot bot;
    private readonly BotFactory botFactory;

    public TicTacToeView(TicTacToeViewModel ticTacToeViewModel, ITicTacToeGame game,BotFactory botFactory)
	{
		BindingContext = ticTacToeViewModel;
		this.game = game;
        this.botFactory = botFactory;
        InitializeComponent();
    }

	public async void InitTicTacToeGame(BotLvL botLvL) 
	{
        this.bot = botFactory.CreateBot(botLvL);
        gameGrid.Drawable =  new TicTacToeGameView(game);
        await InitAnimation();
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
                await LineAnimation();
                await vm.SaveGame(result, bot.GetBotLvL());
                gameGrid.IsEnabled = false;
                await this.ShowPopupAsync(new InfoPopup() { InfoText= GetResult(result) });
                return;
            }
            await MakeBotMove();
            gameGrid.IsEnabled = true;
        }
    }

    private async Task MakeBotMove() 
    {
        var vm = BindingContext as TicTacToeViewModel;
        game.ChangePlayer();
        var botMove = game.MakeMoveForBot(bot);
        if (botMove!= null)
        {
            vm.SaveMove(botMove.Value.row, botMove.Value.col, 2);
            await ElementAnimation();
            var result2 = game.CheckResult();
            if (result2 >= 0)
            {
                await LineAnimation();
                await vm.SaveGame(result2, bot.GetBotLvL());
                gameGrid.IsEnabled = false;
                await this.ShowPopupAsync(new InfoPopup() { InfoText= GetResult(result2) });
                return;
            }
            game.ChangePlayer();
        }

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as TicTacToeViewModel;
        game.Reset();
        vm.Reset();
        await InitAnimation();
    }

    private async Task ElementAnimation() 
    {
        var gameView = gameGrid.Drawable as TicTacToeGameView;
        gameView.ElementScale = 0.0f;
        while (gameView.ElementScale <0.9f)
        {
            gameView.ElementScale+= 0.05f;
            gameGrid.Invalidate();
            await Task.Delay(25);
        }
    }
    private async Task InitAnimation() 
    {
        gameGrid.IsEnabled = false;
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
    private async Task LineAnimation()
    {
        var gameView = gameGrid.Drawable as TicTacToeGameView;
        gameView.LineScale = 0.0f;
        while (gameView.LineScale <1.0)
        {
            gameView.LineScale+= 0.05f;
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