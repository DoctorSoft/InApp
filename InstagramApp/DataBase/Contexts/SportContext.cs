﻿using Constants;

namespace DataBase.Contexts
{
    public class SportContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new SportContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Sport;
        }
    }
}
