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
    public partial class TelaLiberarVotacao : Form
    {
        private string numeroDigitadoV11 = "";
        private class AlunoItem
        {
            public int Id { get; set; }
            public string Ra { get; set; } = "";
            public string Nome { get; set; } = "";
            public string Turma { get; set; } = "";
            public string Status { get; set; } = "";
            public bool JaVotou { get; set; }

            public override string ToString()
            {
                return $"{Nome} - RA: {Ra}";
            }
        }
        private bool terminalV11Liberado = false;
        private int chapaIdSelecionadaV11 = 0;
        private string chapaNomeSelecionadaV11 = "";
        private readonly List<AlunoItem> alunosV11 = new();
        private AlunoItem? alunoEmVotacaoV11 = null;

        public TelaLiberarVotacao()
        {

            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += TelaLiberarVotacao_KeyDown;

            terminalV11Liberado = false;

            CarregarAlunosV11();
            LimparDetalhesAlunoV11();

            lstV11Alunos.ClearSelected();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CarregarAlunosV11()
        {
            alunosV11.Clear();
            lstV11Alunos.Items.Clear();

            DataTable tabela = Database.ListarAlunos();

            foreach (DataRow row in tabela.Rows)
            {
                var aluno = new AlunoItem
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Ra = row["Ra"]?.ToString() ?? "",
                    Nome = row["Nome"]?.ToString() ?? "",
                    Turma = row["Turma"]?.ToString() ?? "",
                    Status = row["Status"]?.ToString() ?? "",
                    JaVotou = Convert.ToInt32(row["JaVotou"]) == 1
                };

                alunosV11.Add(aluno);
                lstV11Alunos.Items.Add(aluno);
            }
        }
        private void LimparDetalhesAlunoV11()
        {
            btnV11Corrige.Enabled = false;
            btnV11Confirma.Enabled = false;
            numeroDigitadoV11 = "";

            lblV11NomeAluno.Text = "-";
            lblV11RaAluno.Text = "-";
            lblV11TurmaAluno.Text = "-";
            lblV11StatusAluno.Text = "-";
            lblV11SituacaoAluno.Text = "Selecione um aluno";
            lblV11Chapa.Text = "Aguardando o número...";
            lblV11Numero.Text = "--";
            btnV11LiberarVotacao.Enabled = false;
            terminalV11Liberado = false;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show(
                "Deseja realmente sair do UrnaLab?",
                "Confirmar Saída",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lstV11Alunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstV11Alunos.SelectedItem is not AlunoItem aluno)
                return;

            lblV11NomeAluno.Text = aluno.Nome;
            lblV11RaAluno.Text = aluno.Ra;
            lblV11TurmaAluno.Text = aluno.Turma;
            lblV11StatusAluno.Text = aluno.Status;

            bool alunoAtivo =
                string.Equals(
                    aluno.Status.Trim(),
                    "Ativo",
                    StringComparison.OrdinalIgnoreCase);

            if (!alunoAtivo)
            {
                lblV11SituacaoAluno.Text = "Aluno inativo";
                btnV11LiberarVotacao.Enabled = false;
                lblV11Chapa.Text = "Indisponível";
                lblV11Numero.Text = "--";
                return;
            }

            if (aluno.JaVotou)
            {
                lblV11SituacaoAluno.Text = "Aluno já votou";
                btnV11LiberarVotacao.Enabled = false;
                lblV11Chapa.Text = "Votação encerrada";
                lblV11Numero.Text = "--";
                return;
            }
            lblV11SituacaoAluno.Text = "Aluno apto para votar";

            lblV11Chapa.Text = "Aguardando votação...";
            lblV11Numero.Text = "--";

            btnV11LiberarVotacao.Enabled = true;

        }

        private void txtV11BuscarAluno_TextChanged(object sender, EventArgs e)
        {
            string busca = txtV11BuscarAluno.Text.Trim();

            lstV11Alunos.Items.Clear();

            IEnumerable<AlunoItem> filtrados = alunosV11;

            if (!string.IsNullOrWhiteSpace(busca))
            {
                filtrados = alunosV11.Where(aluno =>
                    aluno.Nome.Contains(
                        busca,
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    aluno.Ra.Contains(
                        busca,
                        StringComparison.OrdinalIgnoreCase));
            }

            foreach (AlunoItem aluno in filtrados)
            {
                lstV11Alunos.Items.Add(aluno);
            }
        }

        private void btnV11LiberarVotacao_Click(object sender, EventArgs e)
        {
            if (lstV11Alunos.SelectedItem is not AlunoItem aluno)
            {
                MessageBox.Show(
                    "Selecione um aluno antes de liberar a votação.",
                    "Aluno Não Selecionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            bool alunoAtivo = string.Equals(
                aluno.Status.Trim(),
                "Ativo",
                StringComparison.OrdinalIgnoreCase
            );

            if (!alunoAtivo)
            {
                MessageBox.Show(
                    "Este aluno está inativo e não pode votar.",
                    "Votação Não Permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (aluno.JaVotou)
            {
                MessageBox.Show(
                    "Este aluno já registrou seu voto.",
                    "Voto Já Registrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }
            alunoEmVotacaoV11 = aluno;
            terminalV11Liberado = true;
            btnV11Corrige.Enabled = true;
            btnV11Confirma.Enabled = true;
            numeroDigitadoV11 = "";

            lblV11Chapa.Text = "Digite o número da chapa";
            lblV11Numero.Text = "--";

            lblV11SituacaoAluno.Text = "Votação liberada";

            btnV11LiberarVotacao.Enabled = false;

            txtV11BuscarAluno.Enabled = false;


            btnVoltar.Enabled = true;
            btnSair.Enabled = true;
        }

        private void lblV11SituacaoAluno_Click(object sender, EventArgs e)
        {
            if (lstV11Alunos.SelectedItem is not AlunoItem aluno)
            {
                LimparDetalhesAlunoV11();
                return;
            }

            lblV11NomeAluno.Text = aluno.Nome;
            lblV11RaAluno.Text = aluno.Ra;
            lblV11TurmaAluno.Text = aluno.Turma;
            lblV11StatusAluno.Text = aluno.Status;

            bool alunoAtivo = string.Equals(
                aluno.Status.Trim(),
                "Ativo",
                StringComparison.OrdinalIgnoreCase
            );

            if (!alunoAtivo)
            {
                lblV11SituacaoAluno.Text = "Aluno inativo";
                btnV11LiberarVotacao.Enabled = false;
                return;
            }

            if (aluno.JaVotou)
            {
                lblV11SituacaoAluno.Text = "Aluno já votou";
                btnV11LiberarVotacao.Enabled = false;
                return;
            }

            lblV11SituacaoAluno.Text = "Aluno apto para votar";
            btnV11LiberarVotacao.Enabled = true;
        }

        private void TelaLiberarVotacao_KeyDown(object sender, KeyEventArgs e)
        {
            // O teclado só funciona depois que o mesário libera a votação.
            if (!terminalV11Liberado)
                return;

            // Números da parte superior do teclado: 0 até 9.
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                // Impede digitar mais de 2 números.
                if (numeroDigitadoV11.Length >= 3)
                    return;

                string numero =
                    ((int)e.KeyCode - (int)Keys.D0).ToString();

                numeroDigitadoV11 += numero;

                AtualizarChapaDigitadaV11();

                e.Handled = true;
                return;
            }

            // Números do teclado numérico: 0 até 9.
            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                // Impede digitar mais de 2 números.
                if (numeroDigitadoV11.Length >= 2)
                    return;

                string numero =
                    ((int)e.KeyCode - (int)Keys.NumPad0).ToString();

                numeroDigitadoV11 += numero;

                AtualizarChapaDigitadaV11();

                e.Handled = true;
                return;
            }

            // Backspace apaga o último número digitado.
            if (e.KeyCode == Keys.Back)
            {
                numeroDigitadoV11 = "";

                chapaIdSelecionadaV11 = 0;
                chapaNomeSelecionadaV11 = "";

                lblV11Numero.Text = "--";
                lblV11Chapa.Text = "Digite o número da chapa";

                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                ConfirmarVotoV11();

                e.Handled = true;
                return;
            }
        }

        private void AtualizarChapaDigitadaV11()
        {
            chapaIdSelecionadaV11 = 0;
            chapaNomeSelecionadaV11 = "";

            if (string.IsNullOrWhiteSpace(numeroDigitadoV11))
            {
                lblV11Numero.Text = "--";
                lblV11Chapa.Text = "Digite o número da chapa";
                return;
            }

            lblV11Numero.Text = numeroDigitadoV11;

            DataTable resultado =
                Database.BuscarChapaAtivaPorNumero(numeroDigitadoV11);

            if (resultado.Rows.Count == 0)
            {
                lblV11Chapa.Text = "Chapa não encontrada";
                return;
            }

            DataRow chapa = resultado.Rows[0];

            chapaIdSelecionadaV11 =
                Convert.ToInt32(chapa["Id"]);

            chapaNomeSelecionadaV11 =
                chapa["Nome"]?.ToString() ?? "";

            lblV11Chapa.Text = chapaNomeSelecionadaV11;
        }

        private void ConfirmarVotoV11()
        {
            if (!terminalV11Liberado)
                return;

            if (alunoEmVotacaoV11 is null)
            {
                MessageBox.Show(
                    "Nenhum aluno possui votação liberada.",
                    "UrnaLab",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            AlunoItem aluno = alunoEmVotacaoV11;

            if (string.IsNullOrWhiteSpace(numeroDigitadoV11))
            {
                MessageBox.Show(
                    "Digite o número de uma chapa antes de confirmar.",
                    "UrnaLab",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (chapaIdSelecionadaV11 <= 0)
            {
                MessageBox.Show(
                    "A chapa digitada não existe ou não está ativa.",
                    "Chapa Inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult resposta = MessageBox.Show(
                $"Confirmar voto na chapa {numeroDigitadoV11} - {chapaNomeSelecionadaV11}?",
                "Confirmar Voto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta != DialogResult.Yes)
                return;

            Database.RegistrarVoto(
                aluno.Id,
                chapaIdSelecionadaV11
            );

            MessageBox.Show(
                "Voto registrado com sucesso.",
                "UrnaLab",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            FinalizarVotacaoV11();
        }

        private void FinalizarVotacaoV11()
        {

            terminalV11Liberado = false;

            numeroDigitadoV11 = "";
            chapaIdSelecionadaV11 = 0;
            chapaNomeSelecionadaV11 = "";

            CarregarAlunosV11();

            txtV11BuscarAluno.Clear();
            txtV11BuscarAluno.Enabled = true;

            lstV11Alunos.Enabled = true;
            lstV11Alunos.ClearSelected();

            LimparDetalhesAlunoV11();

            lblV11Chapa.Text = "Aguardando o número...";
            lblV11Numero.Text = "--";

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (terminalV11Liberado)
            {
                if (keyData == Keys.Escape)
                {
                    CorrigirVotoV11();
                    return true;
                }

                if (keyData == Keys.Enter)
                {
                    ConfirmarVotoV11();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CorrigirVotoV11()
        {
            if (!terminalV11Liberado)
                return;

            numeroDigitadoV11 = "";

            chapaIdSelecionadaV11 = 0;
            chapaNomeSelecionadaV11 = "";

            lblV11Numero.Text = "--";
            lblV11Chapa.Text = "Digite o número da chapa";
        }

        private void btnV11Corrige_Click(object sender, EventArgs e)
        {
            CorrigirVotoV11();
        }

        private void btnV11Confirma_Click(object sender, EventArgs e)
        {
            ConfirmarVotoV11();
        }

        private void TelaLiberarVotacao_Load(object sender, EventArgs e)
        {

        }

        private void pnlTerminalV11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitPrincipal_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}