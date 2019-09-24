﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKho.Model
{
    class DataProvider
    {
        private static DataProvider _ins;
        public static DataProvider Ins {
            get
            {
                if (_ins == null) _ins = new DataProvider();
                return _ins;
            }
            set
            {
                _ins = value;
            }
            
        }

        public myproject3Entities DB { get; set; }
 
        public DataProvider()
        {
            DB = new myproject3Entities();
        }
       
    }
}
