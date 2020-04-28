using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Cw3.DTOs.Requests;
using Cw3.DTOs.Responses;
using Cw3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [Route("api/recepts")]
    [ApiController]
    public class ReceptsController : ControllerBase
    {
        private IReceptDbService _service;

        public ReceptsController(IReceptDbService service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult ReceptsOfPatient(int name)
        {
            using (var client = new SqlConnection("Data Source=db-mssql; Initial Catalog=s18943; Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                string Ska = "s" + name;
                com.Connection = client;
                com.CommandText = "Select * FROM Student s " +
                                  "JOIN Enrollment e ON e.IdEnrollment=s.IdEnrollment " +
                                  "JOIN Studies t ON t.IdStudy=e.IdStudy " +
                                  " WHERE s.IndexNumber=@id";
                com.Parameters.AddWithValue("id", Ska);

                client.Open();
                var dr = com.ExecuteReader();
                List<Enrollment> enroliments = new List<Enrollment>();
                string result = "";
                while (dr.Read())
                {
                    var en = new Enrollment();
                    en.IdEnrollment = (int)dr["IdEnrollment"];
                    en.Semester = (int)dr["Semester"];
                    en.IdStudy = (int)dr["IdStudy"];
                    en.StartDate = (DateTime)dr["StartDate"];
                    result += name + " " + en.Semester + " " + dr["Name"].ToString() + " " + en.StartDate + "\n";
                }
                if (result != "")
                    return Ok(result);
                return NotFound("Nie znaleziono studenta");
            }
        }
        [HttpPost("{addRecep}")]
        public IActionResult AddRecept(ReceptRequest request)
        {
            PromoteStudentResponse result = _service.AddRecept(request);
            if (result!=null)
                return Ok(result);
            return BadRequest(400); 

        }
    }
}