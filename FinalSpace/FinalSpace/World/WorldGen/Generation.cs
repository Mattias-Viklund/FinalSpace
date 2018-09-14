using FinalSpace.Game.Gameplay.GameplayBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game.Gameplay.Stars;

namespace FinalSpace.World
{
    class Generation
    {
        public static Planet[] GeneratePlanets(int planetCount)
        {
            Planet[] planets = new Planet[planetCount];
            Random rand = new Random();

            for (int i = 0; i < planetCount; i++)
            {
                planets[i] = new InhabitablePlanet();


            }
        }
    }
}
