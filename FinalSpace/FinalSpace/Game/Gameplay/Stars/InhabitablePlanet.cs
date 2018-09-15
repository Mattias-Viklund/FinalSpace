using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game.Gameplay.Stars;
using SFML.Graphics;
using SFML.System;

namespace FinalSpace.Game.Gameplay.Stars
{
    class InhabitablePlanet : Planet
    {
        public InhabitablePlanet(Texture texture, float size, Vector2f globalPosition)
            : base(texture, size, globalPosition)
        {


        }

        public override string GetGreetings(GameState gameState)
        {
            return "";

        }

        public override string SendMessage(String message, GameState gameStatee)
        {
            throw new NotImplementedException();
        }
    }
}
