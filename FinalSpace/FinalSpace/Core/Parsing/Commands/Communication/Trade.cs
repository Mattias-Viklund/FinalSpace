using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game;

namespace FinalSpace.Core.Parsing.Commands.Communication
{
    class Trade : CommandBase
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
            return "TRADE";
        }

        public override string HelpMessage()
        {
            return "Usage: TRADE\nBuy or Sell items to planet you are orbiting.";

        }
    }
}
