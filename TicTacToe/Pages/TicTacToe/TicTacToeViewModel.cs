using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TicTacToe.Common;
using TicTacToe.Database.Factories;
using TicTacToe.Database.Model;
using TicTacToe.Database.Repositories;
using TicTacToe.TicTacToeGame.Bot;

namespace TicTacToe.Pages.TicTacToe
{
    public partial class TicTacToeViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<GameMoveModel> moves = new ObservableCollection<GameMoveModel>();

        private readonly IBaseRepository<Game> gameRepository;
        private readonly IBaseRepository<GameMove> gameMoveRepository;
        private UserSession userSession;
        public TicTacToeViewModel(IBaseRepository<Game> gameRepository, UserSession userSession, IBaseRepository<GameMove> gameMoveRepository)
        {
            this.gameRepository = gameRepository;
            this.gameRepository = gameRepository;
            this.userSession = userSession;
        }

        public void SaveMove(int x, int y,int player) 
        {
            Moves.Add(new() { MoveX=x, MoveY=y, PlayerName = player == 1 ? userSession.CurrentUser.Name : "Bot", Player=player, MoveNumber = Moves.Count+1 });
        }
        public async Task SaveGame(int player,BotLvL botLvL) 
        {
            //var game = GameFactory.CreateGame(userSession.CurrentUser, botLvL, null, true, player ==1);
            //await gameMoveRepository.SaveItems(Moves.Select(x => GameMoveFactory.CreateGameMove(game, x.Player ==1, x.MoveNumber, x.MoveX, x.MoveY)).ToList());
        }
        public void Reset() 
        {
            Moves = new ObservableCollection<GameMoveModel>();
        }
    }
}
