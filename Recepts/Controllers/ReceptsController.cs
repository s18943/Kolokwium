using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recepts.DTOs.Requests;
using Recepts.DTOs.Responses;
using Recepts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recepts.Models;
using System.Data.SqlClient;

namespace Recepts.Controllers
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
        public IActionResult Recepts()
        {
            using (var client = new SqlConnection("Data Source=db-mssql; Initial Catalog=s18943; Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = client;
                com.CommandText = "Select * FROM Perscription p " +
                                  "JOIN Perscription_Medicament e ON e.IdPerscription=p.IdPerscription " +
                                  "JOIN Medicament m ON m.IdMedicament=e.IdMedicament ";

                client.Open();
                var dr = com.ExecuteReader();
                List<Perscription> perscripeions = new List<Perscription>();
                string result = "";
                while (dr.Read())
                {
                   
                }
                if (result != "")
                    return Ok(result);
                return NotFound("Nie znaleziono recepta");
            }
        }
        [HttpPost("{name}")]
        public IActionResult ReceptsOfPatient(String name)
        {
            using (var client = new SqlConnection("Data Source=db-mssql; Initial Catalog=s18943; Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                return null;
            }
        }
        [HttpPost("{addRecep}")]
        public IActionResult AddRecept(ReceptRequest request)
        {
            AddReceptResponse result = _service.AddRecept(request);
            if (result != null)
                return Ok(result);
            return BadRequest(400);

        }
    }
}