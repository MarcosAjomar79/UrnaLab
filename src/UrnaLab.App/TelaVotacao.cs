using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UrnaLab.App.Data;
using UrnaLab.App.Models;
using UrnaLab.App.Services;
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

            DataGridViewColumn? colunaId = dgvChapas.Columns["Id"];
            DataGridViewColumn? colunaNumero = dgvChapas.Columns["Numero"];
            DataGridViewColumn? colunaNome = dgvChapas.Columns["Nome"];

            if (colunaId is not null)
            {
                colunaId.Visible = false;
            }
            if (colunaNumero is not null)
            {
                colunaNumero.HeaderText = "Número";
            }

            if (colunaNome is not null)
            {
                colunaNome.HeaderText = "Nome da Chapa";
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

            btnConfirmarVoto.Enabled = false;

            if (confirmacao != DialogResult.Yes)
            {
                return;
            }

            ComprovanteVoto comprovante =
                Database.RegistrarVoto(alunoId, chapaId);

            try
            {
                DialogResult escolhaFormato = MessageBox.Show(
                    "Deseja preparar o comprovante no formato de bobina térmica de 80 mm?\n\n" +
                     "Sim: formato térmico.\n" +
                     "Não: formato de folha normal ou PDF.",
                     "Formato do comprovante",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question
            );

                bool formatoTermico = escolhaFormato == DialogResult.Yes;

                ImpressoraComprovante impressora =
                    new ImpressoraComprovante(comprovante, formatoTermico);

                impressora.MostrarPreVisualizacao();
                DialogResult desejaImprimir = MessageBox.Show(
                    "Deseja enviar o comprovante para uma impressora agora?",
                    "Imprimir comprovante",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (desejaImprimir == DialogResult.Yes)
                {
                    impressora.ImprimirComEscolhaDeImpressora();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "O voto foi registrado no banco de dados, mas não foi possível abrir a pré-visualização do comprovante.\n\n" +
                    $"Detalhes: {ex.Message}",
                    "Aviso de impressão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }

            MessageBox.Show(
                $"Voto registrado com sucesso.\n\n" +
                $"Comprovante nº {comprovante.VotoId}\n" +
                $"RA: {comprovante.RaAluno}\n" +
                $"Aluno: {comprovante.NomeAluno}\n" +
                $"Chapa: {comprovante.NumeroChapa} - {comprovante.NomeChapa}",
                "Voto confirmado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        
    }
}
