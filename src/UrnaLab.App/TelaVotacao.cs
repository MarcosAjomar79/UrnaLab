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

        }
    }
}
