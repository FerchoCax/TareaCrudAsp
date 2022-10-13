using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace tareaCrud
{
    public class Estudiante
    {
        ConexionBD conectar;
        private DataTable drop_estudiante(){
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select id_tipo_sangre as id,sangres from tipos_sangre;");
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }
        public void drop_puesto(DropDownList drop){
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elige Tipo Sangre >>");
            drop.Items[0].Value = "0";
            drop.DataSource = drop_estudiante();
            drop.DataTextField = "sangre";
            drop.DataValueField = "id";
            drop.DataBind();

        }
        private DataTable grid_empleados() {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            String consulta = string.Format("select e.id_estudiante, e.carne, e.nombres, e.apellidos, e.direccion, e.telefono, e.correo_electronico, e.id_tipo_sangre, s.sangre, date_format(e.fecha_nacimiento,\"%d/%m/%Y\") as fecha_nacimiento,  date_format(e.fecha_nacimiento,\"%Y-%m-%d\") as fecha_aux");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }
        public void grid_empleados(GridView grid){
            grid.DataSource = grid_empleados();
            grid.DataBind();

        }
        public int agregar(string carne,string nombres,string apellidos,string direccion,string telefono,string fecha,int id_tipo_sangre, string email, string genero){
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("insert into estudiantes(carne,nombres,apellidos,direccion,telefono,fecha_nacimiento,correo_electronico,genero,email,id_tipo_sangre) values('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},{8});", carne,nombres,apellidos,direccion,telefono,fecha, genero,email, id_tipo_sangre);
            MySqlCommand insertar = new MySqlCommand(consulta, conectar.conectar);
            insertar.Connection = conectar.conectar;
            int no_ingreso = insertar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;

        }
        public int modificar(int id ,string carne, string nombres, string apellidos, string direccion, string telefono, string fecha, int id_tipo_sangre, string email, string genero)
        {
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("update estudiantes set carne = '{0}',nombres = '{1}',apellidos = '{2}',direccion='{3}',telefono='{4}',fecha_nacimiento='{5}',id_tipo_sangre = {6}, email={8},genero ={9} where id_estudiante = {7};", carne, nombres, apellidos, direccion, telefono, fecha, id_tipo_sangre,id,email, genero);
            MySqlCommand modificar = new MySqlCommand(consulta, conectar.conectar);

            modificar.Connection = conectar.conectar;
            int no_ingreso = modificar.ExecuteNonQuery();

            conectar.CerarConexion();
            return no_ingreso;
        }
        public int eliminar(int id){
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("delete from estudiantes  where id_estudiante = {0};", id);
            MySqlCommand eliminar = new MySqlCommand(consulta, conectar.conectar);
            eliminar.Connection = conectar.conectar;
            int no_ingreso = eliminar.ExecuteNonQuery();

            conectar.CerarConexion();
            return no_ingreso;
        }

}
}