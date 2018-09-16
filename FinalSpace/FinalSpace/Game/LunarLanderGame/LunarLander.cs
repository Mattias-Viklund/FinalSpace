using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Rendering;
using FinalSpace.Util;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace FinalSpace.Game.LunarLanderGame
{
    class LunarLander : StateBase
    {
        private DrawQueue drawQueue = new DrawQueue(256);
        private Lander lander = new Lander(new Vector2f(200, 200));

        private View view = new View(new FloatRect(new Vector2f(0, 0), new Vector2f(1280, 720)));
        private Text magnitude = new Text("Velocity: ", Program.gameFont, 20);

        private Vector2f thrust = new Vector2f(0, 0);
        private Vector2f Zero = new Vector2f(0, 0);

        public override void Init(RenderWindow render)
        {
            render.SetView(view);
            magnitude.Position = new Vector2f(50, 50);

        }


        public override void Update(Time time)
        {
            lander.AddForce(thrust * time.AsSeconds());

        }

        public override void Update(Time time, RenderWindow window)
        {
            // UPDATE
            lander.Update(time);
            magnitude.DisplayedString = "Velocity Magnitude: " + lander.GetMagnitude();

            window.SetView(view);

            // PUT IN RENDER QUEUE
            drawQueue.Clear();
            drawQueue.QueueItem(lander);
            drawQueue.QueueItem(magnitude);

        }

        public override void FixedUpdate(Time time)
        {

        }

        public override void Render(ref DrawQueue queueOut)
        {
            queueOut = drawQueue;

        }

        public override void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
                Program.Close(null, null);

            thrust = Zero;

            switch (e.Code)
            {
                case Keyboard.Key.W: thrust = new Vector2f(0, -10); break;
                case Keyboard.Key.S: thrust = new Vector2f(0, 10); break;
                case Keyboard.Key.E: RotateShip(5); break;
                case Keyboard.Key.Q: RotateShip(-5); break;

            }
        }

        private void RotateShip(float angle)
        {
            lander.Rotate(angle);

        }

        public override void KeyUp(object sender, KeyEventArgs e)
        {

        }

        public override void MouseUp(object sender, MouseButtonEventArgs e)
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
            float change = 1;
            if (e.Delta == -1)
                change = 1.01f;
            if (e.Delta == 1)
                change = 0.99f;

            view.Zoom(change);

        }
    }
}
