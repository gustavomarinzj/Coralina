using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Coralina.modelo;

namespace Coralina
{
    public partial class frmInsertarUsuario : Form
    {
        public frmInsertarUsuario()
        {
            InitializeComponent();
        }

        private void frmInsertarUsuario_Load(object sender, EventArgs e)
        {

        }

        public void Limpiar()
        {
            txtCedula.Text = txtNombre.Text = txtUsuario.Text = txtContrasenna.Text = string.Empty;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(int.Parse(txtCedula.Text), txtNombre.Text, txtUsuario.Text, txtContrasenna.Text);
            UsuarioDB.InsertarUsuario(usuario);
            Limpiar();  
        }
    }
}
