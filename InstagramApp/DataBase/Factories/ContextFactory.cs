using System;
using Constants;
using DataBase.Contexts;

namespace DataBase.Factories
{
    public class ContextFactory : IContextFactory
    {
        public DataBaseContext GetContext(AccountName accountId)
        {
            switch (accountId)
            {
                case AccountName.Ozerny:
                    return new OzernyContext();
                case AccountName.Galaxy:
                    return new GalaxyContext();
                case AccountName.Kioto:
                    return new KiotoContext();
                case AccountName.Nazar:
                    return new NazarContext();
                case AccountName.Lajki:
                    return new LajkiContext();
                case AccountName.Itransition:
                    return new ItransitionContext();
                case AccountName.SalsaRika:
                    return new SalsaRikaContext();
                case AccountName.Augustovski:
                    return new AugustovskiContext();
                default:
                    throw new ArgumentOutOfRangeException("accountId", accountId, null);
            }
        }
    }
}