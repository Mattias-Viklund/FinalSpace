using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Game.Gameplay.Characters
{
    abstract class Citizen
    {
        public abstract string GetName();
        public abstract int GetAge();
        public abstract int Power();

    }
}
