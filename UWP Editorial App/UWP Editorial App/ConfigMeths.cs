using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace UWP_Editorial_App
{
    class ConfigMeths : FileManager
    {
        public ConfigMeths()
        {

        }
        public ConfigMeths(bool isMainWindow)
        {
            if (!KeyExists("Local"))
            {
                AddUpdateAppSettings("Local", @"ProgramData\UWP Editorial App");
            }
            if (!checkFileStructure(Local))
                MessageBox.Show("An Error as Occured while trying to Check/Create the file struture");

        }

        public string Local
        {
            get
            {
                return ReadSetting("Local");
            }
        }

        public string FileList
        {
            get
            {
                return ReadSetting("Local") + @"\SystemData";
            }
        }

        public string ReadSetting(string key)
        {

            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                return appSettings[key] ?? "Not Found";
            }
            catch (ConfigurationErrorsException)
            {
                return "Error reading app settings";
            }
        }

        public bool KeyExists(string Key)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[Key] == null)
                return false;
            else
                return true;

        }

        public void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        public Uri GetScreenSaverVideo
        {
            get
            {
                DirectoryInfo directory = new DirectoryInfo(FileList + @"\ScreenSaverVideo\");
                var Files = directory.GetFiles();
                if (Files.Count() > 0)
                {
                    return new Uri(Files.Select(o => o.FullName).FirstOrDefault());
                }
                else
                    return null;
            }
        }

        public int FilesInCatalogue
        {
            get
            {
                DirectoryInfo directory = new DirectoryInfo(FileList + @"\CatalogueItems\");
                return directory.GetDirectories().Count(o => o.Name != "TemplateItem");
            }
        }


        public FileInfo[] GetFiles(string FilePath)
        {
            DirectoryInfo directory = new DirectoryInfo(FilePath + "/Data");
            return directory.GetFiles();
        }

        public Uri GetFile(string FilePath)
        {
            DirectoryInfo directory = new DirectoryInfo(FilePath);
            if (directory.GetFiles().Count() > 0)
                return new Uri(directory.GetFiles().Select(o => o.FullName).FirstOrDefault());
            else
                return null;
        }

        public Uri GetCatalogueIcon(int IndexFile)
        {
            DirectoryInfo directory = new DirectoryInfo(FileList + @"\CatalogueItems\");
            var Directory = directory.GetDirectories();
            if (Directory.Count() > 0)
            {
                var Item = Directory[IndexFile];

                directory = new DirectoryInfo(Item.FullName + @"\ThumbNail\");
                var Files = directory.GetFiles();
                if (Files.Count() > 0)
                {
                    return new Uri(Files.Select(o => o.FullName).FirstOrDefault());
                }
                else
                {
                    directory = new DirectoryInfo(Item.FullName + @"\Images\");
                    Files = directory.GetFiles();
                    if (Files.Count() > 0)
                    {
                        return new Uri(Files.Select(o => o.FullName).FirstOrDefault());
                    }
                    else
                    {
                        directory = new DirectoryInfo(Item.FullName + @"\Videos\");
                        Files = directory.GetFiles();
                        if (Files.Count() > 0)
                        {
                            return new Uri(Files.Select(o => o.FullName).FirstOrDefault());
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            else
                return null;
        }

    }
}

