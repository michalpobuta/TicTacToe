using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Pages.MainMenu
{
    public class MainMenuModel
    {
        public string Name { get; set; }
        public string PhotoFullPath { get; set; }
        public int[] EasyBotWDL { get; set; }
        public int[] MediumBotWDL { get; set; }
        public int[] HardBotWDL { get; set; }

        public string EasyBotWDLString => EasyBotWDL?.Length ==3 ? $"{EasyBotWDL[0]}/{EasyBotWDL[1]}/{EasyBotWDL[2]}" : "";
        public string MediumBotWDLString => MediumBotWDL?.Length ==3 ? $"{MediumBotWDL[0]}/{MediumBotWDL[1]}/{MediumBotWDL[2]}" : "";
        public string HardBotWDLString => HardBotWDL?.Length ==3 ? $"{HardBotWDL[0]}/{HardBotWDL[1]}/{HardBotWDL[2]}" : "";


    }
}
