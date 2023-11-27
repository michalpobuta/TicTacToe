using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public partial class MainPageViewModel : ObservableObject
    {
        public delegate void FadeToCompletedCallBack();
        public delegate void ToTopCompletedCallBack();

        private readonly int ANIMATION_START_TO_TOP_DELAY = 1000;
        private readonly int ANIMATION_START_FADE_IN_DELAY = 1000;
        private readonly uint ANIMATION_FADE_IN_TIME = 1000;
        private readonly uint ANIMATION_TO_TOP_TIME = 1000;
        private readonly int TRANSLATE_Y_DESTINATION_PIXELS = 0;

        public async void TransitionTranslateToTop(View view, ToTopCompletedCallBack toTopCompletedCallBack, int translateY = 0)
        {
            await Task.Delay(ANIMATION_START_TO_TOP_DELAY);

            if (translateY == 0)
            {
                translateY = (int)view.Y - TRANSLATE_Y_DESTINATION_PIXELS;
            }
            await view.TranslateTo(0, -translateY, ANIMATION_TO_TOP_TIME);
            await Task.Delay(500);
            toTopCompletedCallBack();
        }

        public async void TransitionFadeTo(View view, FadeToCompletedCallBack fadeToCompletedCallBack)
        {
            await Task.Delay(ANIMATION_START_FADE_IN_DELAY);
            await view.FadeTo(1, ANIMATION_FADE_IN_TIME);
            fadeToCompletedCallBack();
        }
    }
}
