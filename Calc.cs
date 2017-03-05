using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HockeyEditor;

namespace ChatBot
{
    public static class Calc
    {
        public static float Angle(HQMVector v1, HQMVector v2)
        {
            double x = v1.X - v2.X;
            double z = v1.Z - v2.Z;

            return (float)(Math.Atan2(x, z)*-180 / Math.PI ); 
        }
        public static float DistanceSquared(HQMVector v1, HQMVector v2)
        {
            return ((v1.X - v2.X) * (v1.X - v2.X) + (v1.Z - v2.Z) * (v1.Z - v2.Z));
        }

        public static float PlayerAngle(Player p)
        {
            double angle = Math.Atan2(p.CosRotation, p.SinRotation);
            double degrees = angle * (180.0 / Math.PI);
            return (float)degrees;
        }

        public static Player ClosestPlayer(HQMVector v)
        //Gets the closest player from any team to the puck
        {
            Player closestPlayer = null;
            float playerDistance = 999f;

            foreach (Player p in PlayerManager.Players)
            {
                if (Calc.DistanceSquared(p.Position, v) < playerDistance)
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
                if (p.Goals > goals)
                {
                    goals = p.Goals;
                    assists = p.Assists;
                    leader = p;
                }
                else if (p.Goals == goals)
                {
                    if (p.Assists > assists)
                    {
                        assists = p.Assists;
                        leader = p;
                    }
                }

            }

            return leader;
        }




    }
}
