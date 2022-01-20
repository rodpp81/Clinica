using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Agenda
    {
        public int Id { get; set; }        
        public DateTime DataDisponivel { get; set; }

        public List<Medico> Medicos { get; set; }
    }
}
