using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Rendering
{
    class DrawQueue : Drawable
    {
        private Drawable[] drawables;
        private int queuedItems = 0;
        private int maxItems;

        private int drawTo = 0;

        // Drawable is anything that can be drawn by a RenderWindow.
        // This creates a static array that can be filled with drawables.
        public DrawQueue(int maxItems)
        {
            drawables = new Drawable[maxItems];
            this.maxItems = maxItems;

        }

        // Set all entries in the array to null;
        public void Clear()
        {
            drawTo = 0;

            //for (int i = 0; i < queuedItems; i++)
            //{
            //    drawables[i] = null;

            //}

            //queuedItems = 0;

        }

        // Interface Draw function, passes (hopefully) a RenderWindow as a target.
        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                for (int i = 0; i < drawTo; i++)
                {
                    if (drawTo == maxItems-1)
                        break;

                    // If nothing is at the Draw Queue index, we shouldn't expect more data.
                    //if (drawables[i] == null)
                    //    break;

                    // Draw all items in the queue;
                    (target as RenderWindow).Draw(drawables[i]);

                }
            }
        }

        // Returns the success of the operation.
        public bool QueueItem(Drawable d)
        {
            if (queuedItems == maxItems)
                return false;

            drawables[drawTo] = d;
            drawTo++;

            return true;

        }
    }
}
