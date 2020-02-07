using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Yorick.Command_Handler.Abstract_classes;

namespace Yorick.Command_Handler
{
    class HelpCommand : BaseCommands
    {
        public HelpCommand(string commandName, string summary, CommandType type) :
             base(commandName, summary, type)
        {
        }
        public override async Task Execute(SocketCommandContext context)
        {

            SingletonCommands singletonCommands = SingletonCommands.Instance;
            List<BaseCommands> Commands = singletonCommands.Commands;

            if (Commands == null) return;

            Commands = Commands.OrderBy(x => x.Type).ToList();

            //place bot commands last
          List<BaseCommands>botCommands =  Commands.Where(x => x.Type == CommandType.Bot_Commands).ToList();
            if (botCommands != null)
            {
                foreach (var item in botCommands)
                {
                    Commands.Remove(item);
                    Commands.Add(item);
                }
            }


            BaseCommands firstCommand = Commands.FirstOrDefault();


            EmbedBuilder builder = new EmbedBuilder();

            CommandType oldCommandType = firstCommand.Type;
            string currentCommandsName = "";
            EmbedFieldBuilder fieldBuilder = new EmbedFieldBuilder();
            fieldBuilder.Name = firstCommand.Type.ToString();

            foreach (BaseCommands command in Commands)
            {
                if (command.Type != oldCommandType)
                {
                    fieldBuilder.Value = currentCommandsName;
                    currentCommandsName = "";
                    builder.AddField(fieldBuilder);
                    fieldBuilder = new EmbedFieldBuilder();
                    fieldBuilder.Name = command.Type.ToString();
                }
                    currentCommandsName += SingletonCommands.CommandPrefix + command.CommandName + ",";
                    oldCommandType = command.Type;
            }
            fieldBuilder.Value = currentCommandsName;
            builder.AddField(fieldBuilder);


            builder.WithTitle(CommandName);
            builder.WithCurrentTimestamp();
            builder.WithColor(Color.Green);

           await context.Channel.SendMessageAsync(embed: builder.Build());
        }
    }
}
