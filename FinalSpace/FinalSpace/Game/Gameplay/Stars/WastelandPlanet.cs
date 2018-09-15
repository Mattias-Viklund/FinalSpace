using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace FinalSpace.Game.Gameplay.Stars
{
    class WastelandPlanet : Planet
    {
        public WastelandPlanet(Texture texture, float size, Vector2f globalPosition)
            : base(texture, size, globalPosition)
        {


        }

        public override string GetGreetings(GameState gameState)
        {
            throw new NotImplementedException();
        }

        public override string SendMessage(String message, GameState gameState)
        {
            throw new NotImplementedException();
        }
    }
}
