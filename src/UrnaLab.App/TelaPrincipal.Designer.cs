namespace UrnaLab.App
{
    partial class TelaPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            lblTitulo = new Label();
            btnAlunos = new Button();
            btnChapas = new Button();
            btnVotacao = new Button();
            btnRelatorios = new Button();
            btnSair = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(541, 53);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(263, 46);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Menu Principal";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnAlunos
            // 
            btnAlunos.Anchor = AnchorStyles.Top;
            btnAlunos.Location = new Point(536, 173);
            btnAlunos.Margin = new Padding(3, 4, 3, 4);
            btnAlunos.Name = "btnAlunos";
            btnAlunos.Size = new Size(251, 60);
            btnAlunos.TabIndex = 1;
            btnAlunos.Text = "Cadastrar Alunos";
            btnAlunos.UseVisualStyleBackColor = true;
            btnAlunos.Click += btnAlunos_Click;
            // 
            // btnChapas
            // 
            btnChapas.Anchor = AnchorStyles.Top;
            btnChapas.Location = new Point(536, 253);
            btnChapas.Margin = new Padding(3, 4, 3, 4);
            btnChapas.Name = "btnChapas";
            btnChapas.Size = new Size(251, 60);
            btnChapas.TabIndex = 2;
            btnChapas.Text = "Cadastrar Chapas";
            btnChapas.UseVisualStyleBackColor = true;
            btnChapas.Click += btnChapas_Click;
            // 
            // btnVotacao
            // 
            btnVotacao.Anchor = AnchorStyles.Top;
            btnVotacao.Location = new Point(536, 333);
            btnVotacao.Margin = new Padding(3, 4, 3, 4);
            btnVotacao.Name = "btnVotacao";
            btnVotacao.Size = new Size(251, 60);
            btnVotacao.TabIndex = 3;
            btnVotacao.Text = "Liberar Votação";
            btnVotacao.UseVisualStyleBackColor = true;
            btnVotacao.Click += btnVotacao_Click;
            // 
            // btnRelatorios
            // 
            btnRelatorios.Anchor = AnchorStyles.Top;
            btnRelatorios.Location = new Point(536, 413);
            btnRelatorios.Margin = new Padding(3, 4, 3, 4);
            btnRelatorios.Name = "btnRelatorios";
            btnRelatorios.Size = new Size(251, 60);
            btnRelatorios.TabIndex = 4;
            btnRelatorios.Text = "Relatórios";
            btnRelatorios.UseVisualStyleBackColor = true;
            btnRelatorios.Click += btnRelatorios_Click;
            // 
            // btnSair
            // 
            btnSair.Anchor = AnchorStyles.Top;
            btnSair.Location = new Point(536, 493);
            btnSair.Margin = new Padding(3, 4, 3, 4);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(251, 60);
            btnSair.TabIndex = 5;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            AutoScrollMinSize = new Size(1300, 800);
            ClientSize = new Size(1326, 748);
            Controls.Add(btnSair);
            Controls.Add(btnRelatorios);
            Controls.Add(btnVotacao);
            Controls.Add(btnChapas);
            Controls.Add(btnAlunos);
            Controls.Add(lblTitulo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "TelaPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UrnaLab - Menu Principal";
            Load += TelaPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnAlunos;
        private Button btnChapas;
        private Button btnVotacao;
        private Button btnRelatorios;
        private Button btnSair;
    }
}