using FinalSpace.Core.Parsing.Commands;
using FinalSpace.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Core.Parsing
{
    class Parser
    {
        private GameState gameState;

        public Parser(GameState gameState)
        {
            CommandBase.InitializeList();

            this.gameState = gameState;

        }

        public static CommandBase TryFindCommand(string key, bool server = false)
        {
            if (!server)
            {
                foreach (CommandBase b in CommandBase.GetClientCommands())
                {
                    if (b.GetKey() == key)
                        return b;

                }
            }
            else
            {
                foreach (CommandBase b in CommandBase.GetServerCommands())
                {
                    if (b.GetKey() == key)
                        return b;

                }
            }

            return null;

        }

        public bool Parse(string input, bool server=false)
        {
            string[] words = input.Split(' ');
            if (words.Length == 0)
                return false;
            int arguments = words.Length;

            CommandBase matchingCommand = CommandBase.ERROR;
            Error.error = words[0];

            if (!server)
            {
                foreach (CommandBase command in CommandBase.GetClientCommands())
                {
                    if (command.GetKey() == words[0])
                        matchingCommand = command;

                }
            }
            else
            {
                foreach (CommandBase command in CommandBase.GetServerCommands())
                {
                    if (command.GetKey() == words[0])
                        matchingCommand = command;

                }
            }

            //if (arguments != matchingCommand.GetArguments())
            //{
            //    matchingCommand = CommandBase.ERROR;
            //    Error.error = "Inproper command syntax.";

            //}

            matchingCommand.Execute(gameState, words);

            return true;

        }
    }
}
