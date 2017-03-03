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
            float playerDistance = 999f;

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
            float playerDistance = 999f;

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
        //Gets the closest player from the same team, excluding self
        {
            Player closestPlayer = null;
            float playerDistance = 999f;

            foreach (Player p in PlayerManager.Players)
            {
                if ((Calc.DistanceSquared(p.Position, v) < playerDistance) && (p.Team == PlayerManager.LocalPlayer.Team) && (p.Name != PlayerManager.LocalPlayer.Name))
                {
                    playerDistance = Calc.DistanceSquared(p.Position, v);
                    closestPlayer = p;
                }
            }

            return closestPlayer;
        }

        public static Player LeadingScorer()
        //Gets the player with the most goals
        {
            Player leader = null;
            int goals = 0;
            int assists = 0;

            foreach (Player p in PlayerManager.Players)
            {
                if (p.Goals>goals)
                {
                    goals = p.Goals;
                    assists = p.Assists;
                    leader = p;
                }
                else if  (p.Goals == goals)
                {
                    if (p.Assists>assists)
                    {
                        assists = p.Assists;
                        leader = p;
                    }
                }
                
            }

            return leader;
        }

        public static HQMVector Extrapolate(HQMVector cPos, HQMVector angle, float speed, float drag, float time)
        //Calculates position if object continues on same path. 
        //Does not attempt to account for vertical arc, so should only be used for players and sliding puck. 
        // NOT FUCTIONAL YET
        {
            float gravity = 9.8f;
            HQMVector endPoint = new HQMVector(0,0,0);

            return endPoint;


        }

    }
}
