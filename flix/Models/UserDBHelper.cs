using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class UserDBHelper : DBHelper
    {
        public UserDBHelper()
        {
            Initialize();
        }

        public bool Add(User user)
        {
            SqlCommand cmd = new SqlCommand("User_Add", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@PathImage", user.PathImage);
            cmd.Parameters.AddWithValue("@Age", user.Age);
            cmd.Parameters.AddWithValue("@User_Genre_Id", user.User_Genre.Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public List<User> GetById(long id)
        {
            List<User> users = new List<User>();

            SqlCommand cmd = new SqlCommand("User_GetById", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();
            
            foreach (DataRow dRow in dTable.Rows)
            {
                var user = new User
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"]),
                    LastName = Convert.ToString(dRow["LastName"]),
                    Username = Convert.ToString(dRow["Username"]),
                    Email = Convert.ToString(dRow["Email"]),
                    Password = Convert.ToString(dRow["Password"]),
                    PathImage = Convert.ToString(dRow["PathImage"]),
                    Age = Convert.ToInt16(dRow["Age"]),
                    User_Genre = new UserGenre
                    {
                        Id = Convert.ToInt64(dRow["UserGenderId"]),
                        Name = Convert.ToString(dRow["UserGenderName"])
                    }
                   
                };
                users.Add(user);
             
            }

            return users;
        }

        public List<User> GetByName(string name)
        {
            List<User> users = new List<User>();

            SqlCommand cmd = new SqlCommand("User_GetByName", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", name);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var user = new User
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"]),
                    LastName = Convert.ToString(dRow["LastName"]),
                    Username = Convert.ToString(dRow["Username"]),
                    Email = Convert.ToString(dRow["Email"]),
                    Password = Convert.ToString(dRow["Password"]),
                    PathImage = Convert.ToString(dRow["PathImag"]),
                    Age = Convert.ToInt16(dRow["Age"]),
                    User_Genre = new UserGenre
                    {
                        Id = Convert.ToInt64(dRow["UserGenderId"]),
                        Name = Convert.ToString(dRow["UserGenderString"])
                    }

                };

                users.Add(user);
            }

            return users;
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();

            SqlCommand cmd = new SqlCommand("User_GetAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var user = new User
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Name = Convert.ToString(dRow["Name"]),
                    LastName = Convert.ToString(dRow["LastName"]),
                    Username = Convert.ToString(dRow["Username"]),
                    Email = Convert.ToString(dRow["Email"]),
                    Password = Convert.ToString(dRow["Password"]),
                    PathImage = Convert.ToString(dRow["PathImag"]),
                    Age = Convert.ToInt16(dRow["Age"]),
                    User_Genre = new UserGenre
                    {
                        Id = Convert.ToInt64(dRow["UserGenderId"]),
                        Name = Convert.ToString(dRow["UserGenderString"])
                    }

                };

                users.Add(user);
            }

            return users;
        }

        public bool Update(User user)
        {
            SqlCommand cmd = new SqlCommand("User_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", user.Id);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@PathImage", user.PathImage);
            cmd.Parameters.AddWithValue("@Age", user.Age);
            cmd.Parameters.AddWithValue("@User_Genre_Id", user.User_Genre.Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Upsert(User user)
        {
            SqlCommand cmd = new SqlCommand("User_Upsert", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", user.Id);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@PathImage", user.PathImage);
            cmd.Parameters.AddWithValue("@Age", user.Age);
            cmd.Parameters.AddWithValue("@User_Genre_Id", user.User_Genre.Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Delete(long Id)
        {
            SqlCommand cmd = new SqlCommand("User_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public ProfileViewModel GetUserProfileById(long id)
        {
            ProfileViewModel users = new ProfileViewModel();
            Movie movie = new Movie();
            Review review = new Review();
            Poster poster = new Poster();
            List<Movie> PMovie = new List<Movie>();
            List<Review> PReview = new List<Review>();
            List<Poster> PPoster = new List<Poster>();


            SqlCommand cmd = new SqlCommand("Review_GetByUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                poster = new Poster()
                {
                    PathImage = Convert.ToString(dRow["PathImage"])
                };

                movie = new Movie()
                {
                    Id = Convert.ToInt64(dRow["MovieId"]),
                    Title = Convert.ToString(dRow["Title"]),
                    
                };
                review = new Review()
                {
                    Id = Convert.ToInt64(dRow["ReviewId"]),
                    Comment = Convert.ToString(dRow["Comment"]),
                    Watched = Convert.ToBoolean(dRow["Watched"]),
                    Rank = Convert.ToInt16(dRow["Rank"]),
                    Wished = Convert.ToBoolean(dRow["Wished"]),
                    Date = Convert.ToDateTime(dRow["Date"]),

                };
            
                PMovie.Add(movie);
                PReview.Add(review);
                PPoster.Add(poster);
                users = new ProfileViewModel()
                {
                    LReviews = PReview,
                    LMovie = PMovie,
                    LPoster = PPoster
                };
               
            }



            return users;
        }

        public long UserExist(long id)
        {
            SqlCommand cmd = new SqlCommand("User_Exist", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

          
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();
            int response = 0;
            foreach (DataRow dRow in dTable.Rows)
            {
                response = unchecked ((int)Convert.ToInt64(dRow["Exists"]));
            }
            
            return response;
        }
    }
}