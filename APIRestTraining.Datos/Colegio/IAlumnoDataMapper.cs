using APIRestTraining.Model.Colegio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Datos.Colegio
{
    internal interface IAlumnoDataMapper
    {
        Task<List<Alumnos>> ObtenerAlumnos(Alumnos almnos);
    }
}
