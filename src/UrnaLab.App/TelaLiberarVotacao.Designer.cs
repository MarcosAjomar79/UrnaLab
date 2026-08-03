namespace UrnaLab.App
{
    partial class TelaLiberarVotacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaLiberarVotacao));
            lblTitulo = new Label();
            lblRa = new Label();
            txtRa = new TextBox();
            btnBuscar = new Button();
            grpAluno = new GroupBox();
            lblSituacaoVoto = new Label();
            lblVotoDescricao = new Label();
            lblStatusAluno = new Label();
            lblStatusDescricao = new Label();
            lblTurmaAluno = new Label();
            lblTurmaDescricao = new Label();
            lblNomeAluno = new Label();
            lblNomeDescricao = new Label();
            btnLiberar = new Button();
            btnLimpar = new Button();
            btnVoltar = new Button();
            btnSair = new Button();
            grpAluno.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            lblTitulo.Location = new Point(340, 35);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(219, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Liberar Votação";
            // 
            // lblRa
            // 
            lblRa.AutoSize = true;
            lblRa.Location = new Point(170, 120);
            lblRa.Name = "lblRa";
            lblRa.Size = new Size(80, 15);
            lblRa.TabIndex = 1;
            lblRa.Text = "RA/Matrícula:";
            lblRa.Click += label1_Click;
            // 
            // txtRa
            // 
            txtRa.Location = new Point(290, 115);
            txtRa.MaxLength = 20;
            txtRa.Name = "txtRa";
            txtRa.PlaceholderText = "Digite seu RA/Matrícula:";
            txtRa.Size = new Size(280, 23);
            txtRa.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(590, 111);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(110, 35);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // grpAluno
            // 
            grpAluno.Controls.Add(lblSituacaoVoto);
            grpAluno.Controls.Add(lblVotoDescricao);
            grpAluno.Controls.Add(lblStatusAluno);
            grpAluno.Controls.Add(lblStatusDescricao);
            grpAluno.Controls.Add(lblTurmaAluno);
            grpAluno.Controls.Add(lblTurmaDescricao);
            grpAluno.Controls.Add(lblNomeAluno);
            grpAluno.Controls.Add(lblNomeDescricao);
            grpAluno.Location = new Point(145, 175);
            grpAluno.Name = "grpAluno";
            grpAluno.Size = new Size(610, 210);
            grpAluno.TabIndex = 4;
            grpAluno.TabStop = false;
            grpAluno.Text = "Dados do Aluno";
            // 
            // lblSituacaoVoto
            // 
            lblSituacaoVoto.AutoSize = true;
            lblSituacaoVoto.Font = new Font("Segoe UI", 10F);
            lblSituacaoVoto.Location = new Point(160, 130);
            lblSituacaoVoto.Name = "lblSituacaoVoto";
            lblSituacaoVoto.Size = new Size(15, 19);
            lblSituacaoVoto.TabIndex = 7;
            lblSituacaoVoto.Text = "-";
            // 
            // lblVotoDescricao
            // 
            lblVotoDescricao.AutoSize = true;
            lblVotoDescricao.Font = new Font("Segoe UI", 10F);
            lblVotoDescricao.Location = new Point(35, 130);
            lblVotoDescricao.Name = "lblVotoDescricao";
            lblVotoDescricao.Size = new Size(116, 19);
            lblVotoDescricao.TabIndex = 6;
            lblVotoDescricao.Text = "Situação do Voto:";
            // 
            // lblStatusAluno
            // 
            lblStatusAluno.AutoSize = true;
            lblStatusAluno.Font = new Font("Segoe UI", 10F);
            lblStatusAluno.Location = new Point(430, 85);
            lblStatusAluno.Name = "lblStatusAluno";
            lblStatusAluno.Size = new Size(15, 19);
            lblStatusAluno.TabIndex = 5;
            lblStatusAluno.Text = "-";
            // 
            // lblStatusDescricao
            // 
            lblStatusDescricao.AutoSize = true;
            lblStatusDescricao.Font = new Font("Segoe UI", 10F);
            lblStatusDescricao.Location = new Point(330, 85);
            lblStatusDescricao.Name = "lblStatusDescricao";
            lblStatusDescricao.Size = new Size(50, 19);
            lblStatusDescricao.TabIndex = 4;
            lblStatusDescricao.Text = "Status:";
            // 
            // lblTurmaAluno
            // 
            lblTurmaAluno.AutoSize = true;
            lblTurmaAluno.Font = new Font("Segoe UI", 10F);
            lblTurmaAluno.Location = new Point(160, 85);
            lblTurmaAluno.Name = "lblTurmaAluno";
            lblTurmaAluno.Size = new Size(15, 19);
            lblTurmaAluno.TabIndex = 3;
            lblTurmaAluno.Text = "-";
            // 
            // lblTurmaDescricao
            // 
            lblTurmaDescricao.AutoSize = true;
            lblTurmaDescricao.Font = new Font("Segoe UI", 10F);
            lblTurmaDescricao.Location = new Point(35, 85);
            lblTurmaDescricao.Name = "lblTurmaDescricao";
            lblTurmaDescricao.Size = new Size(51, 19);
            lblTurmaDescricao.TabIndex = 2;
            lblTurmaDescricao.Text = "Turma:";
            // 
            // lblNomeAluno
            // 
            lblNomeAluno.AutoSize = true;
            lblNomeAluno.Font = new Font("Segoe UI", 10F);
            lblNomeAluno.Location = new Point(160, 45);
            lblNomeAluno.Name = "lblNomeAluno";
            lblNomeAluno.Size = new Size(174, 19);
            lblNomeAluno.TabIndex = 1;
            lblNomeAluno.Text = "Nenhum Aluno Pesquisado";
            // 
            // lblNomeDescricao
            // 
            lblNomeDescricao.AutoSize = true;
            lblNomeDescricao.Font = new Font("Segoe UI", 10F);
            lblNomeDescricao.Location = new Point(35, 45);
            lblNomeDescricao.Name = "lblNomeDescricao";
            lblNomeDescricao.Size = new Size(49, 19);
            lblNomeDescricao.TabIndex = 0;
            lblNomeDescricao.Text = "Nome:";
            // 
            // btnLiberar
            // 
            btnLiberar.Enabled = false;
            btnLiberar.Location = new Point(350, 415);
            btnLiberar.Name = "btnLiberar";
            btnLiberar.Size = new Size(200, 45);
            btnLiberar.TabIndex = 5;
            btnLiberar.Text = "Liberar Votação";
            btnLiberar.UseVisualStyleBackColor = true;
            btnLiberar.Click += btnLiberar_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(134, 490);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(130, 38);
            btnLimpar.TabIndex = 6;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(385, 490);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(130, 38);
            btnVoltar.TabIndex = 7;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // btnSair
            // 
            btnSair.Location = new Point(625, 490);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(130, 38);
            btnSair.TabIndex = 8;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // TelaLiberarVotacao
            // 
            AcceptButton = btnBuscar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnVoltar;
            ClientSize = new Size(884, 561);
            Controls.Add(btnSair);
            Controls.Add(btnVoltar);
            Controls.Add(btnLimpar);
            Controls.Add(btnLiberar);
            Controls.Add(grpAluno);
            Controls.Add(btnBuscar);
            Controls.Add(txtRa);
            Controls.Add(lblRa);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "TelaLiberarVotacao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UrnaLab - Liberar Votação";
            grpAluno.ResumeLayout(false);
            grpAluno.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblRa;
        private TextBox txtRa;
        private Button btnBuscar;
        private GroupBox grpAluno;
        private Button btnLiberar;
        private Button btnLimpar;
        private Button btnVoltar;
        private Label lblTurmaDescricao;
        private Label lblNomeAluno;
        private Label lblNomeDescricao;
        private Label lblVotoDescricao;
        private Label lblStatusAluno;
        private Label lblStatusDescricao;
        private Label lblTurmaAluno;
        private Label lblSituacaoVoto;
        private Button btnSair;
    }
}