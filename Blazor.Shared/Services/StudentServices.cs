using Blazor.Shared.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Services
{
    public class StudentServices : IStudentServices
    {


        string connectionString = string.Empty;
        private readonly IConfiguration configuration;

        public StudentServices(IConfiguration _configuration)
        {
            connectionString = _configuration.GetConnectionString("DBConnection");
        }


        public IEnumerable<StudentEntity> GetAllStudent()
        {
            List<StudentEntity> lstStudent = new List<StudentEntity>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetStudentsRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    StudentEntity student = new StudentEntity();
                    student.StudentID = Convert.ToInt32(rdr["StudentID"]);
                    student.FirstName = rdr["FirstName"].ToString();
                    student.LastName = rdr["LastName"].ToString();
                    student.EmailAddress = rdr["EmailAddress"].ToString();
                    student.Gender = rdr["Gender"].ToString();
                    student.CreatedOn = Convert.ToDateTime(rdr["CreatedOn"].ToString());
                 

                    lstStudent.Add(student);
                }
                con.Close();
            }
            return lstStudent;
        }

        //-- Func for creating new student record
        public void AddStudent(StudentEntity student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddNewStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@EmailAddress", student.EmailAddress);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
             
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public void UpdateStudent(StudentEntity student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateStudentRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", student.StudentID);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@EmailAddress", student.EmailAddress);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public void DeleteStudent(int? StudentID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteStudentRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", StudentID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
