using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using FinalSpace.Rendering;

namespace FinalSpace.Game.Gameplay.Stars
{
    abstract class Planet : Drawable
    {
        // WHELP
        private Texture texture;
        private Hexagon hexagon;
        private CircleShape orbit;
        private float hexagonSize;
        private float orbitSize;
        private Vertex[] linesFromCenter;
        private Vertex[] lines;
        private Text text;
        private string planetName;

        // Friendlyness = 0-99 (50 normal)
        // Friendfactor = -(Friendlyness / 100)
        // Wealth { Rich, Wealthy, Normal, Poor, Primitive, None }
        // Valuables = Item * friendFactor
        // WillBuy = Item

        public int friendlyNess = 50;
        public int friendFactor = 1;

        public enum Wealth
        {
            Rich,
            Wealthy,
            Fine,
            Poor,
            Primitive,
            Wasteland

        }

        public Planet(Texture texture, float size, Vector2f globalPosition)
        {
            this.hexagonSize = size;
            this.orbitSize = size + 50;
            this.texture = texture;
            hexagon = new Hexagon(size, globalPosition, texture);
            orbit = new CircleShape(size + 50);
            orbit.Position = new Vector2f(globalPosition.X - size - 50, globalPosition.Y - size - 50);
            orbit.FillColor = Color.Transparent;
            orbit.OutlineColor = Color.White;
            orbit.OutlineThickness = 1.0f;
            lines = new Vertex[2];
            linesFromCenter = new Vertex[2];
            linesFromCenter[0] = new Vertex(globalPosition);
            linesFromCenter[1] = new Vertex(hexagon.Pivot(new Vector2f(globalPosition.X, globalPosition.Y), -60, size * 2));
            text = new Text("PLANET: ", Program.gameFont, 20);
            text.Position = new Vector2f(linesFromCenter[1].Position.X, linesFromCenter[1].Position.Y - 25);
            lines[0] = linesFromCenter[1];
            lines[1] = linesFromCenter[1];

        }

        public void SetName(string s)
        {
            this.planetName = s;
            text.DisplayedString = "PLANET: "+s;
            lines[1] = new Vertex(new Vector2f(linesFromCenter[1].Position.X+31*s.Length, linesFromCenter[1].Position.Y));

        }

        public abstract string SendMessage(String message, GameState gameState);
        public abstract string GetGreetings(GameState gameState);

        public float GetSize()
        {
            return hexagonSize;

        }

        public float GetOrbitSize()
        {
            return orbitSize;

        }

        public Vector2f GetPosition()
        {
            return orbit.Position;

        }

        public string GetName()
        {
            return planetName;

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                (target as RenderWindow).Draw(hexagon);
                (target as RenderWindow).Draw(linesFromCenter, PrimitiveType.Lines);
                (target as RenderWindow).Draw(lines, PrimitiveType.Lines);
                (target as RenderWindow).Draw(text);

                if (Program._debug)
                {
                    Vertex[] vLine = { new Vertex(new Vector2f(640, 0), Color.Yellow), new Vertex(new Vector2f(640, 720), Color.Yellow) };
                    Vertex[] hLine = { new Vertex(new Vector2f(0, 360), Color.Yellow), new Vertex(new Vector2f(1280, 360), Color.Yellow) };

                    (target as RenderWindow).Draw(hLine, PrimitiveType.Lines);
                    (target as RenderWindow).Draw(vLine, PrimitiveType.Lines);

                }
            }
        }
    }
}