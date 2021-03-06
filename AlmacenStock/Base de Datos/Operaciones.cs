﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AlmacenStock
{
    class Operaciones
    {
        Conexion cnn = new Conexion();

        //Produtos 
        //INSERT
        public bool Insert_producto(string nombre, int cantidad, string descripcion, int ComboboxTipo)
        {
            try
            {
                string sql = "INSERT INTO Producto VALUES('" + nombre + "','" + descripcion + "'," + ComboboxTipo + "," + cantidad + ")";
                SqlCommand cmd = new SqlCommand(sql, cnn.getConection_DonHugo()); // la instruccion sql + la conexion
                int n = cmd.ExecuteNonQuery(); // numero de filas afectadas
                return n > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //UPDATE
        public bool Update_producto(int codigo,string nombre, string descripcion, int cantidad,int comboboxTipo)
        {
            try
            {
                string sql = "Update Producto set Nombre_producto = '" + nombre + "', Cantidad_producto = " + cantidad + ",Descripcion_producto='" + descripcion + "',Id_tipo=" + comboboxTipo + " where Id_producto = " + codigo + "";// los string van con comillas simples
                SqlCommand cmd = new SqlCommand(sql, cnn.getConection_DonHugo()); // la instruccion sql + la conexion
                int n = cmd.ExecuteNonQuery(); // numero de filas afectadas
                return n > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //DELETE
        public bool Delete_producto(int codigo)
        {
            try
            {
                string sql = "delete from Producto where Id_producto = " + codigo + "";// los string van con comillas simples
                SqlCommand cmd = new SqlCommand(sql, cnn.getConection_DonHugo()); // la instruccion sql + la conexion
                int n = cmd.ExecuteNonQuery(); // numero de filas afectadas
                return n > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
  //___________________________________________________________________________________
        //Rescartar Producto
        public DataTable lista_Producto()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "select * from Producto";
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn.getConection_DonHugo());
                
                da.Fill(dt);
                
                return dt;
            }
            catch (Exception)
            {

                return null;
            }
        }
        //Rescatar Tipo

        public DataTable lista_Tipo()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "select * from Tipo";
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn.getConection_DonHugo());
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                return null;
            }
        }

        // Buscar Adminitrador
        public bool Validar_admin(string usuario, string contrasena){
            try
            {
                string sql = "SELECT * FROM Usuario WHERE (username='" + usuario + "' AND contrasena='" + contrasena + "')";
                SqlCommand cmd = new SqlCommand(sql, cnn.getConection_DonHugo()); // la instruccion sql + la conexion
                //int n = cmd.ExecuteNonQuery(); // numero de filas afectadas
                //return n>0 ;
                int n = Convert.ToInt32(cmd);
                return n>0;

            }
            catch (Exception)
            {
               
                return false;
            }
        
        }
    }
}
