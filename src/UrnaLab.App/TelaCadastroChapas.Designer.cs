namespace UrnaLab.App
{
    partial class TelaCadastroChapas
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
            lblNumero = new Label();
            txtNumero = new TextBox();
            lblNome = new Label();
            txtNome = new TextBox();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            btnSalvar = new Button();
            btnLimpar = new Button();
            btnVoltar = new Button();
            dgvChapas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvChapas).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(358, 40);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(270, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Cadastro de Chapas";
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(240, 140);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(107, 15);
            lblNumero.TabIndex = 1;
            lblNumero.Text = "Número da Chapa:";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(390, 136);
            txtNumero.Name = "txtNumero";
            txtNumero.PlaceholderText = "Digite o Número da Chapa:";
            txtNumero.Size = new Size(220, 23);
            txtNumero.TabIndex = 2;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(240, 190);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(96, 15);
            lblNome.TabIndex = 3;
            lblNome.Text = "Nome da Chapa:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(390, 186);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Digite o Nome da Chapa:";
            txtNome.Size = new Size(360, 23);
            txtNome.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(240, 240);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(42, 15);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Ativa", "Inativa" });
            cboStatus.Location = new Point(390, 236);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(180, 23);
            cboStatus.TabIndex = 6;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(280, 330);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(120, 40);
            btnSalvar.TabIndex = 7;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(420, 330);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(120, 40);
            btnLimpar.TabIndex = 8;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(560, 330);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(120, 40);
            btnVoltar.TabIndex = 9;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // dgvChapas
            // 
            dgvChapas.AllowUserToAddRows = false;
            dgvChapas.AllowUserToDeleteRows = false;
            dgvChapas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChapas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChapas.Location = new Point(148, 410);
            dgvChapas.Name = "dgvChapas";
            dgvChapas.ReadOnly = true;
            dgvChapas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChapas.Size = new Size(700, 120);
            dgvChapas.TabIndex = 10;
            // 
            // TelaCadastroChapas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 561);
            Controls.Add(dgvChapas);
            Controls.Add(btnVoltar);
            Controls.Add(btnLimpar);
            Controls.Add(btnSalvar);
            Controls.Add(cboStatus);
            Controls.Add(lblStatus);
            Controls.Add(txtNome);
            Controls.Add(lblNome);
            Controls.Add(txtNumero);
            Controls.Add(lblNumero);
            Controls.Add(lblTitulo);
            Name = "TelaCadastroChapas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UrnaLab - Cadastro de Chapas";
            ((System.ComponentModel.ISupportInitialize)dgvChapas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNumero;
        private TextBox txtNumero;
        private Label lblNome;
        private TextBox txtNome;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Button btnSalvar;
        private Button btnLimpar;
        private Button btnVoltar;
        private DataGridView dgvChapas;
    }
}