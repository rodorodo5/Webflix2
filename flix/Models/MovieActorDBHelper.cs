using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class MovieActorDbHelper : DBHelper
    {
        public MovieActorDbHelper()
        {
            Initialize();
        }

        public bool Add(MovieActor movieActor)
        {
            SqlCommand cmd = new SqlCommand("MovieActor_Add", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Movie_Id", movieActor.Movie_Id);
            cmd.Parameters.AddWithValue("@CharacterName", movieActor.CharacterName);
            cmd.Parameters.AddWithValue("@CharacterDescription", movieActor.CharacterDescription);
            cmd.Parameters.AddWithValue("@Protagonist", movieActor.Protagonist);
            cmd.Parameters.AddWithValue("@VoiceOnly", movieActor.VoiceOnly);
            cmd.Parameters.AddWithValue("@Actor_Id", movieActor.Actor_Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1;
        }

        public List<MovieActor> GetById(long id)
        {
            List<MovieActor> movieActor = new List<MovieActor>();

            SqlCommand cmd = new SqlCommand("MovieActor_GetById", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var actor = new MovieActor
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Movie_Id = long.Parse(Convert.ToString(dRow["Movie_Id"])),
                    CharacterName = Convert.ToString(dRow["CharacterName"]),
                    CharacterDescription = Convert.ToString("CharacterDescription"),
                    Protagonist = bool.Parse(Convert.ToString(dRow["Protagonist"])),
                    VoiceOnly = bool.Parse(Convert.ToString(dRow["VoiceOnly"])),
                    Actor_Id = long.Parse(Convert.ToString(dRow["Actor_Id"]))
                };

                movieActor.Add(actor);
            }

            return movieActor;
        }

        public List<MovieActor> GetByName(string name)
        {
            List<MovieActor> movieActor = new List<MovieActor>();

            SqlCommand cmd = new SqlCommand("MovieActor_GetByName", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CharacterName", name);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var actor = new MovieActor
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Movie_Id = long.Parse(Convert.ToString(dRow["Movie_Id"])),
                    CharacterName = Convert.ToString(dRow["CharacterName"]),
                    CharacterDescription = Convert.ToString("CharacterDescription"),
                    Protagonist = bool.Parse(Convert.ToString(dRow["Protagonist"])),
                    VoiceOnly = bool.Parse(Convert.ToString(dRow["VoiceOnly"])),
                    Actor_Id = long.Parse(Convert.ToString(dRow["Actor_Id"]))
                };

                movieActor.Add(actor);
            }

            return movieActor;
        }

        public List<MovieActor> GetAll()
        {
            List<MovieActor> movieActor = new List<MovieActor>();

            SqlCommand cmd = new SqlCommand("MovieActor_GetAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var actor = new MovieActor
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Movie_Id = long.Parse(Convert.ToString(dRow["Movie_Id"])),
                    CharacterName = Convert.ToString(dRow["CharacterName"]),
                    CharacterDescription = Convert.ToString("CharacterDescription"),
                    Protagonist = bool.Parse(Convert.ToString(dRow["Protagonist"])),
                    VoiceOnly = bool.Parse(Convert.ToString(dRow["VoiceOnly"])),
                    Actor_Id = long.Parse(Convert.ToString(dRow["Actor_Id"]))
                };

                movieActor.Add(actor);
            }

            return movieActor;
        }

        //GetByMovieName - Using in MovieDBHelper
        public List<MovieActor> GetByMovieId(long Id)
        {
            List<MovieActor> movieActor = new List<MovieActor>();

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
                var actor = new MovieActor
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Movie_Id = long.Parse(Convert.ToString(dRow["Movie_Id"])),
                    CharacterName = Convert.ToString(dRow["CharacterName"]),
                    CharacterDescription = Convert.ToString("CharacterDescription"),
                    Protagonist = bool.Parse(Convert.ToString(dRow["Protagonist"])),
                    VoiceOnly = bool.Parse(Convert.ToString(dRow["VoiceOnly"])),
                    Actor_Id = long.Parse(Convert.ToString(dRow["Actor_Id"]))
                };

                movieActor.Add(actor);
            }

            return movieActor;
        }

        public bool Update(MovieActor movieActor)
        {
            SqlCommand cmd = new SqlCommand("MovieActor_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Movie_Id", movieActor.Movie_Id);
            cmd.Parameters.AddWithValue("@CharacterName", movieActor.CharacterName);
            cmd.Parameters.AddWithValue("@CharacterDescription", movieActor.CharacterDescription);
            cmd.Parameters.AddWithValue("@Protagonist", movieActor.Protagonist);
            cmd.Parameters.AddWithValue("@VoiceOnly", movieActor.VoiceOnly);
            cmd.Parameters.AddWithValue("@Actor_Id", movieActor.Actor_Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Upsert(MovieActor movieActor)
        {
            SqlCommand cmd = new SqlCommand("MovieActor_Upsert", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Movie_Id", movieActor.Movie_Id);
            cmd.Parameters.AddWithValue("@CharacterName", movieActor.CharacterName);
            cmd.Parameters.AddWithValue("@CharacterDescription", movieActor.CharacterDescription);
            cmd.Parameters.AddWithValue("@Protagonist", movieActor.Protagonist);
            cmd.Parameters.AddWithValue("@VoiceOnly", movieActor.VoiceOnly);
            cmd.Parameters.AddWithValue("@Actor_Id", movieActor.Actor_Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Delete(long id)
        {
            SqlCommand cmd = new SqlCommand("MovieActor_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

    }
}
