using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Coralina.vista
{
    public partial class frmIniciarSesion : Form
    {
        public frmIniciarSesion()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            UsuarioDB usuario = new UsuarioDB();
            var iniciarSesion= UsuarioDB.ValidarUsuario(txtUsername.Text, txtContrasenna.Text);

            if (iniciarSesion == true)
            {
                MessageBox.Show("Bienvenido");
            }
            else
            {
                MessageBox.Show("Datos no válidos");
            }

        }
    }
}
