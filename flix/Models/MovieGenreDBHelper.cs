using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class MovieGenreDBHelper: DBHelper
    {

        public MovieGenreDBHelper()
        {
            Initialize();
        }

        public bool Add(MovieGenre movieGenre)
        {
            SqlCommand cmd = new SqlCommand("MovieGenre_Add", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Genre_Id", movieGenre.Genre_Id);
            cmd.Parameters.AddWithValue("@Movie_Id", movieGenre.Movie_Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public List<MovieGenre> GetById(long id)
        {
            List<MovieGenre > movieGenres = new List<MovieGenre>();

            SqlCommand cmd = new SqlCommand("MovieGenre_GetById", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var movieGenre = new MovieGenre
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Genre_Id = long.Parse(Convert.ToString(dRow["Genre_Id"])),
                    Movie_Id = long.Parse(Convert.ToString(dRow["Movie_Id"]))
                };

                movieGenres.Add(movieGenre);
            }

            return movieGenres;
        }

        public List<MovieGenre> GetByMovieId(long Id)
        {
            List<MovieGenre> movieGenres = new List<MovieGenre>();

            SqlCommand cmd = new SqlCommand("MovieActor_GetByMovieId", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var movieGenre = new MovieGenre
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Genre_Id = long.Parse(Convert.ToString(dRow["Genre_Id"])),
                    Movie_Id = long.Parse(Convert.ToString(dRow["Movie_Id"]))
                };

                movieGenres.Add(movieGenre);
            }

            return movieGenres;
        }

        public List<MovieGenre> GetAll()
        {
            List<MovieGenre> movieGenres = new List<MovieGenre>();

            SqlCommand cmd = new SqlCommand("MovieGenre_GetAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var movieGenre = new MovieGenre
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Genre_Id = long.Parse(Convert.ToString(dRow["Genre_Id"])),
                    Movie_Id = long.Parse(Convert.ToString(dRow["Movie_Id"]))
                };

                movieGenres.Add(movieGenre);
            }

            return movieGenres;
        }

        public bool Update(MovieGenre movieGenre)
        {
            SqlCommand cmd = new SqlCommand("MovieGenre_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", movieGenre.Id);
            cmd.Parameters.AddWithValue("@Genre_Id", movieGenre.Genre_Id);
            cmd.Parameters.AddWithValue("@Movie_Id", movieGenre.Movie_Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Upsert(MovieGenre movieGenre)
        {
            SqlCommand cmd = new SqlCommand("MovieGenre_Upsert", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", movieGenre.Id);
            cmd.Parameters.AddWithValue("@Genre_Id", movieGenre.Genre_Id);
            cmd.Parameters.AddWithValue("@Movie_Id", movieGenre.Movie_Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Delete(long Id)
        {
            SqlCommand cmd = new SqlCommand("MovieGenre_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

    }
}