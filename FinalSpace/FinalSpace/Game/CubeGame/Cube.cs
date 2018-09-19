using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace FinalSpace.Game.CubeGame
{
    class Plane : Drawable
    {
        public Vertex[] tri1;
        public Vertex[] tri2;

        public Plane(int width, int height, int size)
        {
            Vector2f center = new Vector2f(width / 2, height / 2);

            Vertex common1 = new Vertex(new Vector2f(center.X + size, center.Y - size), Color.Red);
            Vertex common2 = new Vertex(new Vector2f(center.X - size, center.Y + size), Color.Green);

            tri1 = new Vertex[3];
            tri2 = new Vertex[3];

            tri1[0] = new Vertex(new Vector2f(center.X - size, center.Y - size), Color.Black);
            tri1[1] = common1;
            tri1[2] = common2;

            tri2[0] = new Vertex(new Vector2f(center.X + size, center.Y + size), Color.Blue);
            tri2[1] = common2;
            tri2[2] = common1;

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                (target as RenderWindow).Draw(tri1, PrimitiveType.Triangles);
                (target as RenderWindow).Draw(tri2, PrimitiveType.Triangles);

            }
        }
    }
}
