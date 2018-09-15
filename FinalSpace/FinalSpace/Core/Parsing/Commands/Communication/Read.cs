using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game;
using FinalSpace.Game.Gameplay.Communication;

namespace FinalSpace.Core.Parsing.Commands.Communication
{
    class Read : CommandBase
    {
        public override void Execute(GameState stateBase, string[] arguments)
        {
            string msg = "";
            foreach (string s in Conversation.dictionary.Keys)
            {
                msg += s + ", ";

            }

            stateBase.PushString(msg);

        }

        public override int GetArguments()
        {
            return 1;
        }

        public override string GetKey()
        {
            return "READDICTIONARY";
        }

        public override string HelpMessage()
        {
            return "Usage: READDICTIONARY\nRead the entire Dictionary list.";

        }
    }
}
