using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yorick.Command_Handler.Abstract_classes
{
    public abstract class BaseCommands
    {
        public enum CommandType
        {
            LeagueOfLegends,
            CallOfDuty,
            Hearthstone,
            Youtubers,
            Quebec,
            Tv,
            Streamers,
            Kys,
            Bot_Commands,
            Meme,
            Bob_Ross,
            Misc
        }
        public string CommandName { get; }
        public string Summary { get; }
        public CommandType Type { get; }

        //Ajouter un Requirement pour executer une commande.
        //public GuildPermission Required { get; }
        protected BaseCommands(string commandName, string summary, CommandType type)
        {
            CommandName = commandName;
            Summary = summary;
            Type = type;
        // Required = GuildPermission.ViewChannel;
        }

        public abstract Task Execute(SocketCommandContext context);
    }
}
