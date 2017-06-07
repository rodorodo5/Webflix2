using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class ReviewDBHelper : DBHelper
    {

        public ReviewDBHelper()
        {
            Initialize();
        }

        public bool Add(Review review)
        {
            SqlCommand cmd = new SqlCommand("Review_Add", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Comment", review.Comment);
            cmd.Parameters.AddWithValue("@Rank", review.Rank);
            cmd.Parameters.AddWithValue("@Watched", review.Watched);
            cmd.Parameters.AddWithValue("@Wished", review.Wished);
            cmd.Parameters.AddWithValue("@Movie_Id", review.Movie.Id);
            cmd.Parameters.AddWithValue("@User_Id", review.User.Id);
            cmd.Parameters.AddWithValue("@Date", review.Date);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public List<Review> GetById(long id)
        {
            List<Review> reviews = new List<Review>();

            SqlCommand cmd = new SqlCommand("Review_GetById", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var review = new Review
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Comment = Convert.ToString(dRow["Comment"]),
                    Rank = Convert.ToInt16(dRow["Rank"]),
                    Watched = Convert.ToBoolean(dRow["Watched"]),
                    Wished = Convert.ToBoolean(dRow["Wished"]),
                    Date = Convert.ToDateTime(dRow["Date"]),
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
                    },
                    User = new User
                    {
                        Id = Convert.ToInt64(dRow["UserId"]),
                        Name = Convert.ToString(dRow["UserName"]),
                        LastName = Convert.ToString(dRow["UserLastName"]),
                        Username = Convert.ToString(dRow["UserUsername"]),
                        Email = Convert.ToString(dRow["UserEmail"]),
                        Password = Convert.ToString(dRow["UserPassword"]),
                        PathImage = Convert.ToString(dRow["UserPathImage"]),
                        Age = Convert.ToInt16(dRow["UserAge"]),
                        User_Genre = new UserGenre
                        {
                            Id = Convert.ToInt64(dRow["UserGenreId"]),
                            Name = Convert.ToString(dRow["UserGenreName"]),
                        }
                    }
                };

                reviews.Add(review);
            }

            return reviews;
        }

        public List<Review> GetAll()
        {
            List<Review> reviews = new List<Review>();

            SqlCommand cmd = new SqlCommand("GetAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            connection.Open();
            dataAdapt.Fill(dTable);
            connection.Close();

            foreach (DataRow dRow in dTable.Rows)
            {
                var review = new Review
                {
                    Id = Convert.ToInt64(dRow["Id"]),
                    Comment = Convert.ToString(dRow["Comment"]),
                    Rank = Convert.ToInt16(dRow["Rank"]),
                    Watched = Convert.ToBoolean(dRow["Watched"]),
                    Wished = Convert.ToBoolean(dRow["Wished"]),
                    Date = Convert.ToDateTime(dRow["Date"]),
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
                    },
                    User = new User
                    {
                        Id = Convert.ToInt64(dRow["UserId"]),
                        Name = Convert.ToString(dRow["UserName"]),
                        LastName = Convert.ToString(dRow["UserLastName"]),
                        Username = Convert.ToString(dRow["UserUsername"]),
                        Email = Convert.ToString(dRow["UserEmail"]),
                        Password = Convert.ToString(dRow["UserPassword"]),
                        PathImage = Convert.ToString(dRow["UserPathImage"]),
                        Age = Convert.ToInt16(dRow["UserAge"]),
                        User_Genre = new UserGenre
                        {
                            Id = Convert.ToInt64(dRow["UserGenreId"]),
                            Name = Convert.ToString(dRow["UserGenreName"]),
                        }
                    }
                };

                reviews.Add(review);
            }

            return reviews;
        }

        public bool Update(Review review)
        {
            SqlCommand cmd = new SqlCommand("Review_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", review.Id);
            cmd.Parameters.AddWithValue("@Comment", review.Comment);
            cmd.Parameters.AddWithValue("@Rank", review.Rank);
            cmd.Parameters.AddWithValue("@Watched", review.Watched);
            cmd.Parameters.AddWithValue("@Wished", review.Wished);
            cmd.Parameters.AddWithValue("@Movie_Id", review.Movie.Id);
            cmd.Parameters.AddWithValue("@User_Id", review.User.Id);
            cmd.Parameters.AddWithValue("@Date", review.Date);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Upsert(Review review)
        {
            SqlCommand cmd = new SqlCommand("Review_Upsert", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", review.Id);
            cmd.Parameters.AddWithValue("@Comment", review.Comment);
            cmd.Parameters.AddWithValue("@Rank", review.Rank);
            cmd.Parameters.AddWithValue("@Watched", review.Watched);
            cmd.Parameters.AddWithValue("@Wished", review.Wished);
            cmd.Parameters.AddWithValue("@Movie_Id", review.Movie.Id);
            cmd.Parameters.AddWithValue("@User_Id", review.User.Id);
            cmd.Parameters.AddWithValue("@Date", review.Date);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public bool Delete(long Id)
        {
            SqlCommand cmd = new SqlCommand("Review_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();
            var response = cmd.ExecuteNonQuery();
            connection.Close();

            return response >= 1 ? true : false;
        }

        public List<Review> GetByUserId(long id)
        {
            List<Review> reviews = new List<Review>();

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
                var review = new Review
                {
                   
                    Comment = Convert.ToString(dRow["Comment"]),
                    Rank = Convert.ToInt16(dRow["Rank"]),
                    Watched = Convert.ToBoolean(dRow["Watched"]),
                    Wished = Convert.ToBoolean(dRow["Wished"]),
                    Date = Convert.ToDateTime(dRow["Date"]),
                    Movie = new Movie
                    {
                        Id = Convert.ToInt64(dRow["Movie_Id"]),
                        Title = Convert.ToString(dRow["Title"]),
                      
                      },
                  
                 
                };

                reviews.Add(review);
            }

            return reviews;
        }
    }
}