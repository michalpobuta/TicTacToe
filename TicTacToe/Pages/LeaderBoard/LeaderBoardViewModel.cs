using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Database.Model;
using TicTacToe.Database.Repositories;

namespace TicTacToe.Pages.LeaderBoard
{
    public partial class LeaderBoardViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<LeaderBoardModel> leaderBoardObjects = new();


        private readonly IBaseRepository<Game> gameRepository;
        public LeaderBoardViewModel(IBaseRepository<Game> gameRepository) 
        {
            this.gameRepository = gameRepository;
            Task.Run(() =>  SetData());
        }

        private async Task SetData() 
        {
            int i = 1;
            var games = await gameRepository.GetItems(x => x.IsGameFinised);
            var list = games.GroupBy(x => x.User)
                 .Select(x => new LeaderBoardModel() { Score = x.Sum(y => (y.IsUserWinner??false) ? ((int)y.BotLvL) : -((int)y.BotLvL)), ImageFullPath = x.Key.PhotoFullPath, Name = x.Key.Name })
                 .OrderByDescending(x => x.Score)
                 .ToList();
            list.ForEach(x => x.Id = i++);
            LeaderBoardObjects = list.ToObservableCollection();
        }
    }
}
