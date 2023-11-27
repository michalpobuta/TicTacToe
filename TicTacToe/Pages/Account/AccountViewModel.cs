using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TicTacToe.Common;
using TicTacToe.Database.Model;
using TicTacToe.Database.Repositories;
using TicTacToe.Extensions;

namespace TicTacToe.Pages.Account
{
    public partial class AccountViewModel : ObservableObject
    {
        private readonly IBaseRepository<User> userRepository;
        private readonly UserSession userSession;
        private readonly PickerService pickerService;

        [ObservableProperty]
        private AccountModel accountModel;

        public AccountViewModel(IBaseRepository<User> userRepository, UserSession userSession, PickerService pickerService) 
        {
            this.userRepository = userRepository;
            this.userSession = userSession;
            this.pickerService = pickerService;
            GetUser();
        }

        private void GetUser() 
        {
            AccountModel = new AccountModel() { Name = userSession?.CurrentUser?.Name, Email = userSession?.CurrentUser?.Email, PhotoPath = String.IsNullOrEmpty(userSession?.CurrentUser?.PhotoPath) ? "dotnet_bot.jpg" : userSession.CurrentUser.PhotoPath };   
        }

        public async Task SaveUser() 
        {
            if (AccountModel.IsValid())
            {
                userSession.CurrentUser.Name = AccountModel.Name;
                userSession.CurrentUser.Email = AccountModel.Email;
                userSession.CurrentUser.PhotoPath = AccountModel.PhotoPath;
                await userRepository.UpdateItem(userSession.CurrentUser);
            }
            else
                throw new Exception(GetErrorMessage());
        }

        private string GetErrorMessage()
        {
            if (String.IsNullOrEmpty(AccountModel?.Name)) return "Name cannot be empty!";
            if (!(AccountModel?.Email?.IsEmailValid()??false)) return "Name cannot be empty!";
            else return "Unknown error!";
        }

        [RelayCommand]
        public async Task PickPhoto() 
        {
            AccountModel.PhotoPath = await pickerService.PickImage();
        }
        
    }
}
