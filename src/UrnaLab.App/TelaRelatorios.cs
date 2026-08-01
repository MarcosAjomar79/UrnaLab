using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UrnaLab.App.Data;
using UrnaLab.App.Services;

namespace UrnaLab.App
{
    public partial class TelaRelatorios : Form
    {
        public TelaRelatorios()
        {
            InitializeComponent();
            CarregarVotos();
        }

        private void CarregarVotos()
        {
            try
            {
                dgvVotos.DataSource = Database.ListarVotosNominais();

                if (dgvVotos.Columns.Contains("VotoId"))
                {
                    dgvVotos.Columns["VotoId"].Visible = false;
                }

                if (dgvVotos.Columns.Contains("RaAluno"))
                {
                    dgvVotos.Columns["RaAluno"].HeaderText = "RA/Matrícula";
                }

                if (dgvVotos.Columns.Contains("Aluno"))
                {
                    dgvVotos.Columns["Aluno"].HeaderText = "Aluno";
                }

                if (dgvVotos.Columns.Contains("Turma"))
                {
                    dgvVotos.Columns["Turma"].HeaderText = "Turma";
                }

                if (dgvVotos.Columns.Contains("NumeroChapa"))
                {
                    dgvVotos.Columns["NumeroChapa"].HeaderText = "Número da Chapa";
                }

                if (dgvVotos.Columns.Contains("Chapa"))
                {
                    dgvVotos.Columns["Chapa"].HeaderText = "Nome da Chapa";
                }

                if (dgvVotos.Columns.Contains("DataHora"))
                {
                    dgvVotos.Columns["DataHora"].HeaderText = "Data e Hora";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível carregar os votos.\n\nDetalhes: {ex.Message}",
                    "Erro ao Carregar Relatório",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarVotos();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                var votos = Database.ListarVotosNominais();

                if (votos.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Não há votos registrados para exportar.",
                        "Exportação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;

                }
                string pastaExportacoes = Path.Combine(
                    AppContext.BaseDirectory,
                    "exports"
                );

                Directory.CreateDirectory(pastaExportacoes);

                using SaveFileDialog janelaSalvar = new SaveFileDialog();

                janelaSalvar.Title = "Salvar Relatório Nominal dos Votos";
                janelaSalvar.Filter = "Arquivo de Texto (*txt) | *.txt";
                janelaSalvar.FileName = $"relatorio-votos-{DateTime.Now: yyyyMMdd--HHmmss}.txt";
                janelaSalvar.InitialDirectory = pastaExportacoes;

                if (janelaSalvar.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                ExportadorRelatorio.ExportarVotosNominais(
                    votos,
                    janelaSalvar.FileName
                );

                MessageBox.Show(
                    $"Relatório Exportado com Sucesso.\n\n Arquivo: \n{janelaSalvar.FileName}",
                    "Exportação Concluída",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível exportar o relatório. \n\n Detalhes: {ex.Message}",
                    "Erro na Exportação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private int indiceVotoImpressao = 0;

        private void docRelatorio_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var votos = Database.ListarVotosNominais();

            int x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            int largura = e.MarginBounds.Width;

            using Font fonteTitulo = new Font("Segoe UI", 16, FontStyle.Bold
            );

            using Font fonteCabecalho = new Font("Segoe UI", 10, FontStyle.Bold
            );

            using Font fonteTexto = new Font("Segoe UI", 10
            );

            e.Graphics.DrawString(
                "URNALAB - RELATÓRIO NOMINAL DE VOTOS",
                fonteTitulo,
                Brushes.Black,
                x,
                y
            );

            y += 45;

            e.Graphics.DrawString(
               $"Gerado em: {DateTime.Now: dd/MM/yyyy HH:mm:ss}",
               fonteTitulo,
               Brushes.Black,
               x,
               y
           );

            y += 40;

            e.Graphics.DrawString(
               $"Total de Votos Registrados: {votos.Rows.Count}",
               fonteTitulo,
               Brushes.Black,
               x,
               y
           );

            y += 40;

            while (indiceVotoImpressao < votos.Rows.Count)
            {
                var voto = votos.Rows[indiceVotoImpressao];

                string linha1 = $"RA: {voto["RaAluno"]} | Aluno: {voto["Aluno"]}";

                string linha2 =
                    $"Turma: {voto["Turma"]} | " +
                    $"Chapa: {voto["NumeroChapa"]} - {voto["Chapa"]}";

                string linha3 = $"Data e Hora: {voto["DataHora"]}";

                float alturaLinha1 = e.Graphics.MeasureString(
                    linha1,
                    fonteTexto,
                    largura
                ).Height;

                float alturaLinha2 = e.Graphics.MeasureString(
                    linha2,
                    fonteTexto,
                    largura
                ).Height;

                float alturaLinha3 = e.Graphics.MeasureString(
                    linha3,
                    fonteTexto,
                    largura
                ).Height;

                float alturaRegistro =
                    alturaLinha1 +
                    alturaLinha2 +
                    alturaLinha3 +
                    25;


                if (y + alturaRegistro > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                e.Graphics.DrawString(
                    linha1,
                    fonteCabecalho,
                    Brushes.Black,
                    new RectangleF(x, y, largura, alturaLinha1)
                );

                y += alturaLinha1;

                e.Graphics.DrawString(
                    linha2,
                    fonteTexto,
                    Brushes.Black,
                    new RectangleF(x, y, largura, alturaLinha2)
                );
                y += alturaLinha2;

                e.Graphics.DrawString(
                    linha3,
                    fonteTexto,
                    Brushes.Black,
                    new RectangleF(x, y, largura, alturaLinha3)
                );
                y += alturaLinha3 + 15;

                e.Graphics.DrawLine(
                    Pens.Gray,
                    x,
                    y,
                    x + largura,
                    y
                );

                y += 10;
                indiceVotoImpressao++;
            }

            e.HasMorePages = false;
        }
        private void dlgPreVisualizacao_Load(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var votos = Database.ListarVotosNominais();

            if (votos.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Não há votos registrados para imprimir",
                    "Impressão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;

            }

            indiceVotoImpressao = 0;

            
            dlgPreVisualizacao.ShowDialog();
        }

        private void docRelatorio_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indiceVotoImpressao = 0;
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
