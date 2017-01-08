using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using EntityFramework.BulkInsert.Extensions;

namespace TableCopyPaster
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataBaseContext source = new SalsaRikaContext();
            DataBaseContext destination = new NikonContext();

            var list = source.StarRecords
                .ToList().Select(model => new StarRecordDbModel
            {
                Link = model.Link,
                Id = 0,
                Followed = false,
                LastFollowing = null,
                LastUnfollowing = null
            }).ToList();

            var links = list.Select(model => model.Link.ToUpper()).ToList();

            var exceptlist = destination.StarRecords.Where(model => links.Any(link => link == model.Link.ToUpper())).ToList();

            list = list.Where(model => !exceptlist.Select(dbModel => dbModel.Link.ToUpper()).Contains(model.Link.ToUpper())).ToList(); 

            destination.BulkInsert(list);

            destination.SaveChanges();
        }
    }
}
