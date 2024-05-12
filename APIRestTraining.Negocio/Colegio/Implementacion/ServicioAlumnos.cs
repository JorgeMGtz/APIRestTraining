using APIRestTraining.Datos.Colegio;
using APIRestTraining.Model.Colegio;
using APIRestTraining.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Negocio.Colegio.Implementacion
{
    public class ServicioAlumnos : IServicioAlumnos
    {
        private readonly IAlumnosDataMapper _alumnosDataMapper;

        public ServicioAlumnos(IAlumnosDataMapper alumnosDataMapper) {
            _alumnosDataMapper = alumnosDataMapper;
        }

        public async Task<Response> AgregarAlumnos(Alumnos alumno)
        {
            Response response = new Response { status = false, code = (int)HttpStatusCode.InternalServerError };

            List<Alumnos> listaAlumnos = new List<Alumnos>();

            try
            {

                int resultado = await _alumnosDataMapper.AgregarAlumnos(alumno);

                listaAlumnos = await _alumnosDataMapper.ObtenerAlumnosFiltro();
                
                response.model = listaAlumnos;
                response.code = (int)HttpStatusCode.OK;
                response.status = true;

            }
            catch (Exception ex)
            {

                response.code = (int)HttpStatusCode.InternalServerError;
                response.message = ex.Message;
                response.status = false;
            }
           return response;
        }

        public async Task<Response> ObtenerAlumnosFiltro(int? idCarrera = null)
        {
            Response response = new Response { status = false, code = (int)HttpStatusCode.InternalServerError };

            List<Alumnos> listaAlumnos = new List<Alumnos>();

            try
            {

                listaAlumnos = await _alumnosDataMapper.ObtenerAlumnosFiltro(idCarrera);


                if (!listaAlumnos.Any())
                {

                    response.code = (int)HttpStatusCode.NoContent;
                    response.status = false;

                    return response;
                }

                response.model = listaAlumnos;
                response.code = (int)HttpStatusCode.OK;
                response.status = true;

            }
            catch (Exception ex)
            {

                response.code = (int)HttpStatusCode.InternalServerError;
                response.message = ex.Message;
                response.status = false;
            }
            return response;
        }
    }
}
