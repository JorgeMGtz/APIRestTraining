using APIRestTraining.Model.Colegio;
using APIRestTraining.Model.Conexion;
using Dapper;
using System.Data;

namespace APIRestTraining.Datos.Colegio.Implementacion
{
    //Clase para obtener los datos de lo alumnos
    public class AlumnosDataMapper : IAlumnosDataMapper
    {

        private readonly ConexionSql _conexionSql;
        private IDbConnection connection;

        // Se generara las funciones para generar con consultas
        public AlumnosDataMapper(ConexionSql conexionSql)
        {

            _conexionSql = conexionSql;
            connection = _conexionSql.CreateConnection();

        }

        public async Task<int> AgregarAlumnos(Alumnos alumno)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@Nombre", alumno.Nombre);
            dynamicParameters.Add("@Apellido", alumno.Apellido);
            dynamicParameters.Add("@F_Nacimiento", alumno.F_Nacimiento);
            dynamicParameters.Add("@idCarrera", alumno.idCarrera);
            dynamicParameters.Add("@Telefono", alumno.Telefono);

            int result = Convert.ToInt32( await connection.ExecuteScalarAsync("[dbo].[Alumnos_INSERT]",dynamicParameters, commandType: CommandType.StoredProcedure));

            return 0;
        }

        public async Task<List<Alumnos>> ObtenerAlumnosFiltro(int? idCarrera = null)
        {

            List<Alumnos> listaAlumnos = new List<Alumnos>();

            string sql = "select * from [dbo].[Alumnos] ";
            
            if (idCarrera != null)
            {
                sql += "where idCarrera = " + idCarrera ;
            }

            listaAlumnos = connection.Query<Alumnos>(sql).ToList();

            return listaAlumnos;
        }

    }
}
