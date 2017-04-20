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
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        string conStr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public void insert(User user)
        {
            using (SqlConnection conObj = new SqlConnection(conStr))
            {
                string sql = "INSERT INTO [dbo].[User] VALUES('" + user.UserName + "','" + user.Password +"')";
                //string sql = "INSERT INTO [dbo].[User] VALUES('rodi','rod')";
                SqlCommand cmd = new SqlCommand(sql, conObj);
                conObj.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    

}