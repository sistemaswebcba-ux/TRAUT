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
            Double Total, DateTime FechaFactura)
        {
            string sql = "Insert into compraproducto (";
            sql = sql + "Fecha,Numero,CodProveedor,Total,FechaFactura)";
            sql = sql + " values (" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + "'" + Numero + "'";
            if (CodProveedor != null)
                sql = sql + "," + CodProveedor.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + Total.ToString().Replace(",", ".");
            if (Numero != "")
                sql = sql + "," + "'" + FechaFactura.ToShortDateString() + "'";
            else
                sql = sql + ",null";
            sql = sql + ")";
            Int32 CodCompra = 0;
            CodCompra = Convert.ToInt32 (cDb.EjecutarEscalarTransaccion(con, Transaccion, sql));
            return CodCompra;
        }

        public void InsertarDetalle (SqlConnection con, SqlTransaction Transaccion, Int32 CodCompra,
            Int32 CodProducto , int Cantidad ,Double Precio , Double Subtotal )
        {
            string sql = "insert into DetalleCompraProducto(";
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

        public DataTable GetCompraProducto(DateTime FechaDesde, DateTime FechaHasta, string Proveedor)
        {
            string sql = "";
            if (Proveedor =="")
            {
                sql = " select c.CodCompra,";
                sql = sql + "(select p.Nombre from ProveedorAccesorio p where p.CodProveedor = c.CodProveedor) as Proveedor ";
                sql = sql + ", c.Numero, c.Fecha, c.Total ,c.FechaFactura ";
                sql = sql + " from compraproducto c ";
                sql = sql + " where c.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
                sql = sql + " and c.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            }

            if (Proveedor !="")
            {
                sql = " select c.CodCompra,";
                sql = sql + " p.Nombre  as Proveedor ";
                sql = sql + ", c.Numero, c.Fecha, c.Total ,c.FechaFactura ";
                sql = sql + " from compraproducto c ,ProveedorAccesorio p ";
                sql = sql + " where c.CodProveedor =p.CodProveedor ";
                sql = sql + " and c.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
                sql = sql + " and c.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
                sql = sql + " and p.Nombre like " + "'%" + Proveedor + "%'";
            }
           
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetComrpaxCodigo(Int32 CodCompra)
        {
            string sql = "";
            sql = " select * from  compraproducto ";
            sql = sql + " where CodCompra =" + CodCompra.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetDetalleCompra (Int32 CodCompra)
        {
            string sql = "";
            sql = " select p.CodProducto, p.Codigo,p.Nombre,d.Cantidad,d.Precio,d.Subtotal ";
            sql = sql + " from DetalleCompraProducto d, Producto p ";
            sql = sql + " where d.CodProducto=p.CodProducto ";
            sql = sql + " and d.CodCompra = " + CodCompra.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void ActualizarNroFactura (Int32 CodCompra, string Numero, DateTime FechaFactira)
        {
            string sql = "update CompraProducto set ";
            sql = sql + " Numero =" + "'" + Numero + "'" ;
            sql = sql + ", FechaFactura=" + "'" + FechaFactira + "'";
            sql = sql + " where CodCompra =" + CodCompra.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public void AnularCompra(Int32 COdCOmpra)
        {
            Int32 CodProducto = 0;
            int Cantidad = 0;
            string sql2 = "";
            string sql = "select * from DetalleCompraProducto ";
            sql = sql + " where CodCompra =" + COdCOmpra.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                for (int i = 0; i < trdo.Rows.Count ; i++)
                {
                    CodProducto = Convert.ToInt32(trdo.Rows[i]["CodProducto"].ToString());
                    Cantidad = Convert.ToInt32(trdo.Rows[i]["Cantidad"].ToString());
                    sql2 = " update Producto set stock = isnull(stock,0) - " + Cantidad.ToString();
                    sql2 = sql2 + " where CodProducto =" + CodProducto.ToString();
                    cDb.ExecutarNonQuery(sql2);
                }
            }
            // CompraProducto
            sql = "delete from DetalleCompraProducto where CodCompra  =" + COdCOmpra.ToString();
            cDb.ExecutarNonQuery(sql);
            sql = "delete from CompraProducto where CodCompra  =" + COdCOmpra.ToString();
            cDb.ExecutarNonQuery(sql);
        }
    }
}
