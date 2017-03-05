using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HockeyEditor;

namespace ChatBot
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryEditor.Init();



            while (true)
            {
                Player lP = PlayerManager.LocalPlayer;

                HQMVector myZone = new HQMVector(15, 0, 15);

                if (lP.Position.Z < Puck.Position.Z + 10f)
                {
                    Action.ChasePuck();
                }
                else
                {
                    //head back to own zone before trying to get possesion to avoid driving the puck towards own net.
                    Action.GoTo(myZone);
                }

                System.Threading.Thread.Sleep(60);

                
                
            }
                     
        }
    }
}



                
                



    



