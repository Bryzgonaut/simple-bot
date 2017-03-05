using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HockeyEditor;

namespace ChatBot
{
    public static class GameStats
    {
        public static HQMTeam myTeam = PlayerManager.LocalPlayer.Team;
        public static int myTeamScore
        {
            get
            {
                if (PlayerManager.LocalPlayer.Team == HQMTeam.Blue)
                {
                    return GameInfo.BlueScore;
                }
                else if (PlayerManager.LocalPlayer.Team == HQMTeam.Red)
                {
                    return GameInfo.RedScore;
                }
                else return 0;

            }
        }
    }
}
