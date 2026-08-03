using UrnaLab.App.Data;

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

        string? perfil = Database.ValidarUsuario(usuario, senha);

        if (perfil == null)
        {
            MessageBox.Show(
                "Usuário ou senha inválidos.",
                "Erro de Login",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            return;
        }

        MessageBox.Show(
            $"Login realizado com sucesso!\nPerfil: {perfil}",
            "Sucesso",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );

        if (perfil == "Administrador")
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();
            telaPrincipal.ShowDialog();

            this.Hide();
        }

        else if (perfil == "Mesário")
        {
            TelaLiberarVotacao telaMesario = new TelaLiberarVotacao();
            telaMesario.ShowDialog();

            this.Hide();
        }

    }

    private void btnLimpar_Click(object sender, EventArgs e)
    {
        txtUsuario.Text = "";
        txtSenha.Text = "";
    }
}
