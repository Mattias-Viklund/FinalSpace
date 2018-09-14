using FinalSpace.Game.Gameplay.GameplayBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Game.Gameplay.Items
{
    class Test : ItemBase
    {
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
            return 32;
        }

        public override string GetName()
        {
            return "TEST";
        }

        public override int GetValue()
        {
            return 1000;

        }

        public override bool IsConsumable()
        {
            return true;

        }

        public override void UseItem(GameState state)
        {
            state.GetTextBox();

        }
    }
}
