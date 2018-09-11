using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game.Gameplay.Characters;

namespace FinalSpace.Game.Gameplay
{
    abstract class Star
    {
        public abstract string GetName();
        public abstract Leader GetLeader();

    }
}
