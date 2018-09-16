using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using SFML.Graphics;
using SFML.Window;
using SFML.System;

using FinalSpace.Game;
using FinalSpace.GUI;
using FinalSpace.Rendering;
using FinalSpace.Game.Gameplay.Communication;
using FinalSpace.Game.LunarLanderGame;

namespace FinalSpace
{
    class Program
    {
        public static bool _debug = false;

        const int width = 1280;
        const int height = 720;

        public static RenderWindow _window = new RenderWindow(new VideoMode((uint)width, (uint)height), "FINAL SPACE", Styles.Close);
        public static Font gameFont = new Font(".\\Assets\\LucidaConsole.ttf");

        // Ticks Per Second
        const uint TPS = 20;

        private static MenuState menuState = new MenuState();
        private static GameState gameState = new GameState();
        private static LunarLander lunarGame = new LunarLander();

        // Initialize the states
        public static StateBase currentState = gameState;
        public static StateBase newState = gameState;

        static DrawQueue drawQueue = new DrawQueue(256);

        static void Main(string[] args)
        {
            //Console.Title = "FINAL SPACE DEBUGGER";
            Conversation.ReadFromFile(".\\Assets\\Dictionary.txt");
            
            SetIcon(".\\Assets\\icon.png");
            Setup();
            GameLoop();

        }

        static void SetIcon(string path)
        {
            Image img = new Image(path);
            _window.SetIcon(img.Size.X, img.Size.Y, img.Pixels);

        }

        #region Setup
        static void Setup()
        {
            _window.Closed += new EventHandler(Close);
            _window.KeyPressed += new EventHandler<KeyEventArgs>(KeyDown);
            _window.KeyReleased += new EventHandler<KeyEventArgs>(KeyUp);
            _window.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(MouseDown);
            _window.MouseButtonReleased += new EventHandler<MouseButtonEventArgs>(MouseUp);
            _window.MouseMoved += new EventHandler<MouseMoveEventArgs>(MouseMoved);
            _window.MouseWheelMoved += new EventHandler<MouseWheelEventArgs>(MouseScrolled);

            //ShowWindow(GetConsoleWindow(), SW_HIDE);

        }

        private static void MouseScrolled(object sender, MouseWheelEventArgs e)
        {
            currentState.MouseScrolled(sender, e);

        }

        private static void MouseMoved(object sender, MouseMoveEventArgs e)
        {
            currentState.MouseMoved(sender, e);

        }

        private static void MouseUp(object sender, MouseButtonEventArgs e)
        {
            currentState.MouseUp(sender, e);
        }

        private static void MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentState.MouseDown(sender, e);
        }

        private static void KeyUp(object sender, KeyEventArgs e)
        {
            currentState.KeyUp(sender, e);
        }

        private static void KeyDown(object sender, KeyEventArgs e)
        {
            currentState.KeyDown(sender, e);
        }



        public static void Close(object sender, EventArgs e)
        {
            _window.Close();

        }
        #endregion

        static void GameLoop()
        {
            Time timePerUpdate = Time.FromSeconds(1.0f / (float)TPS);
            uint ticks = 0;

            Clock timer = new Clock();

            // Timing variables
            Time lastTime = Time.Zero; // Set to time of last frame
            Time lag = Time.Zero; // For FixedUpdate()
            Time time = Time.Zero; // Time of current frame
            Time deltaTime = Time.Zero; // Deta time of frame

            currentState.Init(_window);

            while (_window.IsOpen)
            {
                if (currentState.GetID() != newState.GetID())
                    SwapState();

                time = timer.ElapsedTime;
                deltaTime = time - lastTime;

                lastTime = time;
                lag += deltaTime;

                // Dispatch window events and feed them to the current state
                _window.DispatchEvents();
                currentState.Update(deltaTime);
                currentState.Update(deltaTime, _window);

                //Fixed time update
                while (lag >= timePerUpdate)
                {
                    ticks++;
                    lag -= timePerUpdate;
                    currentState.FixedUpdate(deltaTime);

                }

                // Hand over control of the drawQueue to the current state.
                currentState.Render(ref drawQueue);

                // Clear the window and prepare for next draw;
                _window.Clear();
                // Draw our framebuffer
                _window.Draw(drawQueue);
                _window.Display();

            }
        }

        public static void PushState(StateBase state)
        {

        }

        static void SwapState()
        {
            currentState = newState;
            currentState.Init(_window);

        }
    }
}
