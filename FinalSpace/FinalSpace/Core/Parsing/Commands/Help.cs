using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game;

namespace FinalSpace.Core.Parsing.Commands
{
    class Help : CommandBase
    {
        public override void Execute(GameState stateBase, string[] arguments)
        {
            if (arguments.Length < 2)
                stateBase.GetTextBox().PushString("help 'command'\nTo display help for a command do:");
            else
            {
                CommandBase command = Parser.TryFindCommand(arguments[1]);
                if (command == null)
                    stateBase.GetTextBox().PushString("Command '"+arguments[1]+"' does not exist.");
                else
                    stateBase.GetTextBox().PushString(command.HelpMessage());

            }
        }

        public override int GetArguments()
        {
            return 1;

        }

        public override string GetKey()
        {
            return "HELP";

        }

        public override string HelpMessage()
        {
            return "Usage: HELP <COMMAND>\nShows help from a command.";

        }
    }
}
