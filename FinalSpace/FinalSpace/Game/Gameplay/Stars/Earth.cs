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

        }
    }
}
