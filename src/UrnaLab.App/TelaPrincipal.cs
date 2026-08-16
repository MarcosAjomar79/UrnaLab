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
            this.Hide();
            TelaCadastroAlunos telaCadastroAlunos = new TelaCadastroAlunos();
            telaCadastroAlunos.ShowDialog();
            this.Show();
        }

        private void btnChapas_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaCadastroChapas telaCadastroChapas = new TelaCadastroChapas();
            telaCadastroChapas.ShowDialog();
            this.Show();
        }

        private void btnVotacao_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaLiberarVotacao telaLiberarVotacao = new TelaLiberarVotacao();
            telaLiberarVotacao.ShowDialog();
            this.Show();
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaRelatorios telaRelatorios = new TelaRelatorios();
            telaRelatorios.ShowDialog();
            this.Show();
        }
    }
}
