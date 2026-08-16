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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCadastroAlunos));
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
            dgvAlunos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAlunos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(510, 53);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(330, 46);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Cadastro de Alunos";
            // 
            // lblRa
            // 
            lblRa.AutoSize = true;
            lblRa.Location = new Point(251, 173);
            lblRa.Name = "lblRa";
            lblRa.Size = new Size(99, 20);
            lblRa.TabIndex = 1;
            lblRa.Text = "RA/Matrícula:";
            // 
            // txtRa
            // 
            txtRa.Location = new Point(411, 168);
            txtRa.Margin = new Padding(3, 4, 3, 4);
            txtRa.Name = "txtRa";
            txtRa.PlaceholderText = "Digite o seu RA/Matrícula";
            txtRa.Size = new Size(297, 27);
            txtRa.TabIndex = 2;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(251, 240);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(123, 20);
            lblNome.TabIndex = 3;
            lblNome.Text = "Nome Completo:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(411, 235);
            txtNome.Margin = new Padding(3, 4, 3, 4);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Digite o seu nome completo";
            txtNome.Size = new Size(411, 27);
            txtNome.TabIndex = 4;
            // 
            // lblTurma
            // 
            lblTurma.AutoSize = true;
            lblTurma.Location = new Point(251, 307);
            lblTurma.Name = "lblTurma";
            lblTurma.Size = new Size(54, 20);
            lblTurma.TabIndex = 5;
            lblTurma.Text = "Turma:";
            // 
            // txtTurma
            // 
            txtTurma.Location = new Point(411, 301);
            txtTurma.Margin = new Padding(3, 4, 3, 4);
            txtTurma.Name = "txtTurma";
            txtTurma.PlaceholderText = "Digite a sua Turma";
            txtTurma.Size = new Size(205, 27);
            txtTurma.TabIndex = 6;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(251, 373);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Status:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Ativo", "Inativo" });
            cboStatus.Location = new Point(411, 368);
            cboStatus.Margin = new Padding(3, 4, 3, 4);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(205, 28);
            cboStatus.TabIndex = 8;
            cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(320, 457);
            btnSalvar.Margin = new Padding(3, 4, 3, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(137, 53);
            btnSalvar.TabIndex = 9;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(480, 457);
            btnLimpar.Margin = new Padding(3, 4, 3, 4);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(137, 53);
            btnLimpar.TabIndex = 10;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(624, 457);
            btnVoltar.Margin = new Padding(3, 4, 3, 4);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(137, 53);
            btnVoltar.TabIndex = 11;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // dgvAlunos
            // 
            dgvAlunos.AllowUserToAddRows = false;
            dgvAlunos.AllowUserToDeleteRows = false;
            dgvAlunos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlunos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlunos.Location = new Point(136, 560);
            dgvAlunos.Margin = new Padding(3, 4, 3, 4);
            dgvAlunos.Name = "dgvAlunos";
            dgvAlunos.ReadOnly = true;
            dgvAlunos.RowHeadersWidth = 51;
            dgvAlunos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlunos.Size = new Size(846, 240);
            dgvAlunos.TabIndex = 12;
            dgvAlunos.CellContentClick += dgvAlunos_CellContentClick;
            // 
            // TelaCadastroAlunos
            // 
            AcceptButton = btnSalvar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(1300, 800);
            CancelButton = btnVoltar;
            ClientSize = new Size(1181, 883);
            Controls.Add(dgvAlunos);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "TelaCadastroAlunos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UrnaLab - Cadastro de Alunos";
            ((System.ComponentModel.ISupportInitialize)dgvAlunos).EndInit();
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
        private DataGridView dgvAlunos;
    }
}