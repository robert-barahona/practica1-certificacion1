using BEUEjercicio;
using BEUEjercicio.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryEjercicio
{
    public partial class frmAlumno : Form
    {
        public frmAlumno()
        {
            InitializeComponent();
        }

        private void frmAlumno_Load(object sender, EventArgs e)
        {
            cargarListado();
        }

        private void cargarListado()
        {
            dgvAlumnos.Rows.Clear();
            List<Alumno> alumnos = AlumnoBLL.List();
            dgvAlumnos.DataSource = alumnos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno a = new Alumno();
                a.nombres = txtNombre.Text.Trim();
                a.apellidos = txtApellido.Text.Trim();
                a.cedula = txtCedula.Text.Trim();
                a.lugar_nacimiento = txtLugarNac.Text.Trim();
                a.sexo = rbtMasculino.Checked ? "M" : "F";
                a.fecha_nacimiento = dtpFechaNac.Value;
                AlumnoBLL.Create(a);
                cargarListado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
