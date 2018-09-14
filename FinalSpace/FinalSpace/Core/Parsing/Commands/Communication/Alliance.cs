using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game;

namespace FinalSpace.Core.Parsing.Commands.Communication
{
    class Alliance : CommandBase
    {
        public override void Execute(GameState stateBase, string[] arguments)
        {
        }

        public override int GetArguments()
        {
            return 1;
        }

        public override string GetKey()
        {
            return "ALLIANCE";
        }

        public override string HelpMessage()
        {
            return "Usage: ALLIANCE\nTry to establish alliance with planet you are orbiting.";

        }
    }
}
