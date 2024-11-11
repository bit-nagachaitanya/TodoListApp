using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TodoListApp.App_Code
{
    public class TaskRepository
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["TodoAppDB"].ConnectionString;

        public static List<Task> GetTasks()
        {
            List<Task> tasks = new List<Task>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Title, IsCompleted FROM Tasks";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new Task
                        {
                            Id = (int)reader["Id"],
                            Title = reader["Title"].ToString(),
                            IsCompleted = (bool)reader["IsCompleted"]
                        });
                    }
                }
            }

            return tasks;
        }

        public static void AddTask(Task task)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Tasks (Title, IsCompleted) VALUES (@Title, @IsCompleted)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Title", task.Title);
                cmd.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateTask(Task task)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateTask", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add parameters for the stored procedure
                cmd.Parameters.AddWithValue("@Id", task.Id);
                cmd.Parameters.AddWithValue("@Title", task.Title);
                cmd.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteTask(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteTask", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add the parameter for the stored procedure
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}