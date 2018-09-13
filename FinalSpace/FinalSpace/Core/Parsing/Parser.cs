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
        public static List<CommandBase> commands;

        private GameState gameState;

        public Parser(GameState gameState)
        {
            CommandBase.InitializeList();

            commands = CommandBase.GetCommands();
            this.gameState = gameState;

        }

        public static CommandBase TryFindCommand(string key)
        {
            foreach (CommandBase b in commands)
            {
                if (b.GetKey() == key)
                    return b;

            }

            return null;

        }

        public bool Parse(string input)
        {
            string[] words = input.Split(' ');
            if (words.Length == 0)
                return false;
            int arguments = words.Length;

            CommandBase matchingCommand = CommandBase.ERROR;
            Error.error = words[0];

            foreach (CommandBase command in commands)
            {
                if (command.GetKey() == words[0])
                    matchingCommand = command;

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
