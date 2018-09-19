using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Game.CubeGame
{
    struct Vector3f
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3f(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;

        }

        public static Vertex ToVertex(Vector3f vec)
        {
            Vector2f vec1 = new Vector2f();
            Vector2f vec2 = new Vector2f();

        }

        #region operators
        public static Vector3f operator +(Vector3f left, float scalar)
        {
            return new Vector3f(left.X + scalar, left.Y + scalar, left.Z + scalar);

        }

        public static Vector3f operator -(Vector3f left, float scalar)
        {
            return new Vector3f(left.X - scalar, left.Y - scalar, left.Z - scalar);

        }

        public static Vector3f operator *(Vector3f left, float scalar)
        {
            return new Vector3f(left.X * scalar, left.Y * scalar, left.Z * scalar);

        }

        public static Vector3f operator /(Vector3f left, float scalar)
        {
            if (scalar == 0)
                return new Vector3f(0, 0, 0);

            return new Vector3f(left.X / scalar, left.Y / scalar, left.Z / scalar);

        }

        public static Vector3f operator *(Vector3f left, Vector3f right)
        {
            return new Vector3f(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

        }

        public static Vector3f operator/(Vector3f left, Vector3f right)
        {
            if (right.X == 0 || right.Y == 0 || right.Z == 0)
                return new Vector3f(0, 0, 0);

            return new Vector3f(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

        }

        public static Vector3f operator +(Vector3f left, Vector3f right)
        {
            return new Vector3f(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        }

        public static Vector3f operator -(Vector3f left, Vector3f right)
        {
            return new Vector3f(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        }
        #endregion

    }
}
