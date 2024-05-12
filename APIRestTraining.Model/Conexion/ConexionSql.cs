using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Model.Conexion
{
    public class ConexionSql
    {
       
        private ConexionString conexionString;

        public ConexionSql(IOptionsMonitor<ConexionString> optionsMonitor)
        {
            conexionString = optionsMonitor.CurrentValue;
        }

        public IDbConnection CreateConnection() => new SqlConnection(conexionString.SqlConnection);



    }
}
