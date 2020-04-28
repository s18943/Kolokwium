using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw3.DTOs.Requests;
using Cw3.DTOs.Responses;
using Cw3.Models;

namespace Cw3.Services
{
    public interface IReceptDbService
    {
        EnrollStudentResponse EnrollStudent(ReceptRequest request);
        PromoteStudentResponse AddRecept(PromoteStudentRequest request);
        Student GetStudent(string index);
        PromoteStudentResponse PromoteStudents(ReceptRequest request);
    }
}
