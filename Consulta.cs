using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetofinal
{
    public class Consulta
    {
        public int Id { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public int Local { get; set; }
        public int Descricao { get; set; }
        public override string ToString()
        {
            return $"{Id} - Paciente: {IdPaciente} - Médico: {IdMedico} - {Data} - {Hora} - {Local}- {Descricao}";
        }
    }
}
