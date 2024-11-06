﻿using System.Runtime.Versioning;

namespace PathManager.Commands
{
    internal sealed class AddPathCommand
    {
        [SupportedOSPlatform("windows")]
        public static void Handle(string directoryPath, bool systemEnvironment, bool addToBeginning)
        {
            Console.WriteLine($"(i) Starting.");
            string systemEnvironmentName = systemEnvironment ? "system" : "user";
            EnvironmentVariableTarget environmentType = systemEnvironment ? EnvironmentVariableTarget.Machine : EnvironmentVariableTarget.User;
            DirectoryInfo di = new DirectoryInfo(directoryPath);
            Console.WriteLine($"(i) Getting \"Path\" {systemEnvironmentName} environment variable.");
            List<string> paths = Environment.GetEnvironmentVariable("Path", environmentType)!.Split(';').ToList();
            Console.WriteLine($"(i) Looking for directory path in \"Path\" {systemEnvironmentName} environment variable.");
            if (paths.FindIndex(a => a.Contains(di.FullName)) == -1) // -1 == not found
            {
                if (addToBeginning)
                {
                    Console.WriteLine($"(i) The directory path is added to the beginning {systemEnvironmentName} environment variable.");
                    paths.Insert(0, di.FullName);
                }
                else
                {
                    Console.WriteLine($"(i) The directory path is added to the {systemEnvironmentName} environment variable.");
                    paths.Add(di.FullName);
                }
                Console.WriteLine($"(i) The \"Path\" environment is stored.");
                string newPaths = string.Join(";", paths.ToArray());
                if (environmentType == EnvironmentVariableTarget.User)
                {
                    Environment.SetEnvironmentVariable("Path", newPaths, EnvironmentVariableTarget.User);
                    Console.WriteLine($"(i) Done.");
                }
                else if (Helpers.IsAdministrator() && environmentType == EnvironmentVariableTarget.Machine)
                {
                    Environment.SetEnvironmentVariable("Path", newPaths, EnvironmentVariableTarget.Machine);
                    Console.WriteLine($"(i) Done.");
                }
                else
                {
                    Console.WriteLine($"(e) You need administrator permissions to remove the directory path from the {systemEnvironmentName} environment variable!");
                }
            }
            else
            {
                Console.WriteLine($"(w) Directory path is already exists in \"Path\" {systemEnvironmentName} environment variable.");
            }
        }
    }
}