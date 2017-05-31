using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class ActorDBHelper : DBHelper
    {
        

        public ActorDBHelper()
        {
            Initialize();
        }

        public bool Add(Actor actor)
        {
            SqlCommand cmd = new SqlCommand("Actor_Add", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", actor.Name);
            cmd.Parameters.AddWithValue("@Image", actor.PathImage);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public List<Actor> GetById(long id)
        {
            List<Actor> actors = new List<Actor>();

            SqlCommand cmd = new SqlCommand("Actor_GetById", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var actor = new Actor
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"]),
                    PathImage = Convert.ToString(dRow["PathImage"])
                };

                actors.Add(actor);
            }

            return actors;
        }

        public List<Actor> GetByName(string name)
        {
            List<Actor> actors = new List<Actor>();

            SqlCommand cmd = new SqlCommand("Actor_GetByName", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", name);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var actor = new Actor
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"]),
                    PathImage = Convert.ToString(dRow["PathImage"])
                };

                actors.Add(actor);
            }

            return actors;
        }

        public List<Actor> GetAll()
        {
            List<Actor> actors = new List<Actor>();

            SqlCommand cmd = new SqlCommand("Actor_GetAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var actor = new Actor
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"]),
                    PathImage = Convert.ToString(dRow["PathImage"])
                };

                actors.Add(actor);
            }

            return actors;
        }

        public bool Update(Actor actor)
        {
            SqlCommand cmd = new SqlCommand("Actor_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", actor.Id);
            cmd.Parameters.AddWithValue("@Name", actor.Name);
            cmd.Parameters.AddWithValue("@Image", actor.PathImage);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Upsert(Actor actor)
        {
            SqlCommand cmd = new SqlCommand("Actor_Upsert", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", actor.Id);
            cmd.Parameters.AddWithValue("@Name", actor.Name);
            cmd.Parameters.AddWithValue("@Image", actor.PathImage);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Delete(long Id)
        {
            SqlCommand cmd = new SqlCommand("Actor_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

    }
}