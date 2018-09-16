using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

using FinalSpace.Rendering;
using FinalSpace.GUI;
using FinalSpace.Game.Gameplay.Stars;

namespace FinalSpace.Game
{
    class MenuState : StateBase
    {
        private DrawQueue queue = new DrawQueue(256);
        private RectangleShape background = new RectangleShape((Vector2f)Program._window.Size);

        public override void Init(RenderWindow window)
        {
            background.Texture = new Texture(".\\Assets\\Background.png");

        }

        public override void Update(Time time)
        {
            queue.Clear();
            queue.QueueItem(background);

        }

        public override void FixedUpdate(Time time)
        {

        }

        public override void Render(ref DrawQueue queueOut)
        {
            queueOut = queue;

        }

        public override void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
                Program.Close(null, null);

        }

        public override void KeyUp(object sender, KeyEventArgs e)
        {

        }

        public override void MouseMoved(object sender, MouseMoveEventArgs e)
        {

        }

        public override void MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        public override void MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        public override void MouseScrolled(object sender, MouseWheelEventArgs e)
        {

        }
    }
}
