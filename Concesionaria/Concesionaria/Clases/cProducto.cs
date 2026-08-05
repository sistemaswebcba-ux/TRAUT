using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public class cProducto
    {
        public DataTable GetProducto(string Codigo, string Nombre)
        {
            string b = "0";
            string b1 = "0";
            if (Codigo != "")
                b = "1";
            if (Nombre != "")
                b1 = "1";
            string rdo = "";
            string sql = "";
            sql = " select CodProducto,Codigo,Nombre ";
            sql = sql + " from Producto ";
            switch(rdo)
            {
                case "01":
                    sql = sql + " where Nombre like " + "'%" + Nombre + "%'";
                    break;
                case "10":
                    sql = sql + " where Codigo like " + "'%" + Nombre + "%'";
                    break;
                case "11":
                    sql = sql + " where Codigo like " + "'%" + Nombre + "%'";
                    sql = sql + " and Nombre like " + "'%" + Nombre + "%'";
                    break;            
            }
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetProductoxCodigo(Int32 CodProducto)
        {
            string sql = "select * ";
            sql = sql + " from Producto ";
            sql = sql + " where CodProducto =" + CodProducto.ToString();
            return cDb.ExecuteDataTable(sql);
        }
    }
}
