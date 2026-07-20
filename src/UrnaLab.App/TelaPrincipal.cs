using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UrnaLab.App
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAlunos_Click(object sender, EventArgs e)
        {
            TelaCadastroAlunos telaCadastroAlunos = new TelaCadastroAlunos();
            telaCadastroAlunos.ShowDialog();
        }
    }
}
