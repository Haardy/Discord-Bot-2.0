using System.Threading.Tasks;
using Discord.Commands;
using Yorick.Command_Handler.Abstract_classes;

namespace Yorick.Command_Handler
{
    class TextCommand : BaseCommands
    {
        public string Text { get; }
        public TextCommand(string commandName, string summary, CommandType type,
                             string text) :
            base(commandName, summary, type)
        {
            Text = text;
        }
        public override async Task Execute(SocketCommandContext context)
        {
            await context.Channel.SendMessageAsync(Text);
        }
    }
}
