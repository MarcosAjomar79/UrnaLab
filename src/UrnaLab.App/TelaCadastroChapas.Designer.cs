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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCadastroChapas));
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
            lblTitulo.Location = new Point(510, 53);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(331, 46);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Cadastro de Chapas";
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(274, 187);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(133, 20);
            lblNumero.TabIndex = 1;
            lblNumero.Text = "Número da Chapa:";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(446, 181);
            txtNumero.Margin = new Padding(3, 4, 3, 4);
            txtNumero.Name = "txtNumero";
            txtNumero.PlaceholderText = "Digite o Número da Chapa:";
            txtNumero.Size = new Size(251, 27);
            txtNumero.TabIndex = 2;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(274, 253);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(120, 20);
            lblNome.TabIndex = 3;
            lblNome.Text = "Nome da Chapa:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(446, 248);
            txtNome.Margin = new Padding(3, 4, 3, 4);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Digite o Nome da Chapa:";
            txtNome.Size = new Size(411, 27);
            txtNome.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(274, 320);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Ativa", "Inativa" });
            cboStatus.Location = new Point(446, 315);
            cboStatus.Margin = new Padding(3, 4, 3, 4);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(205, 28);
            cboStatus.TabIndex = 6;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(320, 440);
            btnSalvar.Margin = new Padding(3, 4, 3, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(137, 53);
            btnSalvar.TabIndex = 7;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(480, 440);
            btnLimpar.Margin = new Padding(3, 4, 3, 4);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(137, 53);
            btnLimpar.TabIndex = 8;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(640, 440);
            btnVoltar.Margin = new Padding(3, 4, 3, 4);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(137, 53);
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
            dgvChapas.Location = new Point(169, 547);
            dgvChapas.Margin = new Padding(3, 4, 3, 4);
            dgvChapas.Name = "dgvChapas";
            dgvChapas.ReadOnly = true;
            dgvChapas.RowHeadersWidth = 51;
            dgvChapas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChapas.Size = new Size(800, 160);
            dgvChapas.TabIndex = 10;
            // 
            // TelaCadastroChapas
            // 
            AcceptButton = btnSalvar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(1300, 800);
            CancelButton = btnVoltar;
            ClientSize = new Size(1098, 748);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
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