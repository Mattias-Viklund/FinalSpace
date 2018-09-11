using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game;

namespace FinalSpace.Core.Parsing.Commands
{
    class Warp : CommandBase
    {
        public override void Execute(GameState stateBase, string[] arguments)
        {
            stateBase.GetTextBox().PushString("help 'command'\nTo display help for a command do:");
            
        }

        public override int GetArguments()
        {
            return 2;

        }

        public override string GetKey()
        {
            return "HELP";

        }
    }
}
