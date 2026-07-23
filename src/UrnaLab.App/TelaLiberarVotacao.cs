using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UrnaLab.App
{
    public partial class TelaLiberarVotacao : Form
    {
        public TelaLiberarVotacao()
        {
            InitializeComponent();
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
            txtRa.Text = "";

            txtRa.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string ra = txtRa.Text.Trim();

            if (ra == "")
            {
                MessageBox.Show(
                    "É Obrigatório preencher este campo para busca do aluno.",
                    "Campo Vazio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }
        }

        private void btnLiberar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
