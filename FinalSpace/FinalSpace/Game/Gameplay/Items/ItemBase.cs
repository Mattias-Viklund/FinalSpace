using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Game.Gameplay.Items
{
    abstract class ItemBase
    {
        public static List<ItemBase> items;
        private static int currentID = 0;

        public int itemID;

        public static void InitializeList()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly asm in assemblies)
            {
                foreach (Type t in asm.GetTypes())
                {
                    if (t.IsSubclassOf(typeof(ItemBase)))
                        Activator.CreateInstance(t);

                }

            }
        }

        public ItemBase(bool macro = true)
        {
            if (macro)
                items.Add(this);

            this.itemID = currentID;
            currentID++;

        }

        public abstract void UseItem(GameState state);

        public abstract bool IsConsumable();
        public abstract bool CanStack();
        public abstract bool CanSell();

        public abstract string GetName();

        public abstract int GetMaxStack();
        public abstract int GetValue();

    }
}
