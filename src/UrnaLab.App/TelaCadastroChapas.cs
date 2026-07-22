using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UrnaLab.App
{
    public partial class TelaCadastroChapas : Form
    {
        public TelaCadastroChapas()
        {
            InitializeComponent();
            cboStatus.SelectedIndex = 0;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNumero.Text = "";
            txtNome.Text = "";
            cboStatus.SelectedIndex = 0;

            txtNumero.Focus();
        }
    }
}
