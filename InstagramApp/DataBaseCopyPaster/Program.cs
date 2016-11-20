using System;
using System.Linq;
using DataBase.Contexts;
using EntityFramework.BulkInsert.Extensions;
using EntityFramework.Extensions;

namespace DataBaseCopyPaster
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var destinationConnection = new SportContext();
            var sourceConnection = new SourceContext.SourceContext(destinationConnection.GetAccountName());

            Console.WriteLine("Start Functionalities");

            var functionalities = sourceConnection.Functionalities.ToList();
            destinationConnection.Functionalities.Delete();
            destinationConnection.Functionalities.AddRange(functionalities);

            destinationConnection.SaveChanges();

            Console.WriteLine("Start Users");

            var users = sourceConnection.Users.ToList();
            destinationConnection.Users.Delete();
            destinationConnection.BulkInsert(users);

            destinationConnection.SaveChanges();

            Console.WriteLine("Start Activity Histories");

            var activityHistories = sourceConnection.ActivityHistories.ToList();
            destinationConnection.ActivityHistories.Delete();
            destinationConnection.BulkInsert(activityHistories);

            destinationConnection.SaveChanges();

            Console.WriteLine("Start Features");

            var features = sourceConnection.Features.ToList();
            destinationConnection.Features.Delete();
            destinationConnection.BulkInsert(features);

            destinationConnection.SaveChanges();

            Console.WriteLine("Start Functionality Records");

            var functionalityRecords = sourceConnection.FunctionalityRecords.ToList();
            destinationConnection.FunctionalityRecords.Delete();
            destinationConnection.BulkInsert(functionalityRecords);

            destinationConnection.SaveChanges();

            Console.WriteLine("Start Functionality Reports");

            var functionalityReports = sourceConnection.FunctionalityReports.ToList();
            destinationConnection.FunctionalityReports.Delete();
            destinationConnection.BulkInsert(functionalityReports);

            destinationConnection.SaveChanges();

            Console.WriteLine("Start Hashtags");

            var hashTags = sourceConnection.HashTags.ToList();
            destinationConnection.HashTags.Delete();
            destinationConnection.BulkInsert(hashTags);

            destinationConnection.SaveChanges();

            Console.WriteLine("Start Languages");

            var languages = sourceConnection.Languages.ToList();
            destinationConnection.Languages.Delete();
            destinationConnection.BulkInsert(languages);

            destinationConnection.SaveChanges();

            Console.WriteLine("Start Medias");

            var medias = sourceConnection.Medias.ToList();
            destinationConnection.Medias.Delete();
            destinationConnection.BulkInsert(medias);

            destinationConnection.SaveChanges();

            Console.WriteLine("Start Profile Settings");

            var profileSettings = sourceConnection.ProfileSettings.ToList();
            destinationConnection.ProfileSettings.Delete();
            destinationConnection.BulkInsert(profileSettings);

            destinationConnection.SaveChanges();

            Console.WriteLine("Start Regions");

            var regions = sourceConnection.ProfileSettings.ToList();
            destinationConnection.Regions.Delete();
            destinationConnection.BulkInsert(regions);

            destinationConnection.SaveChanges();

            Console.WriteLine("Start Spam Words");

            var spamWords = sourceConnection.SpamWords.ToList();
            destinationConnection.SpamWords.Delete();
            destinationConnection.BulkInsert(spamWords);

            Console.WriteLine("End");

            destinationConnection.SaveChanges();
        }
    }
}
