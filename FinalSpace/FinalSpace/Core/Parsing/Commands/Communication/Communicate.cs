using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalSpace.Game;

namespace FinalSpace.Core.Parsing.Commands.Communication
{
    class Communicate : CommandBase
    {
        public override void Execute(GameState stateBase, string[] arguments)
        {
            if (stateBase.GetPlayer().IsCommunicating())
            {
                stateBase.PushString("Closing communications line with " + stateBase.GetPlayer().GetCurrentPlanet().GetName());
                stateBase.GetPlayer().SetCommunicating(false);

            } else
            {
                stateBase.PushString("Opening communications line with " + stateBase.GetPlayer().GetCurrentPlanet().GetName());
                stateBase.GetPlayer().SetCommunicating(true);
                if (!stateBase.GetPlayer().DiscoveredPlanet(stateBase.GetPlayer().GetCurrentPlanet()))
                    stateBase.PushString(stateBase.GetPlayer().GetCurrentPlanet().GetGreetings(stateBase));

            }
        }

        public override int GetArguments()
        {
            return 1;
        }

        public override string GetKey()
        {
            return "COMMUNICATE";
        }

        public override string HelpMessage()
        {
            return "Usage: COMMUNICATE\nInitiates a relationship with planet you are orbiting.";

        }
    }
}
