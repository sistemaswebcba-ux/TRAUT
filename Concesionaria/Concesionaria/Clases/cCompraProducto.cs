using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Concesionaria.Clases
{
    public class cCompraProducto
    {
        public Int32 Insertar (SqlConnection con, SqlTransaction Transaccion,DateTime Fecha,string Numero, Int32? CodProveedor,
            Double Total )
        {
            string sql = "Insert into Compra (";
            sql = sql + "Fecha,Numero,CodProveedor,Total)";
            sql = sql + " values (" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + "'" + Numero + "'";
            if (CodProveedor != null)
                sql = sql + "," + CodProveedor.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + Total.ToString().Replace(",", ".");
            sql = sql + ")";
            Int32 CodCompra = 0;
            CodCompra = Convert.ToInt32 (cDb.EjecutarEscalarTransaccion(con, Transaccion, sql));
            return CodCompra;
        }

        public void InsertarDetalle (SqlConnection con, SqlTransaction Transaccion, Int32 CodCompra,
            Int32 CodProducto , int Cantidad ,Double Precio , Double Subtotal )
        {
            string sql = "insert into DetalleVentaProducto(";
            sql =sql + "CodCompra,CodProducto,Cantidad";
            sql = sql + ",Precio,Subtotal)";
            sql = sql + " values (";
            sql = sql + CodCompra.ToString();
            sql = sql + "," + CodProducto.ToString();
            sql = sql + "," + Cantidad.ToString();
            sql = sql + "," + Precio.ToString().Replace(",", ".");
            sql = sql + "," + Subtotal.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }
    }
}
