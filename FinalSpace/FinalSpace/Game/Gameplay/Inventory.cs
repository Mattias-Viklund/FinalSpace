using FinalSpace.Game.Gameplay.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Game.Gameplay
{
    class Inventory
    {
        private List<ItemStack> slots;
        private int inventorySize;

        public Inventory(int inventorySize)
        {
            this.inventorySize = inventorySize;

            slots = new List<ItemStack>();

        }

        public bool TryAddItem(ItemBase item, int count)
        {
            foreach (ItemStack stack in slots)
            {
                if (stack.item.itemID == item.itemID)
                {
                    stack.count += count;
                    if (stack.count > stack.item.GetMaxStack())
                    {
                        stack.count -= count;
                        return false;

                    }
                    else
                    return true;

                }

            }

            return true;
        }

        public void RemoveItem(int index)
        {


        }

        public int TryFindItem(int ID)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].item.itemID == ID)
                    return i;

            }
            return 0;

        }
    }
}
