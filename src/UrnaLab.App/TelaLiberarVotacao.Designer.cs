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
            Panel pnlTerminalV11;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaLiberarVotacao));
            lblV11SituacaoAluno = new Label();
            pnlCorpoTerminalV11 = new Panel();
            pnlVisorV11 = new Panel();
            lblV11Numero = new Label();
            lblNumeroTituloV11 = new Label();
            lblV11Chapa = new Label();
            lblRotuloChapaV11 = new Label();
            pnlLinhaVisorV11 = new Panel();
            lblTituloVisorV11 = new Label();
            btnVoltar = new Button();
            splitPrincipal = new SplitContainer();
            btnV11Corrige = new Button();
            btnV11Confirma = new Button();
            btnV11LiberarVotacao = new Button();
            grpDetalhesAluno = new GroupBox();
            lblV11StatusAluno = new Label();
            lblStatusDetalhe = new Label();
            lblV11TurmaAluno = new Label();
            lblTurmaTitulo = new Label();
            lblV11RaAluno = new Label();
            lblRaTitulo = new Label();
            lblV11NomeAluno = new Label();
            lblNomeTitulo = new Label();
            lstV11Alunos = new ListBox();
            txtV11BuscarAluno = new TextBox();
            lblSelecionarAluno = new Label();
            pnlCadastroLiberacao = new Panel();
            lblCabecalhoLiberacao = new Label();
            btnSair = new Button();
            lblTituloTerminalV11 = new Label();
            pnlTerminalV11 = new Panel();
            pnlTerminalV11.SuspendLayout();
            pnlCorpoTerminalV11.SuspendLayout();
            pnlVisorV11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitPrincipal).BeginInit();
            splitPrincipal.Panel1.SuspendLayout();
            splitPrincipal.Panel2.SuspendLayout();
            splitPrincipal.SuspendLayout();
            grpDetalhesAluno.SuspendLayout();
            pnlCadastroLiberacao.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTerminalV11
            // 
            pnlTerminalV11.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlTerminalV11.BorderStyle = BorderStyle.FixedSingle;
            pnlTerminalV11.Controls.Add(lblV11SituacaoAluno);
            pnlTerminalV11.Controls.Add(pnlCorpoTerminalV11);
            pnlTerminalV11.Location = new Point(3, 84);
            pnlTerminalV11.Name = "pnlTerminalV11";
            pnlTerminalV11.Size = new Size(467, 672);
            pnlTerminalV11.TabIndex = 1;
            pnlTerminalV11.Paint += pnlTerminalV11_Paint;
            // 
            // lblV11SituacaoAluno
            // 
            lblV11SituacaoAluno.FlatStyle = FlatStyle.System;
            lblV11SituacaoAluno.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblV11SituacaoAluno.ForeColor = Color.Red;
            lblV11SituacaoAluno.Location = new Point(6, 14);
            lblV11SituacaoAluno.Name = "lblV11SituacaoAluno";
            lblV11SituacaoAluno.Size = new Size(289, 40);
            lblV11SituacaoAluno.TabIndex = 9;
            lblV11SituacaoAluno.Text = "Selecione um aluno";
            lblV11SituacaoAluno.Click += lblV11SituacaoAluno_Click;
            // 
            // pnlCorpoTerminalV11
            // 
            pnlCorpoTerminalV11.Anchor = AnchorStyles.Top;
            pnlCorpoTerminalV11.BackColor = Color.Gainsboro;
            pnlCorpoTerminalV11.BorderStyle = BorderStyle.FixedSingle;
            pnlCorpoTerminalV11.Controls.Add(pnlVisorV11);
            pnlCorpoTerminalV11.Location = new Point(-2, 72);
            pnlCorpoTerminalV11.Name = "pnlCorpoTerminalV11";
            pnlCorpoTerminalV11.Size = new Size(469, 613);
            pnlCorpoTerminalV11.TabIndex = 0;
            // 
            // pnlVisorV11
            // 
            pnlVisorV11.Anchor = AnchorStyles.Top;
            pnlVisorV11.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlVisorV11.BackColor = Color.AliceBlue;
            pnlVisorV11.BorderStyle = BorderStyle.Fixed3D;
            pnlVisorV11.Controls.Add(lblV11Numero);
            pnlVisorV11.Controls.Add(lblNumeroTituloV11);
            pnlVisorV11.Controls.Add(lblV11Chapa);
            pnlVisorV11.Controls.Add(lblRotuloChapaV11);
            pnlVisorV11.Controls.Add(pnlLinhaVisorV11);
            pnlVisorV11.Controls.Add(lblTituloVisorV11);
            pnlVisorV11.Location = new Point(25, 59);
            pnlVisorV11.Name = "pnlVisorV11";
            pnlVisorV11.Size = new Size(390, 474);
            pnlVisorV11.TabIndex = 0;
            // 
            // lblV11Numero
            // 
            lblV11Numero.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblV11Numero.BackColor = Color.Transparent;
            lblV11Numero.Font = new Font("Segoe UI", 60F, FontStyle.Bold);
            lblV11Numero.ForeColor = Color.Black;
            lblV11Numero.Location = new Point(25, 196);
            lblV11Numero.Name = "lblV11Numero";
            lblV11Numero.Size = new Size(340, 100);
            lblV11Numero.TabIndex = 5;
            lblV11Numero.Text = "--";
            lblV11Numero.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNumeroTituloV11
            // 
            lblNumeroTituloV11.AutoSize = true;
            lblNumeroTituloV11.BackColor = Color.Transparent;
            lblNumeroTituloV11.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNumeroTituloV11.ForeColor = Color.Navy;
            lblNumeroTituloV11.Location = new Point(25, 150);
            lblNumeroTituloV11.Name = "lblNumeroTituloV11";
            lblNumeroTituloV11.Size = new Size(68, 19);
            lblNumeroTituloV11.TabIndex = 4;
            lblNumeroTituloV11.Text = "Número:";
            // 
            // lblV11Chapa
            // 
            lblV11Chapa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblV11Chapa.BackColor = Color.Transparent;
            lblV11Chapa.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblV11Chapa.ForeColor = Color.Black;
            lblV11Chapa.Location = new Point(25, 108);
            lblV11Chapa.Name = "lblV11Chapa";
            lblV11Chapa.Size = new Size(340, 30);
            lblV11Chapa.TabIndex = 3;
            lblV11Chapa.Text = "Aguardando o número...";
            lblV11Chapa.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRotuloChapaV11
            // 
            lblRotuloChapaV11.AutoSize = true;
            lblRotuloChapaV11.BackColor = Color.Transparent;
            lblRotuloChapaV11.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRotuloChapaV11.ForeColor = Color.DarkBlue;
            lblRotuloChapaV11.Location = new Point(25, 85);
            lblRotuloChapaV11.Name = "lblRotuloChapaV11";
            lblRotuloChapaV11.Size = new Size(55, 19);
            lblRotuloChapaV11.TabIndex = 2;
            lblRotuloChapaV11.Text = "Chapa:";
            // 
            // pnlLinhaVisorV11
            // 
            pnlLinhaVisorV11.Anchor = AnchorStyles.Top;
            pnlLinhaVisorV11.Location = new Point(25, 57);
            pnlLinhaVisorV11.Name = "pnlLinhaVisorV11";
            pnlLinhaVisorV11.Size = new Size(317, 10);
            pnlLinhaVisorV11.TabIndex = 1;
            pnlLinhaVisorV11.Visible = false;
            // 
            // lblTituloVisorV11
            // 
            lblTituloVisorV11.AutoSize = true;
            lblTituloVisorV11.BackColor = Color.Transparent;
            lblTituloVisorV11.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTituloVisorV11.ForeColor = Color.Navy;
            lblTituloVisorV11.Location = new Point(53, 24);
            lblTituloVisorV11.Name = "lblTituloVisorV11";
            lblTituloVisorV11.Size = new Size(217, 30);
            lblTituloVisorV11.TabIndex = 0;
            lblTituloVisorV11.Text = "VOTAÇÃO ESCOLAR";
            // 
            // btnVoltar
            // 
            btnVoltar.Anchor = AnchorStyles.Top;
            btnVoltar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVoltar.Location = new Point(612, 713);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(130, 43);
            btnVoltar.TabIndex = 7;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // splitPrincipal
            // 
            splitPrincipal.BorderStyle = BorderStyle.FixedSingle;
            splitPrincipal.FixedPanel = FixedPanel.Panel1;
            splitPrincipal.IsSplitterFixed = true;
            splitPrincipal.Location = new Point(0, 0);
            splitPrincipal.MinimumSize = new Size(1300, 600);
            splitPrincipal.Name = "splitPrincipal";
            // 
            // splitPrincipal.Panel1
            // 
            splitPrincipal.Panel1.Controls.Add(btnV11Corrige);
            splitPrincipal.Panel1.Controls.Add(btnV11Confirma);
            splitPrincipal.Panel1.Controls.Add(btnV11LiberarVotacao);
            splitPrincipal.Panel1.Controls.Add(grpDetalhesAluno);
            splitPrincipal.Panel1.Controls.Add(lstV11Alunos);
            splitPrincipal.Panel1.Controls.Add(txtV11BuscarAluno);
            splitPrincipal.Panel1.Controls.Add(lblSelecionarAluno);
            splitPrincipal.Panel1.Controls.Add(pnlCadastroLiberacao);
            // 
            // splitPrincipal.Panel2
            // 
            splitPrincipal.Panel2.AutoScroll = true;
            splitPrincipal.Panel2.Controls.Add(pnlTerminalV11);
            splitPrincipal.Panel2.Controls.Add(btnVoltar);
            splitPrincipal.Panel2.Controls.Add(btnSair);
            splitPrincipal.Panel2.Controls.Add(lblTituloTerminalV11);
            splitPrincipal.Panel2.Paint += splitPrincipal_Panel2_Paint;
            splitPrincipal.Size = new Size(1590, 900);
            splitPrincipal.SplitterDistance = 500;
            splitPrincipal.SplitterWidth = 12;
            splitPrincipal.TabIndex = 9;
            // 
            // btnV11Corrige
            // 
            btnV11Corrige.Location = new Point(26, 698);
            btnV11Corrige.Name = "btnV11Corrige";
            btnV11Corrige.Size = new Size(130, 43);
            btnV11Corrige.TabIndex = 10;
            btnV11Corrige.Text = "Corrige";
            btnV11Corrige.UseVisualStyleBackColor = true;
            btnV11Corrige.Click += btnV11Corrige_Click;
            // 
            // btnV11Confirma
            // 
            btnV11Confirma.Location = new Point(330, 698);
            btnV11Confirma.Name = "btnV11Confirma";
            btnV11Confirma.Size = new Size(130, 43);
            btnV11Confirma.TabIndex = 9;
            btnV11Confirma.Text = "Confirma";
            btnV11Confirma.UseVisualStyleBackColor = true;
            btnV11Confirma.Click += btnV11Confirma_Click;
            // 
            // btnV11LiberarVotacao
            // 
            btnV11LiberarVotacao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnV11LiberarVotacao.BackColor = Color.ForestGreen;
            btnV11LiberarVotacao.FlatStyle = FlatStyle.Flat;
            btnV11LiberarVotacao.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnV11LiberarVotacao.ForeColor = Color.White;
            btnV11LiberarVotacao.Location = new Point(25, 610);
            btnV11LiberarVotacao.Name = "btnV11LiberarVotacao";
            btnV11LiberarVotacao.Size = new Size(450, 55);
            btnV11LiberarVotacao.TabIndex = 8;
            btnV11LiberarVotacao.Text = "LIBERAR VOTAÇÃO";
            btnV11LiberarVotacao.UseVisualStyleBackColor = false;
            btnV11LiberarVotacao.Click += btnV11LiberarVotacao_Click;
            // 
            // grpDetalhesAluno
            // 
            grpDetalhesAluno.Anchor = AnchorStyles.Top;
            grpDetalhesAluno.Controls.Add(lblV11StatusAluno);
            grpDetalhesAluno.Controls.Add(lblStatusDetalhe);
            grpDetalhesAluno.Controls.Add(lblV11TurmaAluno);
            grpDetalhesAluno.Controls.Add(lblTurmaTitulo);
            grpDetalhesAluno.Controls.Add(lblV11RaAluno);
            grpDetalhesAluno.Controls.Add(lblRaTitulo);
            grpDetalhesAluno.Controls.Add(lblV11NomeAluno);
            grpDetalhesAluno.Controls.Add(lblNomeTitulo);
            grpDetalhesAluno.Location = new Point(315, 200);
            grpDetalhesAluno.Name = "grpDetalhesAluno";
            grpDetalhesAluno.Size = new Size(180, 390);
            grpDetalhesAluno.TabIndex = 4;
            grpDetalhesAluno.TabStop = false;
            grpDetalhesAluno.Text = "Detalhes do Aluno";
            // 
            // lblV11StatusAluno
            // 
            lblV11StatusAluno.AutoSize = true;
            lblV11StatusAluno.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblV11StatusAluno.Location = new Point(15, 260);
            lblV11StatusAluno.MinimumSize = new Size(150, 30);
            lblV11StatusAluno.Name = "lblV11StatusAluno";
            lblV11StatusAluno.Size = new Size(150, 30);
            lblV11StatusAluno.TabIndex = 7;
            lblV11StatusAluno.Text = "-";
            // 
            // lblStatusDetalhe
            // 
            lblStatusDetalhe.AutoSize = true;
            lblStatusDetalhe.Font = new Font("Segoe UI", 9F);
            lblStatusDetalhe.Location = new Point(15, 235);
            lblStatusDetalhe.Name = "lblStatusDetalhe";
            lblStatusDetalhe.Size = new Size(42, 15);
            lblStatusDetalhe.TabIndex = 6;
            lblStatusDetalhe.Text = "Status:";
            // 
            // lblV11TurmaAluno
            // 
            lblV11TurmaAluno.AutoSize = true;
            lblV11TurmaAluno.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblV11TurmaAluno.Location = new Point(15, 195);
            lblV11TurmaAluno.MinimumSize = new Size(150, 30);
            lblV11TurmaAluno.Name = "lblV11TurmaAluno";
            lblV11TurmaAluno.Size = new Size(150, 30);
            lblV11TurmaAluno.TabIndex = 5;
            lblV11TurmaAluno.Text = "-";
            // 
            // lblTurmaTitulo
            // 
            lblTurmaTitulo.AutoSize = true;
            lblTurmaTitulo.Font = new Font("Segoe UI", 9F);
            lblTurmaTitulo.Location = new Point(15, 170);
            lblTurmaTitulo.Name = "lblTurmaTitulo";
            lblTurmaTitulo.Size = new Size(44, 15);
            lblTurmaTitulo.TabIndex = 4;
            lblTurmaTitulo.Text = "Turma:";
            // 
            // lblV11RaAluno
            // 
            lblV11RaAluno.AutoSize = true;
            lblV11RaAluno.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblV11RaAluno.Location = new Point(15, 130);
            lblV11RaAluno.MinimumSize = new Size(150, 30);
            lblV11RaAluno.Name = "lblV11RaAluno";
            lblV11RaAluno.Size = new Size(150, 30);
            lblV11RaAluno.TabIndex = 3;
            lblV11RaAluno.Text = "-";
            // 
            // lblRaTitulo
            // 
            lblRaTitulo.AutoSize = true;
            lblRaTitulo.Font = new Font("Segoe UI", 9F);
            lblRaTitulo.Location = new Point(15, 105);
            lblRaTitulo.Name = "lblRaTitulo";
            lblRaTitulo.Size = new Size(80, 15);
            lblRaTitulo.TabIndex = 2;
            lblRaTitulo.Text = "RA/Matrícula:";
            // 
            // lblV11NomeAluno
            // 
            lblV11NomeAluno.AutoSize = true;
            lblV11NomeAluno.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblV11NomeAluno.Location = new Point(15, 60);
            lblV11NomeAluno.MinimumSize = new Size(150, 45);
            lblV11NomeAluno.Name = "lblV11NomeAluno";
            lblV11NomeAluno.Size = new Size(150, 45);
            lblV11NomeAluno.TabIndex = 1;
            lblV11NomeAluno.Text = "-";
            // 
            // lblNomeTitulo
            // 
            lblNomeTitulo.AutoSize = true;
            lblNomeTitulo.Font = new Font("Segoe UI", 9F);
            lblNomeTitulo.Location = new Point(15, 35);
            lblNomeTitulo.Name = "lblNomeTitulo";
            lblNomeTitulo.Size = new Size(43, 15);
            lblNomeTitulo.TabIndex = 0;
            lblNomeTitulo.Text = "Nome:";
            // 
            // lstV11Alunos
            // 
            lstV11Alunos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstV11Alunos.BorderStyle = BorderStyle.FixedSingle;
            lstV11Alunos.Font = new Font("Segoe UI", 11F);
            lstV11Alunos.FormattingEnabled = true;
            lstV11Alunos.IntegralHeight = false;
            lstV11Alunos.Items.AddRange(new object[] { "" });
            lstV11Alunos.Location = new Point(25, 200);
            lstV11Alunos.Name = "lstV11Alunos";
            lstV11Alunos.Size = new Size(280, 390);
            lstV11Alunos.TabIndex = 3;
            lstV11Alunos.SelectedIndexChanged += lstV11Alunos_SelectedIndexChanged;
            // 
            // txtV11BuscarAluno
            // 
            txtV11BuscarAluno.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtV11BuscarAluno.Font = new Font("Segoe UI", 12F);
            txtV11BuscarAluno.Location = new Point(25, 145);
            txtV11BuscarAluno.MaxLength = 100;
            txtV11BuscarAluno.Name = "txtV11BuscarAluno";
            txtV11BuscarAluno.PlaceholderText = "Buscar por Nome ou RA";
            txtV11BuscarAluno.Size = new Size(450, 29);
            txtV11BuscarAluno.TabIndex = 2;
            txtV11BuscarAluno.TextChanged += txtV11BuscarAluno_TextChanged;
            // 
            // lblSelecionarAluno
            // 
            lblSelecionarAluno.AutoSize = true;
            lblSelecionarAluno.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSelecionarAluno.ForeColor = Color.MidnightBlue;
            lblSelecionarAluno.Location = new Point(25, 106);
            lblSelecionarAluno.Name = "lblSelecionarAluno";
            lblSelecionarAluno.Size = new Size(191, 30);
            lblSelecionarAluno.TabIndex = 1;
            lblSelecionarAluno.Text = "Selecionar Aluno:";
            // 
            // pnlCadastroLiberacao
            // 
            pnlCadastroLiberacao.BackColor = Color.White;
            pnlCadastroLiberacao.BorderStyle = BorderStyle.FixedSingle;
            pnlCadastroLiberacao.Controls.Add(lblCabecalhoLiberacao);
            pnlCadastroLiberacao.Dock = DockStyle.Top;
            pnlCadastroLiberacao.Location = new Point(0, 0);
            pnlCadastroLiberacao.Name = "pnlCadastroLiberacao";
            pnlCadastroLiberacao.Size = new Size(498, 100);
            pnlCadastroLiberacao.TabIndex = 0;
            // 
            // lblCabecalhoLiberacao
            // 
            lblCabecalhoLiberacao.AutoSize = true;
            lblCabecalhoLiberacao.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCabecalhoLiberacao.ForeColor = Color.MidnightBlue;
            lblCabecalhoLiberacao.Location = new Point(25, 20);
            lblCabecalhoLiberacao.Name = "lblCabecalhoLiberacao";
            lblCabecalhoLiberacao.Size = new Size(235, 30);
            lblCabecalhoLiberacao.TabIndex = 1;
            lblCabecalhoLiberacao.Text = "Liberação de Votação";
            // 
            // btnSair
            // 
            btnSair.Anchor = AnchorStyles.Top;
            btnSair.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSair.Location = new Point(748, 713);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(111, 43);
            btnSair.TabIndex = 8;
            btnSair.Text = "Sair";
            btnSair.UseMnemonic = false;
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // lblTituloTerminalV11
            // 
            lblTituloTerminalV11.AutoSize = true;
            lblTituloTerminalV11.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTituloTerminalV11.ForeColor = Color.MidnightBlue;
            lblTituloTerminalV11.Location = new Point(30, 30);
            lblTituloTerminalV11.Name = "lblTituloTerminalV11";
            lblTituloTerminalV11.Size = new Size(224, 30);
            lblTituloTerminalV11.TabIndex = 0;
            lblTituloTerminalV11.Text = "Terminal de Votação";
            // 
            // TelaLiberarVotacao
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            AutoScrollMinSize = new Size(1500, 900);
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1584, 761);
            Controls.Add(splitPrincipal);
            Font = new Font("Segoe UI", 10F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MinimumSize = new Size(1300, 800);
            Name = "TelaLiberarVotacao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UrnaLab - Simulação Escolar";
            WindowState = FormWindowState.Maximized;
            pnlTerminalV11.ResumeLayout(false);
            pnlCorpoTerminalV11.ResumeLayout(false);
            pnlVisorV11.ResumeLayout(false);
            pnlVisorV11.PerformLayout();
            splitPrincipal.Panel1.ResumeLayout(false);
            splitPrincipal.Panel1.PerformLayout();
            splitPrincipal.Panel2.ResumeLayout(false);
            splitPrincipal.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitPrincipal).EndInit();
            splitPrincipal.ResumeLayout(false);
            grpDetalhesAluno.ResumeLayout(false);
            grpDetalhesAluno.PerformLayout();
            pnlCadastroLiberacao.ResumeLayout(false);
            pnlCadastroLiberacao.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnVoltar;
        private SplitContainer splitPrincipal;
        private Panel pnlCadastroLiberacao;
        private Label lblCabecalhoLiberacao;
        private Label lblSelecionarAluno;
        private TextBox txtV11BuscarAluno;
        private ListBox lstV11Alunos;
        private GroupBox grpDetalhesAluno;
        private Label lblV11StatusAluno;
        private Label lblStatusDetalhe;
        private Label lblV11TurmaAluno;
        private Label lblTurmaTitulo;
        private Label lblV11RaAluno;
        private Label lblRaTitulo;
        private Label lblV11NomeAluno;
        private Label lblNomeTitulo;
        private Button btnV11LiberarVotacao;
        private Label lblTituloTerminalV11;
        private Panel pnlTerminalV11;
        private Panel pnlCorpoTerminalV11;
        private Panel pnlVisorV11;
        private Label lblTituloVisorV11;
        private Panel pnlLinhaVisorV11;
        private Label lblRotuloChapaV11;
        private Label lblV11Chapa;
        private Label lblNumeroTituloV11;
        private Label lblV11Numero;
        private Button btnSair;
        private Label lblV11SituacaoAluno;
        private Button btnV11Corrige;
        private Button btnV11Confirma;
    }
}