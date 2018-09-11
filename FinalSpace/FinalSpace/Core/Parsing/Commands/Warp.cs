using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game;

namespace FinalSpace.Core.Parsing.Commands
{
    class Warp : CommandBase
    {
        public override void Execute(GameState stateBase, string[] arguments)
        {
            if (arguments.Length < 2)
                stateBase.GetTextBox().PushString("WARP NEAREST, WARP 'PLANET', WARP HOME. \nIncorrect Syntax, Correct usage:");
            else
            {
                stateBase.GetTextBox().PushString("WARP");
                stateBase.GetShip().Warp();

            }
        }

        public override int GetArguments()
        {
            return 1;

        }

        public override string GetKey()
        {
            return "WARP";

        }
    }
}
