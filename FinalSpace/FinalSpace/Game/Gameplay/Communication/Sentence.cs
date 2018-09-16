using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Game.Gameplay.Communication
{
    class Sentence
    {
        public Sentence()
        {

        }

        public static Conversation.Tokens[] GenerateContext(string message)
        {
            string[] split = message.Split(' ');
            Conversation.Tokens[] tokens = new Conversation.Tokens[split.Length];

            Conversation.Tokens value = Conversation.Tokens.Ignore;
            for (int i = 0; i < split.Length; i++)
            {
                Conversation.dictionary.TryGetValue(split[i], out value);

                tokens[i] = value;
                value = Conversation.Tokens.Ignore;

            }

            return tokens;

        }
    }
}
