namespace UrnaLab.App
{
    partial class TelaVotacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            grpAluno = new GroupBox();
            lblRaAluno = new Label();
            lblRaDescricao = new Label();
            lblNomeAluno = new Label();
            lblAlunoDescricao = new Label();
            grpChapas = new GroupBox();
            dgvChapas = new DataGridView();
            lblAviso = new Label();
            btnConfirmarVoto = new Button();
            btnCancelar = new Button();
            grpAluno.SuspendLayout();
            grpChapas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChapas).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            lblTitulo.Location = new Point(390, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(121, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Votação";
            // 
            // grpAluno
            // 
            grpAluno.Controls.Add(lblRaAluno);
            grpAluno.Controls.Add(lblRaDescricao);
            grpAluno.Controls.Add(lblNomeAluno);
            grpAluno.Controls.Add(lblAlunoDescricao);
            grpAluno.Location = new Point(100, 85);
            grpAluno.Name = "grpAluno";
            grpAluno.Size = new Size(700, 90);
            grpAluno.TabIndex = 1;
            grpAluno.TabStop = false;
            grpAluno.Text = "Aluno Liberado";
            // 
            // lblRaAluno
            // 
            lblRaAluno.AutoSize = true;
            lblRaAluno.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRaAluno.Location = new Point(530, 38);
            lblRaAluno.Name = "lblRaAluno";
            lblRaAluno.Size = new Size(12, 15);
            lblRaAluno.TabIndex = 3;
            lblRaAluno.Text = "-";
            // 
            // lblRaDescricao
            // 
            lblRaDescricao.AutoSize = true;
            lblRaDescricao.Location = new Point(425, 38);
            lblRaDescricao.Name = "lblRaDescricao";
            lblRaDescricao.Size = new Size(80, 15);
            lblRaDescricao.TabIndex = 2;
            lblRaDescricao.Text = "RA/Matrícula:";
            // 
            // lblNomeAluno
            // 
            lblNomeAluno.AutoSize = true;
            lblNomeAluno.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNomeAluno.Location = new Point(90, 38);
            lblNomeAluno.Name = "lblNomeAluno";
            lblNomeAluno.Size = new Size(12, 15);
            lblNomeAluno.TabIndex = 1;
            lblNomeAluno.Text = "-";
            // 
            // lblAlunoDescricao
            // 
            lblAlunoDescricao.AutoSize = true;
            lblAlunoDescricao.Location = new Point(25, 38);
            lblAlunoDescricao.Name = "lblAlunoDescricao";
            lblAlunoDescricao.Size = new Size(42, 15);
            lblAlunoDescricao.TabIndex = 0;
            lblAlunoDescricao.Text = "Aluno:";
            // 
            // grpChapas
            // 
            grpChapas.Controls.Add(dgvChapas);
            grpChapas.Location = new Point(100, 195);
            grpChapas.Name = "grpChapas";
            grpChapas.Size = new Size(700, 245);
            grpChapas.TabIndex = 2;
            grpChapas.TabStop = false;
            grpChapas.Text = "Escolha uma Chapa";
            // 
            // dgvChapas
            // 
            dgvChapas.AllowUserToAddRows = false;
            dgvChapas.AllowUserToDeleteRows = false;
            dgvChapas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChapas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChapas.Location = new Point(20, 35);
            dgvChapas.MultiSelect = false;
            dgvChapas.Name = "dgvChapas";
            dgvChapas.ReadOnly = true;
            dgvChapas.RowHeadersVisible = false;
            dgvChapas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dgvChapas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChapas.Size = new Size(660, 185);
            dgvChapas.TabIndex = 0;
            // 
            // lblAviso
            // 
            lblAviso.AutoSize = true;
            lblAviso.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic);
            lblAviso.ForeColor = Color.DarkRed;
            lblAviso.Location = new Point(205, 455);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(374, 17);
            lblAviso.TabIndex = 3;
            lblAviso.Text = "Votação Nominal: O aluno e a chapa escolhida serão registrados.";
            // 
            // btnConfirmarVoto
            // 
            btnConfirmarVoto.Location = new Point(270, 495);
            btnConfirmarVoto.Name = "btnConfirmarVoto";
            btnConfirmarVoto.Size = new Size(200, 45);
            btnConfirmarVoto.TabIndex = 4;
            btnConfirmarVoto.Text = "Confirmar Voto";
            btnConfirmarVoto.UseVisualStyleBackColor = true;
            btnConfirmarVoto.Click += btnConfirmarVoto_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(490, 495);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 45);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // TelaVotacao
            // 
            AcceptButton = btnConfirmarVoto;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(884, 561);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmarVoto);
            Controls.Add(lblAviso);
            Controls.Add(grpChapas);
            Controls.Add(grpAluno);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "TelaVotacao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UrnaLab - Votação";
            Load += TelaVotacao_Load;
            grpAluno.ResumeLayout(false);
            grpAluno.PerformLayout();
            grpChapas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChapas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private GroupBox grpAluno;
        private GroupBox grpChapas;
        private Label lblAviso;
        private Button btnConfirmarVoto;
        private Button btnCancelar;
        private Label lblRaDescricao;
        private Label lblNomeAluno;
        private Label lblAlunoDescricao;
        private Label lblRaAluno;
        private DataGridView dgvChapas;
    }
}