using CommunityToolkit.Mvvm.ComponentModel;
using TicTacToe.Common;
using TicTacToe.Database.Model;
using TicTacToe.Database.Repositories;

namespace TicTacToe.Pages.SingIn
{
    public partial class SingInViewModel : ObservableObject
    {
        private readonly IHashService hashService;
        private readonly IBaseRepository<User> userRepository;
        private UserSession userSession;
        public SingInViewModel(IHashService hashService, IBaseRepository<User> userRepository, UserSession userSession) 
        {
            this.hashService = hashService;
            this.userRepository = userRepository;
            this.userSession = userSession;
        }

        [ObservableProperty]
        private UserLoginModel user = new();

        public async Task<bool> Login() 
        {
            var user = (await userRepository.GetItems(x => x.Email.Equals(User.Email)))?.FirstOrDefault();
            if (user!= null)
            {
                if (hashService.Verify(User.Password, user.Password))
                {
                    userSession.CurrentUser = user;
                    user.LastLogin = DateTime.Now.Ticks;
                    await userRepository.UpdateItem(user);
                    return true;
                }
            }
            throw new Exception("Bad email or password!");
        }

    }
}
