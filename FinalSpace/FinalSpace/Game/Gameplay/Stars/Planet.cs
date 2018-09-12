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
        private Texture texture;
        private Hexagon hexagon;
        private CircleShape orbit;
        private float hexagonSize;
        private float orbitSize;
        private Vertex[] lines;
        private Text text;

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
            lines[0] = new Vertex(globalPosition);
            lines[1] = new Vertex(new Vector2f(globalPosition.X, globalPosition.Y-size*2));
            text = new Text("Planet: ", Program.gameFont, 20);
            text.Position = new Vector2f(globalPosition.X-3, globalPosition.Y - size * 2 - 20);

        }

        public void SetName(string s)
        {
            text.DisplayedString = "Planet: "+s;

        }

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

        //string[] names = { "EARTH", "MARS", "TERRA", "VALLES", "MONTES", "COLLES", "FARRA", "THOLI",
        //                     "PALUDES", "DORSA", "RIMAE", "CATANAE", "MACUL","FRETA","UNDAE","OBEROM","", };
        //public static string GetRandomName()
        //{
        //    Random rng = new Random();



        //}

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                (target as RenderWindow).Draw(hexagon);
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