using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Util
{
    class VectorMaths
    {
        public static Vector2f Pivot(Vector2f center, float angleDeg, float size, int count)
        {
            float degrees = angleDeg * count;
            float angleRad = (float)Math.PI / 180 * degrees;
            return new Vector2f(center.X + size * (float)Math.Cos(angleRad), center.Y + size * (float)Math.Sin(angleRad));

        }

        public static float GetDistance(Vector2f left, Vector2f right)
        {
            float width = Math.Abs(left.X - right.X);
            float height = Math.Abs(left.Y - right.Y);

            float distance = (float)Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2));

            return distance;

        }
    }
}
