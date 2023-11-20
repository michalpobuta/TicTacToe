using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Common;
using TicTacToe.Database.Factories;
using TicTacToe.Database.Model;
using TicTacToe.Database.Repositories;

namespace TicTacToe.Pages.Register
{
    public partial class RegisterViewModel : ObservableObject
    {
        [ObservableProperty]
        private NewUserModel user = new();

        private readonly IHashService hashService;
        private readonly IBaseRepository<User> userRepository;
        private UserSession userSession;
        public RegisterViewModel(IHashService hashService, IBaseRepository<User> userRepository, UserSession userSession)
        {
            this.hashService = hashService;
            this.userRepository = userRepository;
            this.userSession = userSession;
        }

        public async Task<bool> Register() 
        {
            if (user.IsUserValid()) 
            {
                if (!(await userRepository.GetItems(x => x.Email.Equals(user.Email))).Any())
                {
                    var newUser = await userRepository.SaveItem(UserFactory.CreateUser(user.Name, user.Email, hashService.Hash(user.Password)));
                    userSession.CurrentUser = newUser;
                    return true;
                }
            }
            return false;
        }
    }
}
