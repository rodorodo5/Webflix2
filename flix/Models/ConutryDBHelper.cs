using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class ConutryDBHelper : DBHelper
    {

        public ConutryDBHelper()
        {
            Initialize();
        }

        public bool Add(Country country)
        {
            SqlCommand cmd = new SqlCommand("Country_Add", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", country.Name);
            cmd.Parameters.AddWithValue("@Abbv", country.Abbv);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public List<Country> GetById(long id)
        {
            List<Country> countries = new List<Country>();

            SqlCommand cmd = new SqlCommand("Country_GetById", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var country = new Country
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"]),
                    Abbv = Convert.ToString(dRow["Abbv"])
                };

                countries.Add(country);
            }

            return countries;
        }

        public List<Country> GetByName(string name)
        {
            List<Country> countries = new List<Country>();

            SqlCommand cmd = new SqlCommand("Country_GetByName", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", name);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var country = new Country
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"]),
                    Abbv = Convert.ToString(dRow["Abbv"])
                };

                countries.Add(country);
            }

            return countries;
        }

        public List<Country> GetAll()
        {
            List<Country> countries = new List<Country>();

            SqlCommand cmd = new SqlCommand("Country_GetAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var country = new Country
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"]),
                    Abbv = Convert.ToString(dRow["Abbv"])
                };

                countries.Add(country);
            }

            return countries;
        }

        public bool Update(Country country)
        {
            SqlCommand cmd = new SqlCommand("Country_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", country.Id);
            cmd.Parameters.AddWithValue("@Name", country.Name);
            cmd.Parameters.AddWithValue("@Abbv", country.Abbv);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Upsert(Country country)
        {
            SqlCommand cmd = new SqlCommand("Country_Upsert", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", country.Id);
            cmd.Parameters.AddWithValue("@Name", country.Name);
            cmd.Parameters.AddWithValue("@Abbv", country.Abbv);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Delete(long Id)
        {
            SqlCommand cmd = new SqlCommand("Country_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }
    }
}