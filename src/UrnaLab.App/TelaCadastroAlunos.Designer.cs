namespace UrnaLab.App
{
    partial class TelaCadastroAlunos
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
            lblRa = new Label();
            txtRa = new TextBox();
            lblNome = new Label();
            txtNome = new TextBox();
            lblTurma = new Label();
            txtTurma = new TextBox();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            btnSalvar = new Button();
            btnLimpar = new Button();
            btnVoltar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(320, 40);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(266, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Cadastro de Alunos";
            // 
            // lblRa
            // 
            lblRa.AutoSize = true;
            lblRa.Location = new Point(220, 130);
            lblRa.Name = "lblRa";
            lblRa.Size = new Size(80, 15);
            lblRa.TabIndex = 1;
            lblRa.Text = "RA/Matrícula:";
            // 
            // txtRa
            // 
            txtRa.Location = new Point(360, 126);
            txtRa.Name = "txtRa";
            txtRa.PlaceholderText = "Digite o seu RA/Matrícula";
            txtRa.Size = new Size(260, 23);
            txtRa.TabIndex = 2;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(220, 180);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(99, 15);
            lblNome.TabIndex = 3;
            lblNome.Text = "Nome Completo:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(360, 176);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Digite o seu nome completo";
            txtNome.Size = new Size(360, 23);
            txtNome.TabIndex = 4;
            // 
            // lblTurma
            // 
            lblTurma.AutoSize = true;
            lblTurma.Location = new Point(220, 230);
            lblTurma.Name = "lblTurma";
            lblTurma.Size = new Size(44, 15);
            lblTurma.TabIndex = 5;
            lblTurma.Text = "Turma:";
            // 
            // txtTurma
            // 
            txtTurma.Location = new Point(360, 226);
            txtTurma.Name = "txtTurma";
            txtTurma.PlaceholderText = "Digite a sua Turma";
            txtTurma.Size = new Size(180, 23);
            txtTurma.TabIndex = 6;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(220, 280);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(42, 15);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Status:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Ativo", "Inativo" });
            cboStatus.Location = new Point(360, 276);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(180, 23);
            cboStatus.TabIndex = 8;
            cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(300, 430);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(120, 40);
            btnSalvar.TabIndex = 9;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(440, 430);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(120, 40);
            btnLimpar.TabIndex = 10;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(580, 430);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(120, 40);
            btnVoltar.TabIndex = 11;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // TelaCadastroAlunos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(btnVoltar);
            Controls.Add(btnLimpar);
            Controls.Add(btnSalvar);
            Controls.Add(cboStatus);
            Controls.Add(lblStatus);
            Controls.Add(txtTurma);
            Controls.Add(lblTurma);
            Controls.Add(txtNome);
            Controls.Add(lblNome);
            Controls.Add(txtRa);
            Controls.Add(lblRa);
            Controls.Add(lblTitulo);
            Name = "TelaCadastroAlunos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UrnaLab - Cadastro de Alunos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblRa;
        private TextBox txtRa;
        private Label lblNome;
        private TextBox txtNome;
        private Label lblTurma;
        private TextBox txtTurma;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Button btnSalvar;
        private Button btnLimpar;
        private Button btnVoltar;
    }
}