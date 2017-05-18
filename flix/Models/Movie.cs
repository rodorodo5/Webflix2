using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class Movie
    {
<<<<<<< HEAD
        //string strConnection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

=======
>>>>>>> Cambios de vistas |Index| Reviews | Perfil
        public long Id { get; set; }
        public string Title { get; set; }
        public short Year { get; set; }
        public int Length { get; set; }
        public string Sinopsis { get; set; }
        public string Description { get; set; }
<<<<<<< HEAD
        //change to classes
        public long Country { get; set; }
        public long Director { get; set; }
        //public ICollection<long> Actors { get; set; }
        //public ICollection<long> Genres { get; set; }

        //public List<Movie> getMovies()
        //{
        //    List<Movie> movies = new List<Movie>();
        //    SqlConnection con = new SqlConnection(strConnection);
        //    string cmd = "SELECT * FROM Movie";
        //    SqlCommand sqlCmd = new SqlCommand(cmd, con);
        //    con.Open();
        //    SqlDataReader dr = sqlCmd.ExecuteReader();
        //    while(dr.Read())
        //    {
        //        Movie m = new Movie();
        //        m.Id = long.Parse(dr["Id"].ToString());
        //        m.Title = dr["title"].ToString();
        //        m.Year = short.Parse(dr["year"].ToString());
        //        m.Length = dr["length"].ToString();
        //        m.Sinopsis = dr["sinopsis"].ToString();
        //        m.Description = dr["description"].ToString();

        //        //change to classes eventually
        //        m.Country = long.Parse(dr["Country"].ToString());
        //        m.Director = long.Parse(dr["Director"].ToString());

        //        string cmd2 = "SELECT Actor_Id FROM Movie_Actor WHERE Movie_Id = " + m.Id;
        //        SqlCommand sqlCmd2 = new SqlCommand(cmd, con);
        //        SqlDataReader dr2 = sqlCmd2.ExecuteReader();
        //        while(dr2.Read())
        //            Actors.Add(long.Parse(dr2["Actor_Id"].ToString()));

        //        string cmd3 = "SELECT Genre_Id FROM Movie_Genre WHERE Movie_Id = " + m.Id;
        //        SqlCommand sqlCmd3 = new SqlCommand(cmd, con);
        //        SqlDataReader dr3 = sqlCmd2.ExecuteReader();
        //        while (dr3.Read())
        //            Genres.Add(long.Parse(dr2["Genre_Id"].ToString()));

        //        movies.Add(m);
        //    }

        //    return movies;
        //}
=======
        public Country Country { get; set; }
        public Director Director { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Genre> Genres { get; set; }
>>>>>>> Cambios de vistas |Index| Reviews | Perfil
    }
}