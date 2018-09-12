using FinalSpace.Game.Gameplay.Stars;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Game
{
    class SpaceShip : Drawable
    {
        private Vector2f[] vecs = {
        new Vector2f(37.5f, 0), // 0
        new Vector2f(50, 10), // 1
        new Vector2f(50, 37.5f), // 2
        new Vector2f(37.5f, 30), // 3
        new Vector2f(37.5f, 60), // 4
        new Vector2f(50, 75), // 5
        new Vector2f(50, 100), // 6
        new Vector2f(37.5f, 100), // 7
        new Vector2f(35, 87.5f), // 8
        new Vector2f(15, 87.5f), // 9
        new Vector2f(12.5f, 100), // 10
        new Vector2f(0, 100), // 11
        new Vector2f(0, 75), // 12
        new Vector2f(12.5f, 60), // 13
        new Vector2f(12.5f, 30), // 14
        new Vector2f(0, 37.5f), // 15
        new Vector2f(0, 10), // 16
        new Vector2f(12.5f, 0)}; // 17

        private Vector2f position;
        private Color color;
        private float hCenter = 50;
        private float vCenter = 25;

        private float degreesPerTick = (360 / 20) / 10;

        private Text text;

        private RectangleShape warp = new RectangleShape((Vector2f)Program._window.Size);
        private float warpTime = 2; // IN SECONDS
        private float fadePerSec; // SET IN WARP()
        private float warpAlpha = 0;
        public bool warping = false;
        private bool reverse = false;

        public SpaceShip(Vector2f position, Color color)
        {
            this.position = position;
            this.color = color;

            text = new Text("", Program.gameFont);
            SetStatus("IN ORBIT", Color.White);

        }

        public void Scale(Vector2f scale)
        {
            hCenter *= scale.X;
            vCenter *= scale.Y;

            for (int i = 0; i < vecs.Length; i++)
            {
                vecs[i] = new Vector2f(vecs[i].X * scale.X - vCenter, vecs[i].Y * scale.Y - hCenter);

            }
        }

        public void Warp()
        {
            if (!warping)
            {
                warping = true;
                warp.FillColor = new Color(255, 255, 255, 0);
                SetStatus("WARPING", new Color(255, 165, 0));
                fadePerSec = 255 / warpTime;

            }
        }

        public Vector2f GetCenter()
        {
            return new Vector2f(hCenter, vCenter);

        }

        private int rotationPoint = 0;
        public void Orbit(Time deltaTime, Vector2f center, float distance)
        {
            this.position = Pivot(center, degreesPerTick, distance, rotationPoint);
            
            if (rotationPoint == 360)
                rotationPoint = 0;

            rotationPoint++;

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                Vertex[] v = new Vertex[2];
                text.Position = position;

                for (int i = 0; i < vecs.Length; i++)
                {
                    v[0] = new Vertex(vecs[i] + position, color);
                    if (i + 1 == 18)
                        v[1] = new Vertex(vecs[0] + position, color);
                    else
                        v[1] = new Vertex(vecs[i + 1] + position, color);

                    (target as RenderWindow).Draw(v, PrimitiveType.Lines);

                }

                (target as RenderWindow).Draw(text);

                if (warping)
                    (target as RenderWindow).Draw(warp);

            }
        }

        public void Update(Time time)
        {
            if (warping)
            {
                float timeSec = time.AsSeconds();
                float fade = timeSec * fadePerSec;
                warpAlpha += fade;

                if (reverse)
                    warp.FillColor = new Color(255, 255, 255, (byte)(255 - warpAlpha));
                else
                    if (warpAlpha < 255)
                    warp.FillColor = new Color(255, 255, 255, (byte)(warpAlpha));
                else
                {
                    warpAlpha = 0;
                    reverse = true;


                }

                if (warpAlpha > 255)
                {
                    warpAlpha = 0;
                    warping = false;
                    reverse = false;
                    SetStatus("IN ORBIT", Color.White);

                }
            }
        }

        private Vector2f Pivot(Vector2f center, float angleDeg, float size, int count)
        {
            float degrees = angleDeg * count;
            float angleRad = (float)Math.PI / 180 * degrees;
            return new Vector2f(center.X + size * (float)Math.Cos(angleRad), center.Y + size * (float)Math.Sin(angleRad));

        }

        public void SetStatus(string status, Color color)
        {
            this.text.DisplayedString = status;
            this.text.Color = color;

        }
    }
}
