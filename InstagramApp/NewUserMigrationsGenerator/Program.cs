using System.IO;
using System.Reflection;

namespace NewUserMigrationsGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string newAccountName = "NewAccount";

            var assembly = Assembly.GetEntryAssembly().Location;

            var currentApplicationDirectory = Directory.GetParent(assembly).Parent.Parent.Parent.FullName;

            const string dataBaseProjectFork = "DataBase";
            const string migrationFolder = newAccountName + "Migrations";
            const string configurationFile = migrationFolder + "\\" + newAccountName + "Configuration.cs";
            var migrationFolderFullPath = currentApplicationDirectory + "\\" + dataBaseProjectFork + "\\" + migrationFolder;
            var migrationFileFullPath = currentApplicationDirectory + "\\" + dataBaseProjectFork + "\\" + configurationFile;
            
            var dataBaseProjectAddess = currentApplicationDirectory + "\\" + dataBaseProjectFork + "\\" + "DataBase.csproj";

            if (!Directory.Exists(migrationFolderFullPath))
            {
                Directory.CreateDirectory(migrationFolderFullPath);
            }

            if (!File.Exists(migrationFileFullPath))
            {
                File.Create(migrationFileFullPath);
            }

            var contextDirectory = "Contexts";

            var contextFile = contextDirectory + "\\" + newAccountName + "Context.cs";
            var contextFileFullPath = currentApplicationDirectory + "\\" + "DataBase" + "\\" + contextFile;

            if (!File.Exists(contextFileFullPath))
            {
                File.Create(contextFileFullPath);
            }

            var project = new Microsoft.Build.Evaluation.Project(dataBaseProjectAddess);
            project.AddItem("Compile", configurationFile);
            project.AddItem("Compile", contextFile);
            project.Save();
        }
    }
}
