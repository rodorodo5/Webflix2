using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class UserGenreDBHelper : DBHelper
    {
        public UserGenreDBHelper()
        {
            Initialize();
        }

        public bool Add(UserGenre userGenre)
        {
            SqlCommand cmd = new SqlCommand("User_Genre_Add", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", userGenre.Name);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public List<UserGenre> GetById(long id)
        {
            List<UserGenre> userGenres = new List<UserGenre>();

            SqlCommand cmd = new SqlCommand("User_Genre_GetById", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var userGenre = new UserGenre
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"])
                };

                userGenres.Add(userGenre);
            }

            return userGenres;
        }

        public List<UserGenre> GetByName(string name)
        {
            List<UserGenre> userGenres = new List<UserGenre>();

            SqlCommand cmd = new SqlCommand("User_Genre_GetByName", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", name);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var userGenre = new UserGenre
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"])
                };

                userGenres.Add(userGenre);
            }

            return userGenres;
        }

        public List<UserGenre> GetAll()
        {
            List<UserGenre> userGenres = new List<UserGenre>();

            SqlCommand cmd = new SqlCommand("User_Genre_GetAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var userGenre = new UserGenre
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"])
                };

                userGenres.Add(userGenre);
            }

            return userGenres;
        }

        public bool Update(UserGenre userGenre)
        {
            SqlCommand cmd = new SqlCommand("User_Genre_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", userGenre.Id);
            cmd.Parameters.AddWithValue("@Name", userGenre.Name);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Upsert(UserGenre userGenre)
        {
            SqlCommand cmd = new SqlCommand("User_Genre_Upsert", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", userGenre.Id);
            cmd.Parameters.AddWithValue("@Name", userGenre.Name);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Delete(long Id)
        {
            SqlCommand cmd = new SqlCommand("User_Genre_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }
    }
}