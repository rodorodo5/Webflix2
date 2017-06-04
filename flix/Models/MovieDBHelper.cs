using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class MovieDBHelper : DBHelper
    {
        public MovieDBHelper()
        {
            Initialize();
        }

        public bool Add(Movie movie)
        {
            SqlCommand cmd = new SqlCommand("Movie_Add", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Title", movie.Title);
            cmd.Parameters.AddWithValue("@Year", movie.Year);
            cmd.Parameters.AddWithValue("@Length", movie.Length);
            cmd.Parameters.AddWithValue("@Sinopsis", movie.Sinopsis);
            cmd.Parameters.AddWithValue("@Description", movie.Description);
            cmd.Parameters.AddWithValue("@Country", movie.Country.Id);
            cmd.Parameters.AddWithValue("@Director", movie.Director.Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public Movie GetById(long id)
        {
            Movie movie = new Movie();
            MovieActorDbHelper movieActorDbHelper = new MovieActorDbHelper();
            MovieGenreDBHelper moviegenreDbHelper = new MovieGenreDBHelper();
            PosterDBHelper posterDbHelper = new PosterDBHelper();

            SqlCommand cmd = new SqlCommand("Movie_GetById", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();
            List<Actor> actors = new List<Actor>();
            List<Genre> genre = new List<Genre>();
            List<Poster> posters = new List<Poster>();
           
            foreach (DataRow dRow in dTable.Rows)
            {
               movie = new Movie
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Title = Convert.ToString(dRow["Title"]),
                    Year = Convert.ToInt16(dRow["Year"]),
                    Length = Convert.ToInt16(dRow["Length"]),
                    Sinopsis = Convert.ToString(dRow["Sinopsis"]),
                    Description = Convert.ToString(dRow["Description"]),
                    Country = new Country
                    {
                        Id = Convert.ToInt64(dRow["CountryId"]),
                        Name = Convert.ToString(dRow["CountryName"]),
                        Abbv = Convert.ToString(dRow["CountryAbbv"])
                    },
                    Director = new Director
                    {
                        Id = Convert.ToInt64(dRow["DirectorId"]),
                        Name = Convert.ToString(dRow["DirectorName"])
                    },
                    MovieActors = movieActorDbHelper.GetByMovieId(id),
                    Genres = moviegenreDbHelper.GetByMovieId(id),
                    Posters = posterDbHelper.GetByMovieId(id)
                };


            }

            return movie;
        }

        public List<Movie> GetByName(string title)
        {
            List<Movie> movies = new List<Movie>();

            SqlCommand cmd = new SqlCommand("Movie_GetByName", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", title);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var movie = new Movie
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Title = Convert.ToString(dRow["Title"]),
                    Year = Convert.ToInt16(dRow["Year"]),
                    Length = Convert.ToInt16(dRow["Length"]),
                    Sinopsis = Convert.ToString(dRow["Sinposis"]),
                    Description = Convert.ToString(dRow["Discription"]),
                    Country = new Country
                    {
                        Id = Convert.ToInt64(dRow["CountryId"]),
                        Name = Convert.ToString(dRow["CountryName"]),
                        Abbv = Convert.ToString(dRow["CountryAbbv"])
                    },
                    Director = new Director
                    {
                        Id = Convert.ToInt64(dRow["DirectorId"]),
                        Name = Convert.ToString(dRow["DirectorName"])
                    }
                };

                movies.Add(movie);
            }

            return movies;
        }

        public List<Movie> GetAll()
        {
            List<Movie> movies = new List<Movie>();

            SqlCommand cmd = new SqlCommand("Movie_GetAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var movie = new Movie
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Title = Convert.ToString(dRow["Title"]),
                    Year = Convert.ToInt16(dRow["Year"]),
                    Length = Convert.ToInt16(dRow["Length"]),
                    Sinopsis = Convert.ToString(dRow["Sinposis"]),
                    Description = Convert.ToString(dRow["Discription"]),
                    Country = new Country
                    {
                        Id = Convert.ToInt64(dRow["CountryId"]),
                        Name = Convert.ToString(dRow["CountryName"]),
                        Abbv = Convert.ToString(dRow["CountryAbbv"])
                    },
                    Director = new Director
                    {
                        Id = Convert.ToInt64(dRow["DirectorId"]),
                        Name = Convert.ToString(dRow["DirectorName"])
                    }
                };

                movies.Add(movie);
            }

            return movies;
        }

        public bool Update(Movie movie)
        {
            SqlCommand cmd = new SqlCommand("Movie_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", movie.Id);
            cmd.Parameters.AddWithValue("@Title", movie.Title);
            cmd.Parameters.AddWithValue("@Year", movie.Year);
            cmd.Parameters.AddWithValue("@Length", movie.Length);
            cmd.Parameters.AddWithValue("@Sinopsis", movie.Sinopsis);
            cmd.Parameters.AddWithValue("@Description", movie.Description);
            cmd.Parameters.AddWithValue("@Country", movie.Country.Id);
            cmd.Parameters.AddWithValue("@Director", movie.Director.Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Upsert(Movie movie)
        {
            SqlCommand cmd = new SqlCommand("Movie_Upsert", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", movie.Id);
            cmd.Parameters.AddWithValue("@Title", movie.Title);
            cmd.Parameters.AddWithValue("@Year", movie.Year);
            cmd.Parameters.AddWithValue("@Length", movie.Length);
            cmd.Parameters.AddWithValue("@Sinopsis", movie.Sinopsis);
            cmd.Parameters.AddWithValue("@Description", movie.Description);
            cmd.Parameters.AddWithValue("@Country", movie.Country.Id);
            cmd.Parameters.AddWithValue("@Director", movie.Director.Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Delete(long Id)
        {
            SqlCommand cmd = new SqlCommand("Movie_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }
    }
}