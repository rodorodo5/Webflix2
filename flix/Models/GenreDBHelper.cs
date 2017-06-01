using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class GenreDBHelper : DBHelper
    {
        public GenreDBHelper()
        {
            Initialize();
        }

        public bool Add(Genre genre)
        {
            SqlCommand cmd = new SqlCommand("Genre_Add", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", genre.Name);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public List<Genre> GetById(long id)
        {
            List<Genre> genres = new List<Genre>();

            SqlCommand cmd = new SqlCommand("Genre_GetById", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var genre = new Genre
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"])
                };

                genres.Add(genre);
            }

            return genres;
        }

        public List<Genre> GetByName(string name)
        {
            List<Genre> genres = new List<Genre>();

            SqlCommand cmd = new SqlCommand("Genre_GetByName", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", name);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var genre = new Genre
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"])
                };

                genres.Add(genre);
            }

            return genres;
        }

        public List<Genre> GetAll()
        {
            List<Genre> genres = new List<Genre>();

            SqlCommand cmd = new SqlCommand("Genre_GetAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var genre = new Genre
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"])
                };

                genres.Add(genre);
            }

            return genres;
        }

        public bool Update(Genre genre)
        {
            SqlCommand cmd = new SqlCommand("Genre_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", genre.Id);
            cmd.Parameters.AddWithValue("@Name", genre.Name);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Upsert(Genre genre)
        {
            SqlCommand cmd = new SqlCommand("Genre_Upsert", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", genre.Id);
            cmd.Parameters.AddWithValue("@Name", genre.Name);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Delete(long Id)
        {
            SqlCommand cmd = new SqlCommand("Genre_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }
    }
}