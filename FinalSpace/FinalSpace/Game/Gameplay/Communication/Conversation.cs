using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FinalSpace.Game.Gameplay.Communication;

namespace FinalSpace.Game.Gameplay.Communication
{
    class Conversation
    {
        public enum Tokens
        {
            Greetings = 0,
            Question = 1,
            Insults = 2,
            Compliments = 3,
            Items = 4,
            Actions = 5,
            Joiner = 6,
            Personal = 7,
            Numbers = 8,
            Confirmation = 9,
            Declining = 10,
            Location = 11

        }

        public static Dictionary<string, Tokens> dictionary = new Dictionary<string, Tokens>();

        public static void ReadFromFile(string path)
        {
            string[] combined;
            List<string> words = new List<string>();
            List<int> tokens = new List<int>();

            using (StreamReader sr = new StreamReader(File.Open(path, FileMode.Open)))
            {
                string wholeFile = sr.ReadToEnd();
                combined = wholeFile.Split(' ', '\n');

            }

            for (int i = 0; i < combined.Length; i++)
            {
                string s = combined[i].Trim();

                if (s.Length == 0)
                {
                    combined[i] = null;
                    continue;

                }

                if (s.Contains("//"))
                {
                    combined[i] = null;
                    int x = i;
                    for (int o = 0; o < combined.Length - x; o++)
                    {
                        i++;
                        if (combined[i].Contains("//"))
                        {
                            combined[i] = null;
                            break;

                        }
                        else
                        {
                            combined[i] = null;

                        }
                    }
                }
                else
                    combined[i] = s.Trim();

            }

            for (int i = 0; i < combined.Length - 1; i += 2)
            {
                if (combined[i] == null || combined[i + 1] == null)
                    continue;

                words.Add(combined[i]);
                try
                {
                    tokens.Add(Convert.ToInt32(combined[i + 1]));

                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: Dictionary failed loading, you probably corrupted it.\nContact 'Mew_#1452' on discord for help.");
                    Environment.Exit(2);

                }
            }

            for (int i = 0; i < tokens.Count; i++)
            {
                try
                {
                    dictionary.Add(words[i], (Tokens)tokens[i]);
                } catch
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: Dictionary failed loading, you added an already existing key.\nContact 'Mew_#1452' on discord for help.");
                    Environment.Exit(3);

                }
            }
        }
    }
}
