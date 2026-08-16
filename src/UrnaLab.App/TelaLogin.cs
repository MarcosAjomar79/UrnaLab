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
        this.Hide();
        TelaPrincipal telaprincipal = new TelaPrincipal();
        telaprincipal.ShowDialog();
        
    }
}
