using APIRestTraining.Model.Colegio;
using APIRestTraining.Model.Generales;
using APIRestTraining.Negocio.Colegio;
using Microsoft.AspNetCore.Mvc;

namespace APIRestTraining.API2.Controllers
{
    [ApiController]
    [Route("Controller/api/Alumnos")]
    public class AlumnosController : Controller
    {
        private readonly IServicioAlumnos _servicioAlumnos;

        public AlumnosController(IServicioAlumnos servicioAlumnos)
        {
            _servicioAlumnos = servicioAlumnos;
        }

        [HttpPost, Route("ObtenerAlumnos")]
        public async Task<Response> AgregarAlumnos(Alumnos alumnos)
        {
            Response response = await _servicioAlumnos.AgregarAlumnos(alumnos);

            return response;
        }

        [HttpGet, Route("ObtenerAlumnosFiltro")]
        public async Task<Response> ObtenerAlumnosFiltro(int? idCarrera = null)
        {
            Response response = await _servicioAlumnos.ObtenerAlumnosFiltro(idCarrera);

            return response;
        }
    }
}
