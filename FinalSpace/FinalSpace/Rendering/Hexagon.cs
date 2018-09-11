using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace FinalSpace.Rendering
{
    class Hexagon : Drawable
    {
        private Vector2f[] vectors;

        private Texture texture;
        private bool hasTexture = false;

        public Hexagon(float size, Vector2f globalPosition, Texture tex)
        {
            vectors = new Vector2f[7];
            vectors[0] = globalPosition;

            texture = tex;
            hasTexture = true;

            float hexagonAngle = 60;
            for (int i = 1; i < 7; i++)
            {
                vectors[i] = Pivot(vectors[0], hexagonAngle * i, size);

            }
        }

        private Vector2f Pivot(Vector2f center, float angleDeg, float size)
        {
            float angleRad = (float)Math.PI / 180 * angleDeg;
            return new Vector2f(center.X + size * (float)Math.Cos(angleRad), center.Y + size * (float)Math.Sin(angleRad));

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Texture = texture;

            if (target is RenderWindow)
            {
                for (int i = 0; i < 6; i++)
                {
                    int v1 = 0;
                    int v2 = i + 1;
                    int v3 = i + 2;

                    if (v3 == 7)
                        v3 = 1;

                    VertexArray verts = new VertexArray(PrimitiveType.Triangles, 3);
                    verts[0] = new Vertex(vectors[v2]/* + position*/) { TexCoords = new Vector2f(128, 0) };
                    verts[1] = new Vertex(vectors[v1]/* + position*/) { TexCoords = new Vector2f(128, 128) };
                    verts[2] = new Vertex(vectors[v3]/* + position*/) { TexCoords = new Vector2f(0, 128) };

                    if (hasTexture)
                        (target as RenderWindow).Draw(verts, states);
                    else
                        (target as RenderWindow).Draw(verts);

                }
            }
        }
    }
}
