using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recepts.DTOs.Requests;
using Recepts.DTOs.Responses;
using Recepts.Models;

namespace Recepts.Services
{
    public interface IReceptDbService
    {
        AddReceptResponse AddRecept(ReceptRequest request);
        List<Perscription> GetAllRecepts();
        List<Perscription> GetAllReceptsOfPatient(String name);
    }
}
