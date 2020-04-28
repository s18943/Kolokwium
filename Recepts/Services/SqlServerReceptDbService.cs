using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recepts.DTOs.Requests;
using Recepts.DTOs.Responses;
using Recepts.Models;

namespace Recepts.Services
{
    public class SqlServerReceptDbService : IReceptDbService
    {
        private string ConnectionString = "Data Source=db-mssql;Initial Catalog=s18943;Integrated Security=True";

        public List<Perscription> GetAllRecepts()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Perscription", connection))
                {


                    connection.Open();

                    List<Perscription> result = new List<Perscription>();
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;
                        result.Add(new Perscription
                        {
                            IdPatient = (int)reader["IdPatient"],
                            Date = (DateTime)reader["Date"],
                            DueDate = (DateTime)reader["DueDate"]
                        });
                    }
                    return result;
                }
            }
        }

        public AddReceptResponse AddRecept(ReceptRequest request)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("", connection))
                {

                    return null;                 
                }
            }
        }

        public List<Perscription> GetAllReceptsOfPatient(string name)
        {
            throw new NotImplementedException();
        }
    }
}
