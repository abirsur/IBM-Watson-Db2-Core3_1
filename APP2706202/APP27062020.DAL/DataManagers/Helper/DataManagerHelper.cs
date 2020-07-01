using System;
using System.Collections.Generic;
using System.Text;

namespace APP27062020.DAL.DataManagers.Helper
{
    public static class DataManagerHelper
    {
        public enum DbDropStatus
        {
            DropSuccess = 1,
            DropFailed = 2,
            NotExists = 3
        }
    }
}
