using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Yorick.Command_Handler.Abstract_classes;
using Yorick.Command_Handler.Static_classes;

namespace Yorick.Command_Handler
{
    public class LeaveCommand : BaseCommands
    {
        public string Text { get; }
        public LeaveCommand(string commandName, string summary, CommandType type,
                             string text) :
            base(commandName, summary, type)
        {
            Text = text;
        }
        public override async Task Execute(SocketCommandContext context)
        {
            await context.Channel.SendMessageAsync(Text);
            var AudioChannel = context.Guild.GetVoiceChannel(GuildIds.voiceChannelId);
            await AudioChannel.DisconnectAsync();
        }
    }
}
