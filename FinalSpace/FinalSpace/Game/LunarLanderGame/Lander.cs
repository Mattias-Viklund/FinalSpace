using FinalSpace.Util;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Game.LunarLanderGame
{
    class Lander : Drawable
    {
        private Vector2f[] lander =
        {
        new Vector2f (25, 0),
        new Vector2f(50, 25),
        new Vector2f(50, 75),
        new Vector2f (0, 75),
        new Vector2f (0, 25),
        new Vector2f (25, 0)
        };



        public Vector2f center = new Vector2f(25, 50);

        private Vector2f position;
        private Vector2f velocity;

        // VECTORS ARE FLIPPED IN WORLD SPACE
        private Vector2f acceleration = new Vector2f(0, 1) * 9.8f;

        public Lander(Vector2f pos)
        {
            position = pos;

        }

        public Vector2f GetPosition()
        {
            return position;

        }

        public void Rotate(float degrees)
        {
            for (int i = 0; i < lander.Length; i++)
            {
                lander[i] = VectorMaths.Pivot(new Vector2f(), degrees, VectorMaths.GetDistance(center, lander[i]), i);

            }
        }

        public float GetMagnitude()
        {
            return (float)Math.Sqrt(Math.Pow(velocity.X, 2) + Math.Pow(velocity.Y, 2));

        }

        public void AddForce(Vector2f force)
        {
            velocity += force;

        }

        public void AddVector(Vector2f vector)
        {
            position += vector;

        }

        public void Update(Time time)
        {
            float elapsedSeconds = time.AsSeconds();
            velocity += acceleration * elapsedSeconds;
            position += (velocity * elapsedSeconds);

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                for (int i = 0; i < lander.Length; i++)
                {
                    Vertex[] vecs = new Vertex[2];

                    vecs[0] = new Vertex(lander[i] + position);
                    if (i + 1 >= lander.Length)
                        vecs[1] = new Vertex(lander[0] + position);
                    else
                        vecs[1] = new Vertex(lander[i + 1] + position);

                    (target as RenderWindow).Draw(vecs, PrimitiveType.Lines);

                }
            }
        }
    }
}
