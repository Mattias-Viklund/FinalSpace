using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Graphics;
using SFML.Window;
using FinalSpace.Game;

namespace FinalSpace.GUI
{
    class TextBox : GUIElement
    {
        private RectangleShape rect;
        private Text text;

        private StringBuilder sb = new StringBuilder();
        private bool inputBox = false;
        private int maxLength;

        private Text[] textBuffers;
        private byte selected = 0x00;
        private int padding = 3;

        private StateBase belongsTo;

        public TextBox(byte bufferSize, StateBase stateFrom)
        {
            // Default values, looks good
            belongsTo = stateFrom;
            Setup(new Vector2f(247, 30), new Vector2f(50, 50), 20, 20, new Color(27, 27, 27), new Color(255, 255, 255), 3, bufferSize);

        }

        public TextBox(Vector2f size, Vector2f position, int maxLength, int charSize, Color rectColor, Color textColor, StateBase stateFrom, int padding = 3, int bufferSize = 5)
        {
            belongsTo = stateFrom;
            Setup(size, position, maxLength, charSize, rectColor, textColor, padding, bufferSize);

        }

        private void Setup(Vector2f size, Vector2f position, int maxLength, int charSize, Color rectColor, Color textColor, int padding, int bufferSize)
        {
            this.padding = padding;
            this.rect = new RectangleShape(size);
            this.rect.Position = position;
            this.rect.FillColor = rectColor;

            this.maxLength = maxLength;

            this.text = new Text("", Program.gameFont, (uint)charSize);
            this.text.Color = new Color(255, 255, 255, 255);
            this.text.Position = new Vector2f(position.X + padding, position.Y + padding);

            FillBuffer(bufferSize);

        }

        private void FillBuffer(int size)
        {
            textBuffers = new Text[size];

            for (int i = 0; i < textBuffers.Length; i++)
            {
                textBuffers[i] = new Text("", Program.gameFont, 20);
                textBuffers[i].Position = new Vector2f(text.Position.X, text.Position.Y + 30 * (i + 1));
                textBuffers[i].Color = Color.White;

            }
        }

        public bool PushString(string s)
        {
            if (s.Length > 0)
            { 
                string[] split = s.Split(Environment.NewLine.ToCharArray());
                if (split.Length > 1)
                {
                    foreach (string str in split)
                        PushString(str);

                    return false;

                }
            }

            string[] textMirror = new string[textBuffers.Length];
            textMirror[0] = s;

            for (int i = 1; i < textBuffers.Length; i++)
            {
                textMirror[i] = textBuffers[i - 1].DisplayedString;
                textBuffers[i - 1].DisplayedString = textMirror[i - 1];

                if (i == textBuffers.Length - 1)
                    textBuffers[i].DisplayedString = textMirror[i];

            }
            return true;

        }

        public string GetLine(int line)
        {
            if (textBuffers.Length < line)
                return "";

            return textBuffers[line].DisplayedString;

        }

        public void AddChar(char c)
        {
            if (sb.Length < maxLength)
                sb.Append(c);

        }
        public void RemoveChar()
        {
            if (inputBox)
            {
                if (sb.Length > 1)
                {
                    sb.Remove(sb.Length - 1, 1);

                }
            }
            else
            {
                if (sb.Length != 0)
                    sb.Remove(sb.Length - 1, 1);

            }
        }
        public void ClearChars()
        {
            sb.Clear();
            if (inputBox)
                AddChar('>');

        }
        public void ClearBuffer()
        {
            for (int i = 0; i < textBuffers.Length; i++)
                textBuffers[i].DisplayedString = "";

        }

        public void ForceSetText(string text)
        {
            sb.Clear();
            if (inputBox)
                sb.Append(">" + text);
            else
                sb.Append(text);

        }
        public void SetPosition(Vector2f position)
        {
            rect.Position = position;
            text.Position = position;

        }
        public void SetInputBox(bool yes)
        {
            inputBox = yes;

            if (yes)
            {
                ClearChars();

            }
        }

