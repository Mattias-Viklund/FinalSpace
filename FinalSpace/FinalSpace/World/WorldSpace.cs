using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.World
{
    public struct WorldSpace
    {
        public int X;
        public int Y;
        public int Z;

        public WorldSpace(int X, int Y, int Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;

        }

        public static float GetDistance(WorldSpace left, WorldSpace right)
        {
            float width = Math.Abs(left.X - right.X);
            float depth = Math.Abs(left.Z - right.Z);
            float height = Math.Abs(left.Y - right.Y);

            float spaceDiagonal = (float)Math.Sqrt(Math.Pow(width, 2) + Math.Pow(depth, 2) + Math.Pow(height, 2));

            return spaceDiagonal;

        }
    }
}
