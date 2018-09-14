﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game;

namespace FinalSpace.Core.Parsing.Commands.Communication
{
    class Say : CommandBase
    {
        public override void Execute(GameState stateBase, string[] arguments)
        {
            if (stateBase.GetPlayer().IsCommunicating())
            {
                string s = "";
                for (int i = 1; i < arguments.Length; i++)
                    s += arguments[i] + " ";

                stateBase.GetTextBox().PushString(s);

            } else
            {
                stateBase.GetTextBox().PushString("Can not use SAY, not communicating.");

            }
        }

        public override int GetArguments()
        {
            return 2;
        }

        public override string GetKey()
        {
            return "SAY";
        }

        public override string HelpMessage()
        {
            return "Using: SAY <MESSAGE>\nUse SAY while communicating to respond to planet.";
        }
    }
}