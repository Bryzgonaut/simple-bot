using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HockeyEditor;

namespace ChatBot
{
    public static class Speech
    {
        static string[] chatGreetings = { "hi", "hello", "hey", "sup", "yo", "ey" };
        static string[] insults = { "fuck you", "fuck off", "ur bad", "ur shit", "die", "pls leave" };
        static string[] chatGreetingsStart = { "hi ", "hello ", "hey ", "sup ", "yo ", "ey " };

        public static Chat.ChatMessage LastMessage
        {
            get
            {
                return Chat.ChatMessages[Chat.ChatMessages.Count - 1];
            }
        }

        public static void InsultPlayer(Player p)
        {
            //check to see if the player being insulted has done anything notable
            if ((p.Goals > GameStats.myTeamScore) && (p.Goals > 3))
            {
                Chat.SendChatMessage(p.Name + " you fucking ringer");
            }
            else
            {
                Chat.SendChatMessage("fuck you " + p.Name);
            }

                
        }

        public static void ComplimentPlayer(Player p)
        {
            Chat.SendChatMessage("good job " + p.Name);
        }





    }
}
