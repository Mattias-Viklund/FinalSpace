using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game;

namespace FinalSpace.Core.Parsing.Commands
{
    class Balance : CommandBase
    {
        public override void Execute(GameState stateBase, string[] arguments)
        {
            stateBase.GetTextBox().PushString("Balance: "+stateBase.GetPlayer().GetMoney().ToString());
        }

        public override int GetArguments()
        {
            return 1;
        }

        public override string GetKey()
        {
            return "BALANCE";
        }

        public override string HelpMessage()
        {
            return "Displays current amount of money";
        }
    }
}
