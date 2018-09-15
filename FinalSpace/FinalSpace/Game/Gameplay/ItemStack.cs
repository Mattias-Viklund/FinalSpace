using FinalSpace.Game.Gameplay.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Game.Gameplay
{
    class ItemStack
    {
        public ItemBase item;
        public int count = 0;

        public ItemStack(ItemBase item)
        {

        }

        public bool CanStack(int count)
        {
            this.count -= count;
            if (this.count > 0)
            {
                return true;

            }
            else
            {
                this.count += count;
                return false;

            }
        }
    }
}
