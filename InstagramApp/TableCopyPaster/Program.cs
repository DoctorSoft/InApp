using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Contexts.InnerTools.StoreContexts;
using DataBase.Models;
using EntityFramework.BulkInsert.Extensions;

namespace TableCopyPaster
{
    public class Program
    {
        private static void CopyStars(DataBaseContext source, DataBaseContext destination)
        {
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

        private static void CopyUsers(IStoreContext source, IStoreContext destination)
        {
            var list = source.Users
                .ToList().Select(model => new UserDbModel
                {
                    Link = model.Link,
                    Id = 0,
                    UserStatus = UserStatus.ToFollow,
                }).ToList();

            if (list.Count > 50000)
            {
                var half = list.Count/2;
                var firstPart = list.Take(half);
                destination.BulkInsert(firstPart);
                var secondPart = list.Skip(half).Take(half + 1);
                destination.BulkInsert(secondPart);
            }
            else
            {
                destination.BulkInsert(list);
            }

            destination.SaveChanges();
        }

        public static void Main(string[] args)
        {
            IStoreContext source = new GrodnoStoreContext();
            IStoreContext destination = new KiotoContext();

            CopyUsers(source, destination);
        }
    }
}
