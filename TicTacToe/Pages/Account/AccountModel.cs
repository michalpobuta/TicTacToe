using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Extensions;

namespace TicTacToe.Pages.Account
{
    public partial class AccountModel : ObservableObject
    {
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string email;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PhotoFullPath))]
        private string photoPath;

     
        public string PhotoFullPath => PhotoPath != null ? Path.Combine(FileSystem.Current.AppDataDirectory, PhotoPath) : "";

        internal bool IsValid()
        {
            return !String.IsNullOrEmpty(Name) && Email.IsEmailValid();
        }
    }
}
