using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game;

namespace FinalSpace.Core.Parsing.Commands
{
    class Planet : CommandBase
    {
        public override void Execute(GameState stateBase, string[] arguments)
        {
            stateBase.GetTextBox().PushString("DAB");

        }

        public override int GetArguments()
        {
            return 1;

        }

        public override string GetKey()
        {
            return "PLANET";

        }

        public override string HelpMessage()
        {
            return "Usage: Planet\nGets NAME of current planet.";
            
        }
    }
}
