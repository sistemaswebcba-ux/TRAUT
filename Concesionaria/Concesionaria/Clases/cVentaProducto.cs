using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Concesionaria.Clases
{
    public class cVentaProducto
    {
        public Int32 Insertar(SqlConnection con, SqlTransaction Transaccion, DateTime Fecha, Int32? CodCliente,
          Double Total)
        {
            string sql = "Insert into VentaProducto (";
            sql = sql + "Fecha,CodCliente,Total)";
            sql = sql + " values (" + "'" + Fecha.ToShortDateString() + "'";
           
            if (CodCliente != null)
                sql = sql + "," + CodCliente.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + Total.ToString().Replace(",", ".");
            
            sql = sql + ")";
            Int32 CodVenta = 0;
            CodVenta = Convert.ToInt32(cDb.EjecutarEscalarTransaccion(con, Transaccion, sql));
            return CodVenta;
        }
    }
}
