using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class UserL
    {
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class UserBL
    {
        string connection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public int CheckUserLogin(UserL User)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand comObj = new SqlCommand("spLogin", con);
                comObj.CommandType = CommandType.StoredProcedure;
                comObj.Parameters.Add(new SqlParameter("@username", User.UserName));
                comObj.Parameters.Add(new SqlParameter("@password", User.Password));
                con.Open();
                return Convert.ToInt32(comObj.ExecuteScalar());
            }
        }
    }

}