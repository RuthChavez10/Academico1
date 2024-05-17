using Academico.Entidades;
using Academico.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academico.Presentacion
{
    public partial class Frm_Estudiante : Form
    {
        public Frm_Estudiante()
        {
            InitializeComponent();
        }

        EstudianteNegocio objnegocio = new EstudianteNegocio();
        Estudiante objEstudiante = new Estudiante();

        FuenteExterna objApi = new FuenteExterna();

        private void consultarDNI()
        {
            try
            {
                if (txtNum_doc.Text.Length == 8)
                {
                    dynamic respuesta = objApi.Get("https://dniruc.apisperu.com/api/v1/dni/" + txtNum_doc.Text + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImxtdGltYW5hZ0BnbWFpbC5jb20ifQ.udFejq_ZQw4kqP6wfRGX1RaKaksh-lFwcqlM7p9Y1dU");
                    txtNombres.Text = respuesta.nombres.ToString() + " " + respuesta.apellidoPaterno.ToString() + " " + respuesta.apellidoMaterno.ToString();
                }

                else
                {
                    MessageBox.Show("Ingrese un número de documento válido.", "Documento inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Ingrese un número de documento válido.", "Documento inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void Limpiar()
        { 
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                    c.Text = "";
            }
        }

        bool validar(string p1, string p2, string p3)
        {
            if (p1.Length == 0 || p2.Length == 0 || p3.Length == 0)
                return false;
            else
                return true;
        }



        private void btnListar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == string.Empty)
            {
                dataEstudiantes.DataSource = objnegocio.ListarEstudiantes();
            }
            else
            {
                dataEstudiantes.DataSource = objnegocio.ListarEstudiantesxNombre(txtBuscar.Text);
            }

        }

 


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validar(txtNum_doc.Text, txtNombres.Text, txtEmail.Text) == true)
            {
                objEstudiante.Num_doc = txtNum_doc.Text;
                objEstudiante.Nombres = txtNombres.Text;
                objEstudiante.Email = txtEmail.Text;
                objEstudiante.Estado = (this.chkEstado.Checked == true) ? true : false;

                try
                {
                    objnegocio.Agregar(objEstudiante);
                    MessageBox.Show("Se ha registrado un Nuevo Estudiante");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los Datos");
            }
        }



        private void dataEstudiantes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataEstudiantes.CurrentRow.Cells[0].Value.ToString();
            txtNum_doc.Text = dataEstudiantes.CurrentRow.Cells[1].Value.ToString();
            txtNombres.Text = dataEstudiantes.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dataEstudiantes.CurrentRow.Cells[3].Value.ToString();
            if (dataEstudiantes.CurrentRow.Cells[4].Value is true)
            {
                this.chkEstado.Checked = true;
            }
            else
            {
                this.chkEstado.Checked = false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (validar(txtNum_doc.Text, txtNombres.Text, txtEmail.Text) == true)
            {

                objEstudiante = objnegocio.Buscar(Convert.ToInt32(txtId.Text));
                objEstudiante.Num_doc = txtNum_doc.Text;
                objEstudiante.Nombres = txtNombres.Text;
                objEstudiante.Email = txtEmail.Text;
                objEstudiante.Estado = (this.chkEstado.Checked == true) ? true : false;

                try
                {
                    objnegocio.Actualizar(objEstudiante);
                    MessageBox.Show("Se ha Actualizado la Categoria");
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Primero Selecciona el registro que quieres Actualizar");
            }
        }



        private void txtNum_doc_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtNum_doc_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDNi_Click(object sender, EventArgs e)
        {
            consultarDNI();
        }

        private void Frm_Estudiante_Load(object sender, EventArgs e)
        {

        }
    }
}
