using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class TrailerDBHelper : DBHelper
    {
        public TrailerDBHelper()
        {
            Initialize();
        }

        public bool Add(Trailer trailer)
        {
            SqlCommand cmd = new SqlCommand("Trailer_Add", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Url", trailer.Url);
            cmd.Parameters.AddWithValue("@Movie_Id", trailer.Movie.Id);
            
            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public List<Trailer> GetById(long id)
        {
            List<Trailer> trailers = new List<Trailer>();

            SqlCommand cmd = new SqlCommand("Trailer_GetById", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var trailer = new Trailer
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Url = Convert.ToString(dRow["Url"]),
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

                trailers.Add(trailer);
            }

            return trailers;
        }

        public List<Trailer> GetAll()
        {
            List<Trailer> trailers = new List<Trailer>();

            SqlCommand cmd = new SqlCommand("Trailer_GetAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var trailer = new Trailer
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Url = Convert.ToString(dRow["Url"]),
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

                trailers.Add(trailer);
            }

            return trailers;
        }

        public bool Update(Trailer trailer)
        {
            SqlCommand cmd = new SqlCommand("Trailer_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", trailer.Id);
            cmd.Parameters.AddWithValue("@Url", trailer.Url);
            cmd.Parameters.AddWithValue("@Movie_Id", trailer.Movie.Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Upsert(Trailer trailer)
        {
            SqlCommand cmd = new SqlCommand("Trailer_Upsert", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", trailer.Id);
            cmd.Parameters.AddWithValue("@Url", trailer.Url);
            cmd.Parameters.AddWithValue("@Movie_Id", trailer.Movie.Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Delete(long Id)
        {
            SqlCommand cmd = new SqlCommand("Trailer_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }
    }
}