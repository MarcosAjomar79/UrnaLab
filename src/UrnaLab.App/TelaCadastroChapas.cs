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
    public partial class TelaCadastroChapas : Form
    {
        public TelaCadastroChapas()
        {
            InitializeComponent();
            cboStatus.SelectedIndex = 0;
            CarregarChapas();
        }

        private void CarregarChapas()
        {
            dgvChapas.DataSource = Database.ListarChapas();

            if (dgvChapas.Columns.Contains("Id"))
            {
                dgvChapas.Columns["Id"].Visible = false;
            }

            if (dgvChapas.Columns.Contains("Numero"))
            {
                dgvChapas.Columns["Numero"].HeaderText = "Número";
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (txtNumero.Text == "" && txtNome.Text == "" && cboStatus.SelectedIndex == 0)
            {
                MessageBox.Show(
                    "Não foi possível limpar os campos, pois eles já estão vazios.",
                    "Campo Já Vazio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                txtNumero.Text = "";
                txtNome.Text = "";
                cboStatus.SelectedIndex = 0;

                txtNumero.Focus();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string numero = txtNumero.Text;
            string nome = txtNome.Text;

            if (numero == "" || nome == "" || cboStatus.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Preencha todos os campos vazios para cadastrar chapas.",
                    "Campo Vazio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );

                return;
            }

            string status = cboStatus.Text.Trim();

            try
            {
                Database.InserirChapa(numero, nome, status);

                MessageBox.Show(
                    "A chapa foi validada com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );

                btnLimpar.PerformClick();
                CarregarChapas();
                
            }
            catch (Microsoft.Data.Sqlite.SqliteException)
            {
                MessageBox.Show(
                    "Já existe uma chapa cadastrada com essas informações.",
                    "Chapa Duplicada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );

                return;
            }
        }
    }
}
