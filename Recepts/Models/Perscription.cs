using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recepts.Models
{
    public class Perscription
    {
        public int Dose { get; internal set; }
        public String Medicament { get; internal set; }
        public String Detales { get; internal set; }
        public int IdPatient { get; internal set; }
        public DateTime Date { get; internal set; }
        public DateTime DueDate { get; internal set; }
    }
}
