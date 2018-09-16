using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Window;

using FinalSpace.Rendering;
using SFML.Graphics;

namespace FinalSpace.Game
{
    abstract class StateBase
    {
        // Macro that executes when something inherits from StateBase
        static int states = 0; // Keeps track of how many statebase instances there are.
        public StateBase()
        {
            // Set stateID of instance and increment
            stateID = states;
            states++;

        }

        // Return state identification
        private int stateID;
        public int GetID()
        {
            return stateID;

        }

        // Init
        public abstract void Init(RenderWindow window);

        // Core
        public abstract void Update(Time time);
        public virtual void Update(Time time, RenderWindow window) { }
        public abstract void FixedUpdate(Time time);
        public abstract void Render(ref DrawQueue queueOut);
        public virtual void SendLine(string s) { }

        // Input
        public abstract void KeyUp(object sender, KeyEventArgs e);
        public abstract void MouseUp(object sender, MouseButtonEventArgs e);
        public abstract void KeyDown(object sender, KeyEventArgs e);
        public abstract void MouseMoved(object sender, MouseMoveEventArgs e);
        public abstract void MouseDown(object sender, MouseButtonEventArgs e);
        public abstract void MouseScrolled(object sender, MouseWheelEventArgs e);

    }
}
