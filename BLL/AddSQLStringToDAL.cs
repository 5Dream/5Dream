﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    class AddSQLStringToDAL
    {
        public static DataTable GetDatatableBySQL(string str1, string str2, string str3)
        {
           // throw new NotImplementedException();
            string strTemp = BuildSQLSelectString(str1, str2, str3);
            return ConnHelper.GetDataTable(strTemp);
        }
        public static DataTable GetDatatableBySQL() { }

    }
}
