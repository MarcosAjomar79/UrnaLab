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
        lblTitulo = new Label();
        lblUsuario = new Label();
        txtUsuario = new TextBox();
        lblSenha = new Label();
        txtSenha = new TextBox();
        btnEntrar = new Button();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.Anchor = AnchorStyles.Top;
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTitulo.Location = new Point(271, 25);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(259, 37);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Acesso ao UrnaLab";
        lblTitulo.TextAlign = ContentAlignment.TopCenter;
        // 
        // lblUsuario
        // 
        lblUsuario.Anchor = AnchorStyles.Top;
        lblUsuario.AutoSize = true;
        lblUsuario.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblUsuario.Location = new Point(230, 120);
        lblUsuario.Name = "lblUsuario";
        lblUsuario.Size = new Size(62, 20);
        lblUsuario.TabIndex = 1;
        lblUsuario.Text = "Usuário:";
        // 
        // txtUsuario
        // 
        txtUsuario.Anchor = AnchorStyles.Top;
        txtUsuario.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtUsuario.Location = new Point(320, 116);
        txtUsuario.MaxLength = 50;
        txtUsuario.Name = "txtUsuario";
        txtUsuario.PlaceholderText = "Digite o seu usuário";
        txtUsuario.Size = new Size(250, 27);
        txtUsuario.TabIndex = 0;
        // 
        // lblSenha
        // 
        lblSenha.Anchor = AnchorStyles.Top;
        lblSenha.AutoSize = true;
        lblSenha.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblSenha.Location = new Point(230, 170);
        lblSenha.Name = "lblSenha";
        lblSenha.Size = new Size(52, 20);
        lblSenha.TabIndex = 3;
        lblSenha.Text = "Senha:";
        // 
        // txtSenha
        // 
        txtSenha.Anchor = AnchorStyles.Top;
        txtSenha.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtSenha.Location = new Point(320, 166);
        txtSenha.MaxLength = 50;
        txtSenha.Name = "txtSenha";
        txtSenha.PlaceholderText = "Digite a sua senha";
        txtSenha.Size = new Size(250, 27);
        txtSenha.TabIndex = 1;
        txtSenha.UseSystemPasswordChar = true;
        // 
        // btnEntrar
        // 
        btnEntrar.Anchor = AnchorStyles.Top;
        btnEntrar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnEntrar.Location = new Point(340, 220);
        btnEntrar.Name = "btnEntrar";
        btnEntrar.Size = new Size(120, 40);
        btnEntrar.TabIndex = 2;
        btnEntrar.Text = "Entrar";
        btnEntrar.UseVisualStyleBackColor = true;
        btnEntrar.Click += this.btnEntrar_Click;
        // 
        // TelaLogin
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(btnEntrar);
        Controls.Add(txtSenha);
        Controls.Add(lblSenha);
        Controls.Add(txtUsuario);
        Controls.Add(lblUsuario);
        Controls.Add(lblTitulo);
        Name = "TelaLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "UrnaLab - Urna Eleitoral Grêmio";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitulo;
    private Label lblUsuario;
    private TextBox txtUsuario;
    private Label lblSenha;
    private TextBox txtSenha;
    private Button btnEntrar;
}
