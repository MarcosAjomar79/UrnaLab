using System.Drawing;
using System.Drawing.Printing;
using System.Collections.Generic;
using System;
using System.Text;
using UrnaLab.App.Models;

namespace UrnaLab.App.Services
{
    public class ImpressoraComprovante
    {
        private readonly ComprovanteVoto comprovante;
        private readonly PrintDocument documento;
        private readonly bool formatoTermico;

        public ImpressoraComprovante(
            ComprovanteVoto comprovante, 
            bool formatoTermico = false
        )
        {
            this.comprovante = comprovante;
            this.formatoTermico = formatoTermico;

            documento = new PrintDocument();
            documento.PrintPage += Documento_PrintPage;

            if (formatoTermico)
            {
                documento.DefaultPageSettings.PaperSize =
            new PaperSize("Bobina 80 mm", 315, 800);

                documento.DefaultPageSettings.Margins =
                    new Margins(10, 10, 10, 10);
            }
        }
        public void MostrarPreVisualizacao()
        {
            using PrintPreviewDialog preVisualizacao = new();

            preVisualizacao.Document = documento;
            preVisualizacao.WindowState = FormWindowState.Maximized;
            preVisualizacao.ShowDialog();
        }

        public void ImprimirComEscolhaDeImpressora()
        {
            using PrintDialog janelaImpressao = new();

            janelaImpressao.Document = documento;

            if (janelaImpressao.ShowDialog()== DialogResult.OK)
            {
                documento.Print();
            }
        }

        private void Documento_PrintPage(object? sender, PrintPageEventArgs e)
        {
            if (e.Graphics is null)
            {
                return;
            }

            using Font fonteTitulo = new Font(
                "Arial",
                formatoTermico ? 10 : 16,
                FontStyle.Bold
            );

            using Font fonteTexto = new Font(
                "Arial",
                formatoTermico ? 8 : 11
            );

            using Font fonteRodape = new Font(
                "Arial",
                formatoTermico ? 7 : 9,
                FontStyle.Italic
            );

            int margemEsquerda = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;

            e.Graphics.DrawString(
                "URNALAB - COMPROVANTE DE VOTO",
                fonteTitulo,
                Brushes.Black,
                margemEsquerda,
                y
            );

            y += 45;

            e.Graphics.DrawString(
              $"Comprovante N°: {comprovante.VotoId}",
              fonteTexto,
              Brushes.Black,
              margemEsquerda,
              y
          );

            y += formatoTermico ? 18 : 25;

            e.Graphics.DrawString(
              $"RA/Matrícula: {comprovante.RaAluno}",
              fonteTexto,
              Brushes.Black,
              margemEsquerda,
              y
          );

            y += formatoTermico ? 18 : 25;

            e.Graphics.DrawString(
              $"Aluno: {comprovante.NomeAluno}",
              fonteTexto,
              Brushes.Black,
              margemEsquerda,
              y
          );

            y += formatoTermico ? 18 : 25;

            e.Graphics.DrawString(
              $"Turma: {comprovante.TurmaAluno}",
              fonteTexto,
              Brushes.Black,
              margemEsquerda,
              y
          );

            y += formatoTermico ? 18 : 25;

            e.Graphics.DrawString(
              $"Data e Hora: {comprovante.DataHora: dd/MM/yyyy HH:mm:ss}",
              fonteTexto,
              Brushes.Black,
              margemEsquerda,
              y
          );

            y += 40;

            e.Graphics.DrawLine(
              Pens.Black,
              margemEsquerda,
              y,
              margemEsquerda + 500,
              y
          );

            y += 15;

            e.Graphics.DrawString(
              "Registro Nominal de votação Escolar.",
              fonteRodape,
              Brushes.Black,
              margemEsquerda,
              y
          );

        }
    };
}
