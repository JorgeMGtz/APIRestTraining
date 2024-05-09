using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Model.Colegio
{
    public class Alumnos
    {
        public int idAlumnos {  get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime F_Nacimiento { get; set; }
        public int idCarrera { get; set; }
        public string Telefono { get; set; }
    }
}
