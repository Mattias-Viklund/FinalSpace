using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.GUI
{
    abstract class GUIElement : Drawable
    {
        public abstract void SendKey(Keyboard.Key key);
        public abstract void MouseEvent();
        public abstract void Draw(RenderTarget target, RenderStates states);

    }
}
    