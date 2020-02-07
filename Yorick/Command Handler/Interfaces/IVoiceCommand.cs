using Discord;
using Discord.Audio;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Yorick.Command_Handler.Interfaces
{
    public interface IVoiceCommand
    {
        public async Task StartVoiceCommand(IVoiceChannel AudioChannel,string path)
        {
            //try to disconnect in case already connected
            await AudioChannel.DisconnectAsync();

            IAudioClient audio = await AudioChannel.ConnectAsync();

            await SendAudioAsync(audio, path);

            await AudioChannel.DisconnectAsync();
        }
        private async Task SendAudioAsync(IAudioClient client, string path)
        {
            using (var ffmpeg = CreateStream(path))
            using (var output = ffmpeg.StandardOutput.BaseStream)
            using (var discord = client.CreatePCMStream(AudioApplication.Mixed))
            {
                try { await output.CopyToAsync(discord); }
                finally { await discord.FlushAsync(); }
            }
        }
        private Process CreateStream(string path)
        {
            return Process.Start(new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = $"-hide_banner -loglevel panic -i \"{path}\" -ac 2 -f s16le -ar 48000 pipe:1",
                UseShellExecute = false,
                RedirectStandardOutput = true,
            });
        }

    }
}
