
using TicTacToe.Pages.SingIn;

namespace TicTacToe
{
    public partial class MainPage : ContentPage
    {
        private readonly IServiceProvider serviceProvider;
        View imageView;
        readonly MainPageViewModel _mainPageViewModel;
        public MainPage(IServiceProvider serviceProvider, MainPageViewModel _mainPageViewModel)
        {
            this._mainPageViewModel = _mainPageViewModel;
            this.serviceProvider = serviceProvider;
            InitializeComponent();
        }
        public void ChangePage() 
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(serviceProvider.GetService(typeof(SingInView)) as SingInView);
            });
        }
        private void ImageOnHandlerChanged(object sender, EventArgs e)
        {
            imageView = sender as View;
        }
        private void GridOnHandlerChanged(object sender, EventArgs e)
        {
            _mainPageViewModel.TransitionFadeTo(sender as View, FadeToCompleted);
        }

        void FadeToCompleted()
        {
            _mainPageViewModel.TransitionTranslateToTop(imageView, ToTopCompleted);
        }
        void ToTopCompleted()
        {
            imageView.IsVisible = false;
            ChangePage();
        }

    }

}
