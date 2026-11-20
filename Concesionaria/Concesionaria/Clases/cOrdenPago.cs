using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Concesionaria.Clases
{
    public class cOrdenPago
    {
        public Int32 Insertar(SqlConnection con, SqlTransaction Transaccion, DateTime Fecha,Double Efectivo,Double Tranferencia, Double Total)
        {
            Int32 CodOrden = 0;
            string sql = "insert into OrdenPago(";
            sql = sql + " Fecha,Efectivo,Tranferencia,Total)";
            sql = sql + " values (" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Efectivo.ToString().Replace(",", ".");
            sql = sql + "," + Tranferencia.ToString().Replace(",", ".");
            sql = sql + "," + Total.ToString().Replace(",", ".");
            sql = sql + ")";
            CodOrden = cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
            return CodOrden;
        }

        public void  InsertarDetalle(SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden, Int32 CodDeuda )
        {
            string sql = "insert into DetalleOrdenPago ";
            sql = sql + " (CodOrden,CodDeuda)";
            sql = sql + " values (";
            sql = sql + CodOrden.ToString();
            sql = sql + "," + CodDeuda.ToString();
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }
    }
}
