using LLNET.DynamicCommand;
using LLNET.Logger;
using MC;

namespace InfoCmd.Commands
{
    [Command("info", Description = "server info", Permission = CommandPermissionLevel.Any, AutoReset = true)]
    internal class InfoCommand : ICommand
    {
        static Logger Logger { get; set; } = new("InfoCmd");
        static DirectoryInfo Dir = new(Directory.GetCurrentDirectory() + @"\plugins\InfoCmd");
        static FileInfo ifile = new(Dir + @"\info.txt");
        static string? itext = null;

        public void Execute(CommandOrigin origin, CommandOutput output)
        {
            using (StreamReader reader = new(ifile.FullName))
                itext = reader.ReadToEnd();

            if (origin.Name != "Server")
            {
                origin.Player.SendText( itext );
            }
                
            else Logger.info.WriteLine( itext );

            Logger.Dispose();
        }
    }
}
