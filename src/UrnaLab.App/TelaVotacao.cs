using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UrnaLab.App.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UrnaLab.App
{
    public partial class TelaVotacao : Form
    {

        private int alunoId;
        public TelaVotacao()
        {
            InitializeComponent();
        }

        public TelaVotacao(int alunoIdRecebido, string ra, string nome) : this()
        { 
            alunoId = alunoIdRecebido;
            lblNomeAluno.Text = nome;
            lblRaAluno.Text = ra;
            CarregarChapas();

            if (alunoId == 0)
            {
                btnConfirmarVoto.Enabled = false;
            }
            
        }

        private void CarregarChapas()
        {
            dgvChapas.DataSource = Database.ListarChapasAtivas();

            if (dgvChapas.Columns.Contains("Id"))
            {
                dgvChapas.Columns["Id"].Visible = false;
            }

            if (dgvChapas.Columns.Contains("Numero"))
            {
                dgvChapas.Columns["Numero"].HeaderText = "Número";
            }

            if (dgvChapas.Columns.Contains("Nome"))
            {
                dgvChapas.Columns["Nome"].HeaderText = "Nome da Chapa";
            }

            dgvChapas.ClearSelection();
            btnConfirmarVoto.Enabled = true;
        }
        private void TelaVotacao_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmarVoto_Click(object sender, EventArgs e)
        { 
            if (dgvChapas.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Selecione uma chapa antes de confirmar o voto.",
                    "Chapa Não Selecionada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );

                return;

            }
            DataGridViewRow linhaSelecionada = dgvChapas.SelectedRows[0];

            int chapaId = Convert.ToInt32(
                linhaSelecionada.Cells["Id"].Value
            );

            string numeroChapa = linhaSelecionada.Cells["Numero"].Value?.ToString() ?? "";
            string nomeChapa = linhaSelecionada.Cells["Nome"].Value?.ToString() ?? "";

            DialogResult confirmacao = MessageBox.Show(
                $"Confirmar o voto na chapa {numeroChapa} - {nomeChapa}?\n\n" +
                "Esta votação é nominal e o aluno será registrado junto com o voto",
                "Confirmar Voto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacao != DialogResult.Yes)
            {
                return;
            }
            try
            {
                Database.RegistrarVoto(
                    alunoId,
                    chapaId
                );

                MessageBox.Show(
                    "voto registrado com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Voto não registrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível registrar o voto \n\n Detalhes: {ex.Message}",
                    "Erro na Votação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
