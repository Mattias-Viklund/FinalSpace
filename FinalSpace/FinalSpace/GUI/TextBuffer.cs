using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.GUI
{
    class TextBuffer
    {
        string[] lines;
        byte currentLine = 0x00;

        public TextBuffer(byte size)
        {
            lines = new string[size];

        }

        public void Init()
        {
            for (byte b = 0; b < lines.Length; b++)
                lines[b] = ">";

        }

        public void Push(string s)
        {
            if (currentLine < lines.Length)
            {
                lines[currentLine] = s;
                currentLine++;

            }
            else
                MoveDown(s);

        }

        private void MoveDown(string next)
        {
            for (byte b = 0; b < lines.Length; b++)
            {
                if (b < lines.Length - 1)
                    lines[b] = lines[b + 1];
                else
                    lines[b] = next;

            }
        }

        public string GetLine(byte line)
        {
            if (line < lines.Length)
                return lines[line];

            return "";

        }

        public byte GetLength()
        {
            return (byte)lines.Length;

        }

        public byte GetFilled()
        {
            byte filled = 0x00;

            for (byte i = 0; i < lines.Length; i++)
            {
                if (lines[i] == ">")
                    break;

                filled++;

            }

            return filled;

        }
    }
}
