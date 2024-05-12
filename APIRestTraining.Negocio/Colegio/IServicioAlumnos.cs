using APIRestTraining.Model.Colegio;
using APIRestTraining.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Negocio.Colegio
{
    public interface IServicioAlumnos
    {
        Task<Response> AgregarAlumnos(Alumnos alumno);

        Task<Response> ObtenerAlumnosFiltro(int? Carrera = null);

    }
}
