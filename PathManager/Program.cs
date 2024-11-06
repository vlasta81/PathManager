using PathManager.Commands;
using System.CommandLine;
using System.Runtime.Versioning;

namespace PathManager
{
    internal class Program
    {
        [SupportedOSPlatform("windows")]
        static void Main(string[] args)
        {
            Option<string> directoryOption = new Option<string>("--directory", "The directory path that is added to the \"Path\" environment variable.");
            directoryOption.IsRequired = true;
            directoryOption.ArgumentHelpName = "path";
            directoryOption.AddAlias("-d");

            Option<bool> systemEnvironmentOption = new Option<bool>("--system", "Select if you want to add/remove the directory path to/from the system instead of user environment \"Path\" variable. (Required administrator permissions!)");
            systemEnvironmentOption.SetDefaultValue(false);
            systemEnvironmentOption.AddAlias("-s");

            Option<bool> addToBeginningOption = new Option<bool>("--first", "Select if you want to add the directory path to the beginning of the \"Path\" environment variable.");
            addToBeginningOption.SetDefaultValue(false);
            addToBeginningOption.AddAlias("-f");

            RootCommand rootCommand = new RootCommand("PathManager is a CLI tool managing the windows \"Path\" environment variable.");

            Command addCommand = new Command("add", "Add path to environment variable.");
            addCommand.AddOption(directoryOption);
            addCommand.AddOption(systemEnvironmentOption);
            addCommand.AddOption(addToBeginningOption);
            addCommand.SetHandler(AddPathCommand.Handle, directoryOption, systemEnvironmentOption, addToBeginningOption);
            rootCommand.Add(addCommand);

            Command removeCommand = new Command("remove", "Remove path from environment variable.");
            removeCommand.AddOption(directoryOption);
            removeCommand.AddOption(systemEnvironmentOption);
            removeCommand.SetHandler(RemovePathCommand.Handle, directoryOption, systemEnvironmentOption);
            rootCommand.Add(removeCommand);

            rootCommand.Invoke(args);
        }
    }
}
