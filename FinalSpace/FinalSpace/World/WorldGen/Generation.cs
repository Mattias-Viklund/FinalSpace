using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game.Gameplay.Stars;
using SFML.Graphics;
using SFML.System;

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
                planets[i] = new InhabitablePlanet(new Texture(".\\assets\\Planet.png"), 50, new Vector2f(1280/2, 720/2));


            }

            return planets;

        }
    }
}
