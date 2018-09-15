using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Game.Gameplay.Items
{
    class Spice : ItemBase
    {
        private string name;
        private int value;

        public Spice(string name, int value)
        {
            this.name = name;
            this.value = value;

        }

        public override bool CanSell()
        {
            return true;
        }

        public override bool CanStack()
        {
            return true;
        }

        public override int GetMaxStack()
        {
            return 64;
        }

        public override string GetName()
        {
            return name;
        }

        public override int GetValue()
        {
            return value;
        }

        public override bool IsConsumable()
        {
            return false;
        }

        public override void UseItem(GameState state)
        {
            state.PushString("Item '"+name+"' is not usable.");

        }
    }
}
