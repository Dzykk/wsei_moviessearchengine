﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Data.SqlClient;


namespace Search_Engine_Library
{
    public class DBConnect
    {
        private SqlConnection conn;
        public DBConnect() { }
        
        public SqlConnection Connect()
        {
            //conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\Database.mdf; Integrated Security = True");
            conn = new SqlConnection(@"Data Source=DESKTOP-BOFB2DM\SQLEXPRESS;Initial Catalog=MovieDB;Integrated Security=True");
            return conn;
        }

    }
}

