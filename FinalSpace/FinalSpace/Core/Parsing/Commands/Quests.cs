using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game;

namespace FinalSpace.Core.Parsing.Commands
{
    class Quests : CommandBase
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
            return "QUESTS";
        }

        public override string HelpMessage()
        {
            return "Shows your current quests";
        }
    }
}
