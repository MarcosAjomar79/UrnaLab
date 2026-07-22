using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UrnaLab.App.Data;

namespace UrnaLab.App
{
    public partial class TelaCadastroAlunos : Form
    {
        public TelaCadastroAlunos()
        {
            InitializeComponent();
            cboStatus.SelectedIndex = 0;
            CarregarAlunos();
        }

        private void CarregarAlunos()
        {
            dgvAlunos.DataSource = Database.ListarAlunos();

            if (dgvAlunos.Columns.Contains("Id"))
            {
                dgvAlunos.Columns["Id"].Visible = false;
            }

            if (dgvAlunos.Columns.Contains("Ra"))
            {
                dgvAlunos.Columns["Ra"].HeaderText = "RA/Matrícula";
            }
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

            string status = cboStatus.Text.Trim();

            try
            {
                Database.InserirAluno(ra, nome, turma, status);

                MessageBox.Show(
                    "Aluno Validado com Sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );

                btnLimpar.PerformClick();
                CarregarAlunos();
            }
            catch (Microsoft.Data.Sqlite.SqliteException)
            {
                MessageBox.Show(
                    "Já existe um aluno cadastrado com essas informações.",
                    "RA Duplicado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void dgvAlunos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
