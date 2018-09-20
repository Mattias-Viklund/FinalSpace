using FinalSpace.Core.Parsing.Commands;
using FinalSpace.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Core.Parsing
{
    abstract class CommandBase
    {
        private static List<CommandBase> clientCommands = new List<CommandBase>();
        private static List<CommandBase> serverCommands = new List<CommandBase>();
        public static CommandBase ERROR = new Error();

        public static void InitializeList()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly asm in assemblies)
            {
                foreach (Type t in asm.GetTypes())
                {
                    if (t.IsSubclassOf(typeof(CommandBase)))
                        Activator.CreateInstance(t);

                }

            }
        }

        public static List<CommandBase> GetClientCommands()
        {
            return clientCommands;

        }

        public static List<CommandBase> GetServerCommands()
        {
            return serverCommands;

        }

        public CommandBase(bool macro = true, bool server = false)
        {
            if (macro)
                if (!server)
                    clientCommands.Add(this);
                else
                    serverCommands.Add(this);
                    

        }

        public abstract void Execute(GameState stateBase, string[] arguments);
        public abstract string GetKey();
        public abstract int GetArguments();
        public abstract string HelpMessage();

    }
}
