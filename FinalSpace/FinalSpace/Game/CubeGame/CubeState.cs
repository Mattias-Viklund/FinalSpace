using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Rendering;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace FinalSpace.Game.CubeGame
{
    class CubeState : StateBase
    {
        private DrawQueue drawQueue = new DrawQueue(256);
        private Plane cube = new Plane((int)Program._window.Size.X, (int)Program._window.Size.Y, 100);

        public override void Init(RenderWindow window)
        {
            window.SetTitle("CubeGame");

        }

        public override void KeyDown(object sender, KeyEventArgs e)
        {

        }

        public override void KeyUp(object sender, KeyEventArgs e)
        {

        }

        public override void MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        public override void MouseMoved(object sender, MouseMoveEventArgs e)
        {

        }

        public override void MouseScrolled(object sender, MouseWheelEventArgs e)
        {

        }

        public override void MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        public override void Update(Time time)
        {
            drawQueue.Clear();

            drawQueue.QueueItem(cube);

        }

        public override void FixedUpdate(Time time)
        {

        }

        public override void Render(ref DrawQueue queueOut)
        {
            queueOut = drawQueue;

        }
    }
}
