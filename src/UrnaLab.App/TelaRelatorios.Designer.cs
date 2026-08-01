namespace UrnaLab.App
{
    partial class TelaRelatorios
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaRelatorios));
            lblTitulo = new Label();
            dgvVotos = new DataGridView();
            btnAtualizar = new Button();
            btnExportar = new Button();
            btnImprimir = new Button();
            btnVoltar = new Button();
            docRelatorio = new System.Drawing.Printing.PrintDocument();
            dlgPreVisualizacao = new PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)dgvVotos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(350, 30);
            lblTitulo.Margin = new Padding(6, 0, 6, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(284, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Relatórios da Eleição";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // dgvVotos
            // 
            dgvVotos.AllowUserToAddRows = false;
            dgvVotos.AllowUserToDeleteRows = false;
            dgvVotos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVotos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVotos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvVotos.DefaultCellStyle = dataGridViewCellStyle1;
            dgvVotos.Location = new Point(50, 120);
            dgvVotos.MultiSelect = false;
            dgvVotos.Name = "dgvVotos";
            dgvVotos.ReadOnly = true;
            dgvVotos.RowHeadersVisible = false;
            dgvVotos.RowHeadersWidth = 45;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvVotos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvVotos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVotos.Size = new Size(880, 390);
            dgvVotos.TabIndex = 1;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAtualizar.Location = new Point(170, 540);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(130, 45);
            btnAtualizar.TabIndex = 2;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportar.Location = new Point(350, 540);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(130, 45);
            btnExportar.TabIndex = 3;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnImprimir.Location = new Point(530, 540);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(130, 45);
            btnImprimir.TabIndex = 4;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnVoltar
            // 
            btnVoltar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnVoltar.Location = new Point(710, 540);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(130, 45);
            btnVoltar.TabIndex = 5;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // docRelatorio
            // 
            docRelatorio.BeginPrint += docRelatorio_BeginPrint;
            docRelatorio.PrintPage += docRelatorio_PrintPage;
            // 
            // dlgPreVisualizacao
            // 
            dlgPreVisualizacao.AutoScrollMargin = new Size(0, 0);
            dlgPreVisualizacao.AutoScrollMinSize = new Size(0, 0);
            dlgPreVisualizacao.ClientSize = new Size(400, 300);
            dlgPreVisualizacao.Document = docRelatorio;
            dlgPreVisualizacao.Enabled = true;
            dlgPreVisualizacao.Icon = (Icon)resources.GetObject("dlgPreVisualizacao.Icon");
            dlgPreVisualizacao.Name = "dlgPreVisualizacao";
            dlgPreVisualizacao.Visible = false;
            dlgPreVisualizacao.Load += dlgPreVisualizacao_Load;
            // 
            // TelaRelatorios
            // 
            AutoScaleDimensions = new SizeF(16F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(btnVoltar);
            Controls.Add(btnImprimir);
            Controls.Add(btnExportar);
            Controls.Add(btnAtualizar);
            Controls.Add(dgvVotos);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6, 7, 6, 7);
            MaximizeBox = false;
            Name = "TelaRelatorios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UrnaLab - Relatórios da Eleição";
            ((System.ComponentModel.ISupportInitialize)dgvVotos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvVotos;
        private Button btnAtualizar;
        private Button btnExportar;
        private Button btnImprimir;
        private Button btnVoltar;
        private System.Drawing.Printing.PrintDocument docRelatorio;
        private PrintPreviewDialog dlgPreVisualizacao;
    }
}