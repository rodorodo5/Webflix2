using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class DirectorDBHelper : DBHelper
    {
        
        public DirectorDBHelper()
        {
            Initialize();
        }

        public bool Add(Director director)
        {
            SqlCommand cmd = new SqlCommand("Director_Add", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@Name", director.Name);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public List<Director> GetById(long id)
        {
            List<Director> directors = new List<Director>();

            SqlCommand cmd = new SqlCommand("Director_GetById", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var director = new Director
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"])
                };

                directors.Add(director);
            }

            return directors;
        }

        public List<Director> GetByName(string name)
        {
            List<Director> directors = new List<Director>();

            SqlCommand cmd = new SqlCommand("Director_GetByName", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", name);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var director = new Director
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"])
                };

                directors.Add(director);
            }

            return directors;
        }

        public List<Director> GetAll()
        {
            List<Director> directors = new List<Director>();

            SqlCommand cmd = new SqlCommand("Director_GetAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var director = new Director
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"])
                };

                directors.Add(director);
            }

            return directors;
        }

        public bool Update(Director director)
        {
            SqlCommand cmd = new SqlCommand("Director_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", director.Id);
            cmd.Parameters.AddWithValue("@Name", director.Name);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Upsert(Director director)
        {
            SqlCommand cmd = new SqlCommand("Director_Upsert", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", director.Id);
            cmd.Parameters.AddWithValue("@Name", director.Name);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Delete(long Id)
        {
            SqlCommand cmd = new SqlCommand("Director_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }
    }
}