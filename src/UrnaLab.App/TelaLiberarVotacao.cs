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

        private int AlunoIdSelecionado = 0;

        private void LimparDadosAluno()
        {
            AlunoIdSelecionado = 0;

            lblNomeAluno.Text = "Nenhum Aluno Pesquisado";
            lblTurmaAluno.Text = "-";
            lblStatusAluno.Text = "-";
            lblSituacaoVoto.Text = "-";

            btnLiberar.Enabled = false;
        }

        public TelaLiberarVotacao()
        {
            InitializeComponent();
            btnLiberar.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            string ra = txtRa.Text.Trim();

            if (txtRa.Text == "")
            {
                MessageBox.Show(
                    "Não foi possível limpar o Campo, pois ele já está vazio.",
                    "Campo Já Vazio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
            }
            else
            {
                txtRa.Clear();
                LimparDadosAluno();
                txtRa.Focus();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string ra = txtRa.Text.Trim();

            DataTable resultado = Database.BuscarAlunoPorRa(ra);

            if (resultado.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Nenhum Aluno foi encontrado com esse RA/Matrícula.",
                    "Aluno Não Encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DataRow aluno = resultado.Rows[0];

            AlunoIdSelecionado = Convert.ToInt32(aluno["id"]);

            string nome = aluno["Nome"].ToString() ?? "";
            string turma = aluno["Turma"].ToString() ?? "";
            string status = aluno["status"].ToString() ?? "";
            int jaVotou = Convert.ToInt32(aluno["JaVotou"]);

            lblNomeAluno.Text = nome;
            lblTurmaAluno.Text = turma;
            lblStatusAluno.Text = status;

            if (jaVotou == 1)
            {
                lblSituacaoVoto.Text = "Aluno já Votou";
                btnLiberar.Enabled = false;
            }
            else
            {
                lblSituacaoVoto.Text = "O aluno ainda não votou";

                bool alunoAtivo = string.Equals(
                    status,
                    "Ativo",
                    StringComparison.OrdinalIgnoreCase
                );

                btnLiberar.Enabled = alunoAtivo;
            }
        }

        private void btnLiberar_Click(object sender, EventArgs e)
        {
            if (AlunoIdSelecionado == 0)
            {
                MessageBox.Show(
                    "Pesquise e selecione um aluno antes de liberar a votação.",
                    "Aluno Não Selecionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;

            }

            string ra = txtRa.Text.Trim();
            string nome = lblNomeAluno.Text.Trim();

            TelaVotacao telaVotacao = new TelaVotacao(
                AlunoIdSelecionado,
                ra,
                nome
            );

            telaVotacao.ShowDialog();
            LimparDadosAluno();
            txtRa.Focus();

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
