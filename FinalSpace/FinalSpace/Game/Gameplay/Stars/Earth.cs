using FinalSpace.Game.Gameplay.Stars;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Game.Gameplay.Stars
{
    class Earth : Planet
    {
        public Earth(Texture texture, float size, Vector2f globalPosition)
            : base(texture, size, globalPosition)
        {
            base.SetName("EARTH");

        }

        public override string GetGreetings(GameState gameState)
        {
            return gameState.GetPlayer().GetCurrentPlanet().GetName() + ": Glad to see you made it back, " + gameState.GetPlayer().GetName();

        }

        public override string SendMessage(String message, GameState gameState)
        {
            return "a";

        }
    }
}
