#region Configs

#define _LOGGER_
#define _EVENT_
//#define _SCHEDULE_
//#define _THOOK_
#define _DYNAMICCOMMAND_
#define _COMMAND_
//#define _REMOTECALL_
#define _FORM_

#endregion

using InfoCmd.Commands;
using LLNET.Core;
using LLNET.Logger;
using System.Runtime.InteropServices;

[assembly: LibPath("plugins\\InfoCmd\\libs")]

namespace InfoCmd;

[PluginMain("InfoCmd")]
public class Main : IPluginInitializer
{
    public Dictionary<string, string> MetaData => new()
        {
            ["Dir"] = GetDir()
        };

    public Version Version => new(2, 3, 1);
    public string Introduction => "Info command plugin for LL.NET";

    public Logger Logger = new("InfoCmd");

    public void OnInitialize()
    {
#if _LOGGER_

#endif
#if _EVENT_

#endif
#if _DYNAMICCOMMAND_

#endif
#if _COMMAND_
        CommandRegister commandRegister = new();
        commandRegister.Execute();
#endif
#if _FORM_
        
#endif
    }

    internal string GetDir()
    {
        DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\plugins\InfoCmd");
        if (!dir.Exists)
            dir.Create();

        if (!File.Exists(dir + @"\info.txt"))
        {
            Logger.warn.WriteLine("info.txt not found. Creating info.txt...");
            try
            {
                using (StreamWriter writer = new(dir + @"\info.txt", false))
                    writer.WriteLine("\n§l§7===§i§eServerName§r§l§7===§r\nYour text here §c§l<3§r");
            }
            finally
            {
                Logger.info.WriteLine("Success!");
            }
        }

        return dir.FullName;
    }
}