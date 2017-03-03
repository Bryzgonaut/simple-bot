using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HockeyEditor;

namespace API_test
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryEditor.Init();

            

        }
    }

    public static class Calc
    {
        public static float DistanceSquared (HQMVector v1, HQMVector v2)
        //returns squared distance between 2 HQNVectors
        //useful when only comparative distance is needed, to avoid costly sqrt operation.
        {
            return ((v1.X - v2.X) * (v1.X - v2.X) + (v1.Z - v2.Z) * (v1.Z - v2.Z));
        }




        public static Player ClosestPlayer(HQMVector v)
        //Gets the closest player from any team to the puck
        {
            Player closestPlayer = null;
            float playerDistance = 999;

            foreach (Player p in PlayerManager.Players)
            {
                if (Calc.DistanceSquared(p.Position,v) < playerDistance)
                {
                    playerDistance = Calc.DistanceSquared(p.Position, v);
                    closestPlayer = p;
                }
            }

            return closestPlayer;
        }

        public static Player ClosestOpponent(HQMVector v)
        //Gets the closest player from the opposite team
        {
            Player closestPlayer = null;
            float playerDistance = 999;

            foreach (Player p in PlayerManager.Players)
            {
                if ((Calc.DistanceSquared(p.Position, v) < playerDistance) && (p.Team != PlayerManager.LocalPlayer.Team))
                {
                    playerDistance = Calc.DistanceSquared(p.Position, v);
                    closestPlayer = p;
                }
            }

            return closestPlayer;
        }

        public static Player ClosestTeammate(HQMVector v)
        //Gets the closest player from the same team
        {
            Player closestPlayer = null;
            float playerDistance = 999;

            foreach (Player p in PlayerManager.Players)
            {
                if ((Calc.DistanceSquared(p.Position, v) < playerDistance)&&(p.Team==PlayerManager.LocalPlayer.Team))
                {
                    playerDistance = Calc.DistanceSquared(p.Position, v);
                    closestPlayer = p;
                }
            }

            return closestPlayer;
        }



    }
}
