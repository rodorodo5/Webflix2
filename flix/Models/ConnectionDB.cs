using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public static class ConnectionDb
    {
        private static readonly string StrConnection = ConfigurationManager.ConnectionStrings["DBConnection"]
            .ConnectionString;

        public static List<Review> GetTop50Review()
        {
            List<Review> Review = new List<Review>();
            SqlConnection connection = new SqlConnection(StrConnection);
            string cmd = "SELECT TOP(50) from Review";
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            connection.Open();
            SqlDataReader dr = sqlCmd.ExecuteReader();
            while (dr.Read())
            {
                Review r = new Review();
                r.Id = long.Parse(dr["Id"].ToString());
                r.Movie.Title = dr["Movie"].ToString();
                r.Comment = dr["Comment"].ToString();
                r.User.Username = dr["user"].ToString();

                Review.Add(r);
            }
            return Review;

        }

        public static List<Genre> GetGenres()
        {
            List<Genre> genre = new List<Genre>();
            SqlConnection connection = new SqlConnection(StrConnection);
            string cmd = "SELECT * from Genre";
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            connection.Open();
            SqlDataReader dr = sqlCmd.ExecuteReader();
            while (dr.Read())
            {
                Genre g = new Genre();
                g.Id = long.Parse(dr["Id"].ToString());
                g.Name = dr["Name"].ToString();
                genre.Add(g);
            }
            return genre;
        }
    }
}