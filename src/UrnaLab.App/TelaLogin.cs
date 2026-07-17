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
                "Informe o usuário e a senha.",
                "Atenção",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return;
        }
        MessageBox.Show("Tentativa de Login recebida.");
    }
}
