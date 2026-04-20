using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RobloxSettingsHelper
{
    internal class Program
    {
        private static string userName = System.Environment.UserName;
        private static string appPath = AppDomain.CurrentDomain.BaseDirectory;
        private static string robloxPath;

        static void Main(string[] args)
        {
            robloxPath = getRobloxFilePath();
            if (robloxPath != null)
            {
                UnlockFPS();
                CopyClientSettings();
                CopyTextures();
                CopyFonts();
            }
            else
            {
                Console.WriteLine("Error: Roblox folder not found!");
            }
            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();
        }

        public static void UnlockFPS()
        {
            string globalBasicSettingsPath = "C:\\Users\\" + userName + "\\AppData\\Local\\Roblox\\GlobalBasicSettings_13.xml";
            Console.WriteLine("Unlocking FPS..");
            if (File.Exists(globalBasicSettingsPath))
            {
                Console.WriteLine("GlobalBasicSettings file path: " + globalBasicSettingsPath);
                var xdoc = XDocument.Load(globalBasicSettingsPath);
                var frameCap = xdoc.Descendants("int").FirstOrDefault(x => (string)x.Attribute("name") == "FramerateCap");
                if (frameCap != null)
                {
                    frameCap.Value = "2000";
                    xdoc.Save(globalBasicSettingsPath);
                    Console.WriteLine("Successfully unlocked FPS!");
                    return;
                }
            }
            Console.WriteLine("Error: Couldn't find GlobalBasicSettings_13.xml in " + globalBasicSettingsPath);
        }

        public static void CopyFonts()
        {
            string localFontPath = appPath + "font.ttf";
            Console.WriteLine("Copying fonts..");
            if (File.Exists(localFontPath))
            {
                string robloxFontFolderPath = robloxPath + "\\content\\fonts";
                Console.WriteLine("Font folder path: " + robloxFontFolderPath);
                foreach (var file in Directory.GetFiles(robloxFontFolderPath))
                {
                    string oldFont = file.ToString();
                    if (oldFont != robloxFontFolderPath + "\\families" && oldFont != robloxFontFolderPath + "\\gamecontrollerdb.txt" && oldFont != robloxFontFolderPath + "\\RobloxEmoji.ttf" && oldFont != robloxFontFolderPath + "\\TwemojiMozilla.ttf")
                    {
                        File.Delete(oldFont);
                        File.Copy(localFontPath, oldFont);
                    }
                }
                Console.WriteLine("Successfully copied fonts!");
                return;
            }
            Console.WriteLine("Error: font.ttf is missing in " + appPath);
        }

        public static void CopyTextures()
        {
            Console.WriteLine("Copying textures..");
            string localTexturesFolderPath = appPath + "textures";
            if (Directory.Exists(localTexturesFolderPath))
            {
                string robloxTexturesPath = robloxPath + "\\PlatformContent\\pc\\textures";
                Console.WriteLine("Textures path: " + localTexturesFolderPath);
                if (Directory.Exists(robloxTexturesPath))
                {
                    CopyDirectory(localTexturesFolderPath, robloxTexturesPath, true);
                    Console.WriteLine("Successfully copied textures!");
                    return;
                }
                Console.WriteLine("Error: Couldn't find roblox textures path." + robloxTexturesPath);
                return;
            }
            Console.WriteLine("Error: Couldn't find local textures file: " + localTexturesFolderPath);
            return;
        }

        public static void CopyClientSettings()
        {
            string clientSettingsFolderPath = appPath + "ClientSettings";
            string clientSettingsPath = clientSettingsFolderPath + "\\ClientAppSettings.json";
            Console.WriteLine("Copying client settings..");
            if (File.Exists(clientSettingsPath))
            {
                CopyDirectory(clientSettingsFolderPath, robloxPath + "\\ClientSettings", false);
                Console.WriteLine("ClientAppSettings file path:" + robloxPath + "\\ClientSettings\\ClientAppSettings.json");
                Console.WriteLine("Successfully copied ClientAppSettings!");
                return;
            }
            Console.WriteLine("Error: Couldn't find ClientAppSettings.json in folder " + clientSettingsPath);
            return;
        }

        public static string getUserName()
        {
            return userName;
        }

        public static string getFilePath()
        {
            return "C:\\Users\\" + getUserName() + "\\AppData\\Local\\Roblox\\Versions";
        }

        public static string getRobloxFilePath()
        {
            // Check local files for latest Roblox version (ignoring studio)
            var lastModifiedFolders = new DirectoryInfo(getFilePath())
                .GetDirectories()
                .OrderByDescending(d => d.LastWriteTime)
                .Take(2)
                .ToList();

            foreach (var folder in lastModifiedFolders)
            {
                if (folder.EnumerateFiles("RobloxPlayerBeta.exe").Any())
                {
                    return getFilePath() + "\\" + folder.ToString();
                }
            }
            return null;
        }

        public static void CopyDirectory(string source, string target, bool recursive)
        {
            var dir = new DirectoryInfo(source);
            if (!dir.Exists) throw new DirectoryNotFoundException("Error: Source not found.");
            Directory.CreateDirectory(target);

            foreach (var file in dir.GetFiles())
            {
                file.CopyTo(Path.Combine(target, file.Name), true);
            }

            if(recursive)
            {
                foreach(var subDir in dir.GetDirectories())
                {
                    CopyDirectory(subDir.FullName, Path.Combine(target, subDir.Name), true);
                }
            }
        }
    }
}
