using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game;

namespace FinalSpace.Core.Parsing.Commands
{
    class Echo : CommandBase
    {
        public override void Execute(GameState stateBase, string[] arguments)
        {
            string s = "";
            for (int i = 1; i < arguments.Length; i++)
                s += arguments[i]+" ";

            stateBase.GetTextBox().PushString(s);

        }

        public override int GetArguments()
        {
            return 1;

        }

        public override string GetKey()
        {
            return "ECHO";

        }

        public override string HelpMessage()
        {
            return "Usage: ECHO <MESSAGE>\nPrints <MESSAGE> to buffer";
        }
    }
}
