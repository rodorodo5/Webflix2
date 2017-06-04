using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class PosterDBHelper : DBHelper
    {
        public PosterDBHelper()
        {
            Initialize();
        }

        public bool Add(Poster poster)
        {
            SqlCommand cmd = new SqlCommand("Poster_Add", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Image", poster.PathImage);
            cmd.Parameters.AddWithValue("@Movie_Id", poster.Movie.Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }
        public List<Poster> GetByMovieId(long id)
        {
            List<Poster> posters = new List<Poster>();

            SqlCommand cmd = new SqlCommand("Poster_GetByMovieId", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Movie_Id", id);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var poster = new Poster
                {
              
                    PathImage = Convert.ToString(dRow["PathImage"])
                   
                };

                posters.Add(poster);
            }

            return posters;
        }
        public List<Poster> GetById(long id)
        {
            List<Poster> posters = new List<Poster>();

            SqlCommand cmd = new SqlCommand("Poster_GetById", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var poster = new Poster
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    PathImage = Convert.ToString(dRow["PathImage"]),
                    Movie = new Movie
                    {
                        Id = Convert.ToInt64(dRow["MovieId"]),
                        Title = Convert.ToString(dRow["MovieTitle"]),
                        Year = Convert.ToInt16(dRow["MovieYear"]),
                        Length = Convert.ToInt16(dRow["MovieLength"]),
                        Sinopsis = Convert.ToString(dRow["MovieSinopsis"]),
                        Description = Convert.ToString(dRow["MovieDescription"]),
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
                    }
                };

                posters.Add(poster);
            }

            return posters;
        }

        public List<Poster> GetAll()
        {
            List<Poster> posters = new List<Poster>();

            SqlCommand cmd = new SqlCommand("Poster_GetAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var poster = new Poster
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    PathImage = Convert.ToString(dRow["PathImage"]),
                    Movie = new Movie
                    {
                        Id = Convert.ToInt64(dRow["MovieId"]),
                        Title = Convert.ToString(dRow["MovieTitle"]),
                        Year = Convert.ToInt16(dRow["MovieYear"]),
                        Length = Convert.ToInt16(dRow["MovieLength"]),
                        Sinopsis = Convert.ToString(dRow["MovieSinposis"]),
                        Description = Convert.ToString(dRow["MovieDiscription"]),
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
                    }
                };

                posters.Add(poster);
            }

            return posters;
        }

        public bool Update(Poster poster)
        {
            SqlCommand cmd = new SqlCommand("Poster_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", poster.Id);
            cmd.Parameters.AddWithValue("@Name", poster.PathImage);
            cmd.Parameters.AddWithValue("@Movie_Id", poster.Movie.Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Upsert(Poster poster)
        {
            SqlCommand cmd = new SqlCommand("Poster_Upsert", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", poster.Id);
            cmd.Parameters.AddWithValue("@Name", poster.PathImage);
            cmd.Parameters.AddWithValue("@Movie_Id", poster.Movie.Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Delete(long Id)
        {
            SqlCommand cmd = new SqlCommand("Poster_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }
    }
}