﻿using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Nikon)]
    public class NikonContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new NikonContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Nikon;
        }
    }
}
