﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game;

namespace FinalSpace.Core.Parsing.ServerCommands
{
    class Error : CommandBase
    {
        string a;
        public static string error;
        string c;

        public Error()
            : base(false, true)
        {
            a = "Silent Command '";
            c = "' does not exist.";

        }

        public static void CommandUsed(string s)
        {
            error = s;

        }

        public override void Execute(GameState stateBase, string[] arguments)
        {
            stateBase.GetTextBox().PushString(a+error+c);
            
        }

        public override int GetArguments()
        {
            return 0;

        }

        public override string GetKey()
        {
            return "";

        }

        public override string HelpMessage()
        {
            return "You are not supposed to be here.";

        }
    }
}