        public void SendLine()
        {
            ///////////
            // PARSE //
            ///////////
            string send = sb.ToString().Remove(0, 1);
            belongsTo.SendLine(send);

            ClearChars();

        }

        // Very unmaintainable method, can we do something about it?
        public override void SendKey(Keyboard.Key key)
        {
            if (inputBox)
                switch (key)
                {
                    case Keyboard.Key.Delete: ClearChars(); break;
                    case Keyboard.Key.BackSpace: RemoveChar(); break;
                    case Keyboard.Key.Return: SendLine(); break;

                    case Keyboard.Key.A: AddChar('A'); break;
                    case Keyboard.Key.B: AddChar('B'); break;
                    case Keyboard.Key.C: AddChar('C'); break;
                    case Keyboard.Key.D: AddChar('D'); break;
                    case Keyboard.Key.E: AddChar('E'); break;
                    case Keyboard.Key.F: AddChar('F'); break;
                    case Keyboard.Key.G: AddChar('G'); break;
                    case Keyboard.Key.H: AddChar('H'); break;
                    case Keyboard.Key.I: AddChar('I'); break;
                    case Keyboard.Key.J: AddChar('J'); break;
                    case Keyboard.Key.K: AddChar('K'); break;
                    case Keyboard.Key.L: AddChar('L'); break;
                    case Keyboard.Key.M: AddChar('M'); break;
                    case Keyboard.Key.N: AddChar('N'); break;
                    case Keyboard.Key.O: AddChar('O'); break;
                    case Keyboard.Key.P: AddChar('P'); break;
                    case Keyboard.Key.Q: AddChar('Q'); break;
                    case Keyboard.Key.R: AddChar('R'); break;
                    case Keyboard.Key.S: AddChar('S'); break;
                    case Keyboard.Key.T: AddChar('T'); break;
                    case Keyboard.Key.U: AddChar('U'); break;
                    case Keyboard.Key.V: AddChar('V'); break;
                    case Keyboard.Key.W: AddChar('W'); break;
                    case Keyboard.Key.X: AddChar('X'); break;
                    case Keyboard.Key.Y: AddChar('Y'); break;
                    case Keyboard.Key.Z: AddChar('Z'); break;
                    case Keyboard.Key.Num1: AddChar('1'); break;
                    case Keyboard.Key.Num2: AddChar('2'); break;
                    case Keyboard.Key.Num3: AddChar('3'); break;
                    case Keyboard.Key.Num4: AddChar('4'); break;
                    case Keyboard.Key.Num5: AddChar('5'); break;
                    case Keyboard.Key.Num6: AddChar('6'); break;
                    case Keyboard.Key.Num7: AddChar('7'); break;
                    case Keyboard.Key.Num8: AddChar('8'); break;
                    case Keyboard.Key.Num9: AddChar('9'); break;
                    case Keyboard.Key.Num0: AddChar('0'); break;
                    case Keyboard.Key.Space: AddChar(' '); break;

                    case Keyboard.Key.Up: GetFromBuffer(false); break;
                    case Keyboard.Key.Down: GetFromBuffer(true); break;

                    default: break;

                }
        }
        public override void MouseEvent()
        {

        }

        public void GetFromBuffer(bool up)
        {
            if (up)
            {
                if (selected < textBuffers.Length - 1)
                    selected++;

            }
            else
            {
                if (selected != 0)
                    selected--;

            }
            sb.Clear();
            ForceSetText(GetLine(selected));

        }
        public void SetPosition(Vector2f position, int padding = 5)
        {
            this.rect.Position = position;
            this.text.Position = new Vector2f(rect.Position.X + padding, rect.Position.Y + padding);

        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                text.DisplayedString = sb.ToString();

                (target as RenderWindow).Draw(rect);
                (target as RenderWindow).Draw(text);
                for (int i = 0; i < textBuffers.Length; i++)
                    (target as RenderWindow).Draw(textBuffers[i]);

            }
        }
    }
}
