namespace UrnaLab.App;

partial class TelaLogin
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaLogin));
        lblTitulo = new Label();
        btnEntrar = new Button();
        pictureBox1 = new PictureBox();
        label1 = new Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.Anchor = AnchorStyles.Top;
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTitulo.Location = new Point(412, 64);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(259, 37);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Acesso ao UrnaLab";
        lblTitulo.TextAlign = ContentAlignment.TopCenter;
        // 
        // btnEntrar
        // 
        btnEntrar.Anchor = AnchorStyles.Top;
        btnEntrar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnEntrar.Location = new Point(409, 284);
        btnEntrar.Name = "btnEntrar";
        btnEntrar.Size = new Size(262, 49);
        btnEntrar.TabIndex = 2;
        btnEntrar.Text = "Entrar";
        btnEntrar.UseVisualStyleBackColor = true;
        btnEntrar.Click += btnEntrar_Click;
        // 
        // pictureBox1
        // 
        pictureBox1.BackColor = Color.Transparent;
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(22, 10);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(321, 208);
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 6;
        pictureBox1.TabStop = false;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Top;
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 15F);
        label1.Location = new Point(360, 140);
        label1.Name = "label1";
        label1.Size = new Size(370, 84);
        label1.TabIndex = 7;
        label1.Text = "Sistema de votação escolar desenvolvido\npara realizar eleições de forma simples,\norganizada e segura.";
        label1.TextAlign = ContentAlignment.TopCenter;
        // 
        // TelaLogin
        // 
        AcceptButton = btnEntrar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1122, 565);
        Controls.Add(label1);
        Controls.Add(pictureBox1);
        Controls.Add(btnEntrar);
        Controls.Add(lblTitulo);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "TelaLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "UrnaLab - Urna Eleitoral Grêmio";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitulo;
    private Button btnEntrar;
    private PictureBox pictureBox1;
    private Label label1;
}
