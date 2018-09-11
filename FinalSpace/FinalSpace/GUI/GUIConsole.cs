using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace FinalSpace.GUI
{
    class GUIConsole : GUIElement
    {
        public TextBox textBox;
        public TextBox[] textBoxes;

        public GUIConsole(byte lines)
        {
            textBox = new TextBox(lines);
            textBox.SetInputBox(true);
            textBoxes = new TextBox[lines];
            textBox.EnableScrolling(false);
            Fill();

        }

        // Darn, I wish I had a better way to do this
        private void Fill()
        {
            int more = 30;
            for (byte b = (byte)(textBoxes.Length-1); b >= 0; b--)
            {
                textBoxes[b] = new TextBox(0);
                Vector2f pos = textBoxes[b].GetPosition();
                textBoxes[b].SetPosition(new Vector2f(pos.X, pos.Y + (30 * (b+1))));

            }
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                (target as RenderWindow).Draw(textBox);

                // Update the lines
                for (byte b = 0; b < textBoxes.Length; b++)
                {
                    textBoxes[b].ForceSetText(textBox.GetLine(b));
                    (target as RenderWindow).Draw(textBoxes[b]);

                }
            }
        }

        public override void MouseEvent()
        {
            throw new NotImplementedException();
        }

        public override void SendKey(Keyboard.Key key)
        {
            textBox.SendKey(key);

        }
    }
}
