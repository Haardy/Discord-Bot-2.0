using Discord.Commands;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Yorick.Command_Handler.Abstract_classes;
using Yorick.Command_Handler.Static_classes;
using static Yorick.Command_Handler.Abstract_classes.BaseCommands;

namespace Yorick.Command_Handler
{
    public class SingletonCommands
    {
        private static SingletonCommands instance = null;
        private static readonly object padlock = new object();
        public static char CommandPrefix = '!';
        public static string AudioPath = System.AppDomain.CurrentDomain.BaseDirectory + @"Audio_Mp3\";
        private List<BaseCommands> _commands { get; }
     

        private SingletonCommands()
        {
           _commands = new List<BaseCommands>();
            LoadCommands();
        }

        public static SingletonCommands Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new SingletonCommands();
                    return instance;
                }
            }
        }

        public List<BaseCommands> Commands
        {
            get
            {
                List<BaseCommands> bc = new List<BaseCommands>();
                foreach (var item in _commands)
                    bc.Add(item);
                return bc;
            }
        }

        public void AddCommand(BaseCommands baseCommand)
        {
            if (!_commands.Contains(baseCommand))
                _commands.Add(baseCommand);
        }

        public void RemoveCommand(BaseCommands baseCommand)
        {
            if (_commands.Contains(baseCommand))
                _commands.Remove(baseCommand);
        }
        public async Task TryRunCommandAsync(SocketCommandContext context)
        {
            string commandName = context.Message.Content.Split(CommandPrefix)[1];

            var command = _commands.FirstOrDefault(x => x.CommandName == commandName);

            if (command == null) return;

            await command.Execute(context);
        }


        private void LoadCommands()
        {

            AddCommand(new VoiceCommand("grave", "Whats one more grave", CommandType.LeagueOfLegends,AudioPath+"grave.mp3"));
            AddCommand(new VoiceCommand("ravage", "orianna q", CommandType.LeagueOfLegends, AudioPath + "ravage.mp3"));
            AddCommand(new VoiceCommand("time", "singed quote", CommandType.LeagueOfLegends, AudioPath + "time.mp3"));
            AddCommand(new VoiceCommand("kystessier", "kys tessier", CommandType.Kys, AudioPath + "kystessier.mp3"));
            AddCommand(new VoiceCommand("kysantoine", "kys antoine", CommandType.Kys, AudioPath + "kysantoine.mp3"));
            AddCommand(new VoiceCommand("b6", "bravo 6 going dark", CommandType.CallOfDuty, AudioPath + "b6.mp3"));
            AddCommand(new VoiceCommand("mfailed", "mission failed", CommandType.CallOfDuty, AudioPath + "mfailed.mp3"));
            AddCommand(new VoiceCommand("ac130", "ac130 above", CommandType.CallOfDuty, AudioPath + "ac130.mp3"));
            AddCommand(new VoiceCommand("bhell", "just got our asses kicked", CommandType.CallOfDuty, AudioPath + "bhell.mp3"));
            AddCommand(new VoiceCommand("victory", "rangers lead the way", CommandType.CallOfDuty, AudioPath + "rangers lead the way.mp3"));
            AddCommand(new VoiceCommand("paladin", "paladin et archimage", CommandType.Quebec, AudioPath + "paladin.mp3"));
            AddCommand(new VoiceCommand("bruce", "penis a bruce", CommandType.Quebec, AudioPath + "bruce.mp3"));
            AddCommand(new VoiceCommand("nword", "naggers", CommandType.Tv, AudioPath + "nword.mp3"));
            AddCommand(new VoiceCommand("lambsauce", "WHERE THE LAMB SAUCE", CommandType.Tv, AudioPath + "lambsauce.mp3"));
            AddCommand(new VoiceCommand("lenoir", "le noir est mort", CommandType.Streamers, AudioPath + "lenoir.mp3"));
            AddCommand(new VoiceCommand("csur", "mais cetait sur", CommandType.Streamers, AudioPath + "csur.mp3"));
            AddCommand(new VoiceCommand("win", "I always win", CommandType.Hearthstone, AudioPath + "win.mp3"));
            AddCommand(new VoiceCommand("wtf", "wtf", CommandType.Youtubers, AudioPath + "wtf.mp3"));
            AddCommand(new VoiceCommand("chocolatine", "pain au chocolat", CommandType.Youtubers, AudioPath + "chocolatine.mp3"));
            AddCommand(new VoiceCommand("gothim", "we got him", CommandType.Meme, AudioPath + "gothim.mp3"));
            AddCommand(new VoiceCommand("baldhead", "i got a bald head", CommandType.Youtubers, AudioPath + "mofuka i got a BALD HEAD.mp3"));
	        AddCommand(new VoiceCommand("onjoue", "on joue", CommandType.Quebec, AudioPath + "onjoue.mp3"));
            AddCommand(new VoiceCommand("pal", "I dont think so pal", CommandType.Meme, AudioPath + "pal.mp3"));
            AddCommand(new VoiceCommand("tryn", "if he is a man you're gay", CommandType.LeagueOfLegends, AudioPath + "tryn.mp3"));
            AddCommand(new VoiceCommand("pie", "pie", CommandType.Youtubers, AudioPath + "pie.mp3"));
            AddCommand(new VoiceCommand("borne", "jason borne", CommandType.Meme, AudioPath + "jasonborne.mp3"));
            AddCommand(new VoiceCommand("ah", "ah", CommandType.Meme, AudioPath + "ah.mp3"));
            AddCommand(new VoiceCommand("assistance", "assistance", CommandType.Hearthstone, AudioPath + "assistance.mp3"));
            AddCommand(new VoiceCommand("bitch", "bitch", CommandType.Meme, AudioPath + "bitch.mp3"));
            AddCommand(new VoiceCommand("sonofa", "grave", CommandType.Meme, AudioPath + "sonofa.mp3"));
            AddCommand(new VoiceCommand("baron", "grave", CommandType.LeagueOfLegends, AudioPath + "grave1.mp3"));
            AddCommand(new VoiceCommand("ezdude", "ezdude", CommandType.LeagueOfLegends, AudioPath + "ez dude.mp3"));
            AddCommand(new VoiceCommand("consequence", "consequence", CommandType.Meme, AudioPath + "Frick.mp3"));
            AddCommand(new VoiceCommand("sanic", "sanic", CommandType.Meme, AudioPath + "sanic.mp3"));
            AddCommand(new VoiceCommand("triple", "triple", CommandType.CallOfDuty, AudioPath + "triple.mp3"));
            AddCommand(new VoiceCommand("oof", "oof", CommandType.Meme, AudioPath + "oof.mp3"));
            AddCommand(new VoiceCommand("leeroy", "leeroy", CommandType.Meme, AudioPath + "Leeroy-Jenkin.mp3"));
            AddCommand(new VoiceCommand("hisname", "hisname", CommandType.Meme, AudioPath + "hisname.mp3"));
            AddCommand(new VoiceCommand("antoine", "antoine", CommandType.Kys, AudioPath + "antoine.mp3"));
            AddCommand(new VoiceCommand("antoinehype", "antoinehype", CommandType.Kys, AudioPath + "antoinehype.mp3"));
            AddCommand(new VoiceCommand("antoinerage", "antoinerage", CommandType.Kys, AudioPath + "antoinerage.mp3"));
            AddCommand(new VoiceCommand("antoineboi", "antoineboi", CommandType.Kys, AudioPath + "antoineboi.mp3"));
            AddCommand(new VoiceCommand("spotted", "spotted", CommandType.CallOfDuty, AudioPath + "spotted.mp3"));




            AddCommand(new VoiceCommand("ross", "paint", CommandType.Bob_Ross, AudioPath + "ross.mp3"));
            AddCommand(new VoiceCommand("devil", "devil out of it", CommandType.Bob_Ross, AudioPath + "devil.mp3"));
            AddCommand(new VoiceCommand("white", "white", CommandType.Bob_Ross, AudioPath + "white.mp3"));

            AddCommand(new VoiceCommand("furie", "furie", CommandType.Quebec, AudioPath + "furie.mp3"));
            AddCommand(new VoiceCommand("ludovick", "ludovick", CommandType.Quebec, AudioPath + "ludovick.mp3"));
            AddCommand(new VoiceCommand("nain", "nain", CommandType.Quebec, AudioPath + "nain.mp3"));
            AddCommand(new VoiceCommand("muscu", "muscu", CommandType.Meme, AudioPath + "muscu.mp3"));

            AddCommand(new VoiceCommand("shotgun", "shotgun", CommandType.Meme, AudioPath + "shotgun.mp3"));
            AddCommand(new VoiceCommand("desoler", "desoler", CommandType.Meme, AudioPath + "desoler.mp3"));


            AddCommand(new VoiceCommand("inter", "intervention", CommandType.CallOfDuty, AudioPath + "Intervention.mp3"));
            AddCommand(new VoiceCommand("nuke", "nuke", CommandType.CallOfDuty, AudioPath + "nuke.mp3"));




            AddCommand(new VoiceCommand("happy", "happy", CommandType.Bob_Ross, AudioPath + "happy.mp3"));




            AddCommand(new VoiceCommand("sou", "toss sou to your witcher", CommandType.Meme, AudioPath + "sou.mp3"));


            AddCommand(new VoiceCommand("noice", "noice", CommandType.Meme, AudioPath + "noice.mp3"));


            AddCommand(new VoiceCommand("nigger", "nigger", CommandType.LeagueOfLegends, AudioPath + "nigger.mp3"));

            AddCommand(new LeaveCommand("gtfo", "make bot leave voice chat", CommandType.Bot_Commands, "leaving chat..."));
            AddCommand(new TextCommand("git", "return git page", CommandType.Bot_Commands,
           "https://github.com/Haardy/Discord-Bot-2.0"));
            AddCommand(new HelpCommand("help", "print every commands", CommandType.Bot_Commands));

        }

    }
}
