using APIRestTraining.Model.Colegio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Datos.Colegio
{
    public interface IAlumnosDataMapper
    {
        Task<int> AgregarAlumnos(Alumnos alumno);

        Task<List<Alumnos>> ObtenerAlumnosFiltro(int? idCarrera = null);
    }
}
