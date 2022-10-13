using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tareaCrud
{
    public partial class _Default : Page
    {
        Estudiante _estudiante;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                _estudiante = new Estudiante();
                _estudiante.drop_puesto(drop_sangre);
                _estudiante.grid_empleados(grid_estudiantes);
            }
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            _estudiante = new Estudiante();
            if (_estudiante.agregar(txt_carne.Text,txt_nombres.Text,txt_apellidos.Text,txt_direccion.Text,txt_telefono.Text,txt_fn.Text,Convert.ToInt32(drop_sangre.SelectedValue),txt_email.Text, txt_genero.Text) > 0){
                lbl_mensaje.Text = "Ingreso Exitoso";
                _estudiante.grid_empleados(grid_estudiantes);
            }
        }

        protected void grid_estudiante_SelectedIndexChanged(object sender, EventArgs e)
        {
            //grid_empleados.SelectedValue.ToString();
            //grid_empleados.DataKeys[indice].Values["id"].ToString();
            txt_carne.Text = grid_estudiantes.SelectedRow.Cells[2].Text;
            txt_nombres.Text = grid_estudiantes.SelectedRow.Cells[3].Text;
            txt_apellidos.Text = grid_estudiantes.SelectedRow.Cells[4].Text;
            txt_direccion.Text = grid_estudiantes.SelectedRow.Cells[5].Text;
            txt_telefono.Text = grid_estudiantes.SelectedRow.Cells[6].Text;
            txt_email.Text = grid_estudiantes.SelectedRow.Cells[6].Text;
            txt_genero.Text = grid_estudiantes.SelectedRow.Cells[6].Text;
            DateTime fecha = Convert.ToDateTime(grid_estudiantes.SelectedRow.Cells[7].Text);
            txt_fn.Text  = fecha.ToString("yyyy-MM-dd");
            int indice = grid_estudiantes.SelectedRow.RowIndex;
            drop_sangre.SelectedValue = grid_estudiantes.DataKeys[indice].Values["id_sangre"].ToString();
            btn_modificar.Visible = true;
        }

        protected void grid_estudiante_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            _estudiante = new Estudiante();
            if (_estudiante.eliminar( Convert.ToInt32( e.Keys["id"])) > 0){
                lbl_mensaje.Text = "Eliminacion Exitoso...";
                _estudiante.grid_empleados(grid_estudiantes);
                btn_modificar.Visible = false;
            }
        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            _estudiante = new Estudiante();
            if (_estudiante.modificar(Convert.ToInt32(grid_estudiantes.SelectedValue), txt_carne.Text, txt_nombres.Text, txt_apellidos.Text, txt_direccion.Text, txt_telefono.Text, txt_fn.Text, Convert.ToInt32(drop_sangre.SelectedValue),txt_email.Text,txt_genero.Text) > 0)
            {
                lbl_mensaje.Text = "Modifacacion Exitoso...";
                _estudiante.grid_empleados(grid_estudiantes);
                btn_modificar.Visible = false;
            }
            
        }
    }
}