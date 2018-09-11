using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using FinalSpace.Rendering;
using SFML.Graphics;
using FinalSpace.Game.Gameplay.Stars;
using FinalSpace.GUI;
using FinalSpace.Core.Parsing;

namespace FinalSpace.Game
{
    class GameState : StateBase
    {
        private RectangleShape background = new RectangleShape((Vector2f)Program._window.Size);
        private Texture planetTexture = new Texture(".\\Assets\\Planet.png");
        private DrawQueue queue = new DrawQueue(256);

        private Vector2f shipOrbitPosition;
        private SpaceShip ship;
        private Planet planet;

        private TextBox textbox;

        private Parser parser;

        public override void Init()
        {
            background.Texture = new Texture(".\\Assets\\Background.png");
            planet = new Earth(planetTexture, 75, new Vector2f(Program._window.Size.X / 2, Program._window.Size.Y / 2));
            ship = new SpaceShip(new Vector2f(), Color.Red);
            ship.Scale(new Vector2f(0.25f, 0.25f));
            shipOrbitPosition = new Vector2f(planet.GetPosition().X + planet.GetOrbitSize()-ship.GetCenter().X/2, planet.GetPosition().Y + planet.GetOrbitSize() - ship.GetCenter().Y/2);
            background.FillColor = Color.White;

            textbox = new TextBox(new Vector2f(Program._window.Size.X, 180), new Vector2f(0, Program._window.Size.Y-180), 50, 20, Color.Black, Color.White, this);
            textbox.SetInputBox(true);

            parser = new Parser(this);

        }

        public TextBox GetTextBox()
        {
            return textbox;

        }

        public void ChangePlanetTexture(string path)
        {
            this.background.Texture = new Texture(path);

        }

        public override void Update(Time time)
        {
            ship.Update(time);

            // Draw Order
            queue.Clear();
            queue.QueueItem(background);
            queue.QueueItem(planet);
            queue.QueueItem(textbox);
            queue.QueueItem(ship);

        }

        public override void FixedUpdate(Time time)
        {
            ship.Orbit(time, shipOrbitPosition, planet.GetOrbitSize());

        }

        public override void Render(ref DrawQueue queueOut)
        {
            queueOut = queue;

        }

        public override void SendLine(string s)
        {
            Console.WriteLine(s);
            parser.Parse(s);

        }

        public override void KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        public override void MouseUp(object sender, MouseButtonEventArgs e)
        {
            

        }

        public override void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
                Program.Close(null, null);
            else
                textbox.SendKey(e.Code);
            
        }

        public override void MouseMoved(object sender, MouseMoveEventArgs e)
        {
            
        }

        public override void MouseDown(object sender, MouseButtonEventArgs e)
        {
         
        }
    }
}
