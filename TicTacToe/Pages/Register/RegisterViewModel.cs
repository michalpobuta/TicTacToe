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
using TicTacToe.Extensions;

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
                else
                    throw new Exception("User already exist!");
            }
            else
                throw new Exception(GetErrorMessage());
        }

        private string GetErrorMessage() 
        {
            if (String.IsNullOrEmpty(User?.Name)) return "Name cannot be empty!";
            if (!User?.Email?.IsEmailValid()??false) return "Email is not Valid!";
            if (String.IsNullOrEmpty(User?.Password) || !(User?.Password?.Equals(User?.Password2)??false)) return "Incorrect password!";
            else return "Unknown error!";
        }



    }
}
