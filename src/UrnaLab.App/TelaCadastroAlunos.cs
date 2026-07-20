using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UrnaLab.App
{
    public partial class TelaCadastroAlunos : Form
    {
        public TelaCadastroAlunos()
        {
            InitializeComponent();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtRa.Text = "";
            txtNome.Text = "";
            txtTurma.Text = "";
            cboStatus.SelectedIndex = -1;

            txtRa.Focus();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string ra = txtRa.Text.Trim();
            string nome = txtNome.Text.Trim();
            string turma = txtTurma.Text.Trim();

            if (ra == "" || nome == "" || turma == "" || cboStatus.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Preencha todos os campos vazios.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );

                return;

            }

            MessageBox.Show(
                "Aluno Validado com Sucesso!",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }
    }
}
