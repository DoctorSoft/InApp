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
                case AccountName.Karina:
                    return new KarinaContext();
                case AccountName.SalsaRika:
                    return new SalsaRikaContext();
                case AccountName.Augustovski:
                    return new AugustovskiContext();
                case AccountName.Nikon:
                    return new NikonContext();
                case AccountName.KrissSpam:
                    return new KrissSpamContext();
                case AccountName.MakarovaSpam:
                    return new MakarovaSpamContext();
                case AccountName.NovikovaSpam:
                    return new NovikovaSpamContext();
                case AccountName.GreenDozor:
                    return new GreenDozorContext();
                case AccountName.Mirelle:
                    return new MirelleContext();
                case AccountName.Mumia:
                    return new MumiaContext();
                case AccountName.Canon:
                    return new CanonContext();
                case AccountName.Egor:
                    return new EgorContext();
                case AccountName.Gadanie:
                    return new GadanieContext();
                default:
                    throw new ArgumentOutOfRangeException("accountId", accountId, null);
            }
        }
    }
}