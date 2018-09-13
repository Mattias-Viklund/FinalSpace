using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Game.Gameplay
{
    class Inventory
    {
        private List<ItemBase> items;
        private int inventorySize;

        public Inventory(int inventorySize)
        {
            this.inventorySize = inventorySize;

            items = new List<ItemBase>();

        }

        public bool TryAddItem(ItemBase item)
        {
            if (items.Count < inventorySize)
            {
                items.Add(item);
                return true;

            }
            else
                return false;

        }

        public void RemoveItem(int index)
        {


        }

        public int TryFindItem(int ID)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].itemID == ID)
                    return i;

            }
            return 0;

        }
    }
}
