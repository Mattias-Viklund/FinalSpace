using FinalSpace.Game.Gameplay.GameplayBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Game.Gameplay.Items
{
    class EMPTY : ItemBase
    {
        public EMPTY()
            : base(false)
        {

        }

        public override bool CanSell()
        {
            return false;

        }

        public override bool CanStack()
        {
            return false;

        }

        public override int GetMaxStack()
        {
            return 0;

        }

        public override string GetName()
        {
            return "EMPTY";

        }

        public override int GetValue()
        {
            return 0;

        }

        public override bool IsConsumable()
        {
            return false;

        }

        public override void UseItem(GameState state)
        {
            state.GetTextBox().PushString("Item has no effect.");

        }
    }
}
