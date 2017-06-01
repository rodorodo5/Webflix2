using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public abstract class DBHelper
    {
        private string connString { get; set; }
        protected SqlConnection connection { get; set; }

        public void Initialize()
        {
            connString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            connection = new SqlConnection(connString);
        }
        
    }
}