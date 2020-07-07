using System;
using System.Collections.Generic;
using System.Text;

namespace APPCOVID.DAL.DataManagers.Helper
{
    public static class DataManagerHelper
    {
        public enum DbDropStatus
        {
            DropSuccess = 1,
            DropFailed = 2,
            NotExists = 3
        }

        public enum MembershipPlan
        {
            Silver = 1,
            Gold = 2,
            Platinum = 3
        }
    }
}
