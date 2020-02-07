using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using Yorick.Command_Handler.Abstract_classes;
using Yorick.Command_Handler.Interfaces;
using Yorick.Command_Handler.Static_classes;

namespace Yorick.Command_Handler
{
    public class VoiceCommand : BaseCommands,IVoiceCommand
    {
        public string Path { get; }
        public VoiceCommand(string commandName,string summary, CommandType type,
                             string path) :
            base(commandName,summary,type)
        {
            Path = path;
        }
        public override Task Execute(SocketCommandContext context)
        {
            IVoiceCommand voice = this as IVoiceCommand;
            IVoiceChannel AudioChannel = context.Guild.GetVoiceChannel(GuildIds.voiceChannelId) as IVoiceChannel;
            Task.Run(() => voice.StartVoiceCommand(AudioChannel, Path));
            return Task.CompletedTask;
        }
    }
}
