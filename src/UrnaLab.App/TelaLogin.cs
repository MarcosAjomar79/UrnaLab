namespace UrnaLab.App;

public partial class TelaLogin : Form
{
    public TelaLogin()
    {
        InitializeComponent();
    }

    private void btnEntrar_Click(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text.Trim();
        string senha = txtSenha.Text.Trim();

        if (usuario == "" || senha == "")
        {
            MessageBox.Show(
                "Usuário ou senha com o campo vazio.",
                "Atenção",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            return;
        }

        if (usuario == "admin" && senha == "123")
        {
            MessageBox.Show(
                "Login realizado com sucesso!",
                "Sucesso!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            TelaPrincipal telaPrincipal = new TelaPrincipal();
            telaPrincipal.Show();
            this.Hide();
        }

        else
        {
            MessageBox.Show(
                "Usuário ou senha inválido, por favor digite novamente.",
                "Erro de Login",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
        }
    }

    private void btnLimpar_Click(object sender, EventArgs e)
    {
        txtUsuario.Text = "";
        txtSenha.Text = "";
    }
}
