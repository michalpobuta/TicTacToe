using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Common;
using TicTacToe.Database.Model;
using TicTacToe.Database.Repositories;
using TicTacToe.TicTacToeGame.Bot;

namespace TicTacToe.Pages.MainMenu
{
    public partial class MainMenuViewModel : ObservableObject
    {

        [ObservableProperty]
        private MainMenuModel menuModel;
        private readonly IBaseRepository<Game> gameRepository;
        private readonly UserSession userSession;
        public MainMenuViewModel(UserSession userSession, IBaseRepository<Game> gameRepository) 
        {
            this.userSession = userSession;
            this.gameRepository = gameRepository;

            Task.Run(() => SetData());
        }

        private async Task SetData() 
        {
            var menuModel = new MainMenuModel();
            menuModel.Name = userSession.CurrentUser.Name;
            menuModel.PhotoFullPath = userSession.CurrentUser.PhotoFullPath;
            var userGames = await gameRepository.GetItems(x => x.User.Id == userSession.CurrentUser.Id);
            var es = new int[3] {0,0,0};

            menuModel.EasyBotWDL = userGames.Where(x => x.BotLvL.Equals(BotLvL.Easy)).Aggregate(new int[] { 0, 0, 0 }, setResult);
            menuModel.MediumBotWDL = userGames.Where(x => x.BotLvL.Equals(BotLvL.Medium)).Aggregate(new int[] { 0, 0, 0 }, setResult);
            menuModel.HardBotWDL = userGames.Where(x => x.BotLvL.Equals(BotLvL.Hard)).Aggregate(new int[] { 0, 0, 0 }, setResult);

            MenuModel = menuModel;
        }

        private int[] setResult(int[] tab, Game game) 
        {
            tab[game?.IsUserWinner??false ? 0 : ((game?.IsGameFinised??false) ? 2 : 1)]+=1;
            return tab;
        }


            
        
        



    }
}
