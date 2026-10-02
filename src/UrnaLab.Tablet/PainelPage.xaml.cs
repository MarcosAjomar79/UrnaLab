namespace UrnaLab.Tablet;

public partial class PainelPage : ContentPage
{
	public PainelPage()
	{
		InitializeComponent();
	}

    private async void btnAlunos_Click(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AlunosPage));
    }

    private async void btnChapas_Click(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ChapasPage));
    }

    private async void btnIniciarVotacao_Click(object? sender,EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ConfigurarVotacaoPage));
    }

    private async void btnRelatorios_Click(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(RelatoriosPage));
    }

    private void pickerTema_SelectedIndexChanged(object? sender, EventArgs e)
    {
        string? tema_Selecionado = pickerTema.SelectedItem as string;

        if (tema_Selecionado is null)
            return;

        if (tema_Selecionado == "Sistema")
        {
            Application.Current?.UserAppTheme = AppTheme.Unspecified;
        }
        if (tema_Selecionado == "Escuro")
        {
            Application.Current?.UserAppTheme = AppTheme.Dark;
        }
        if (tema_Selecionado == "Claro")
        {
            Application.Current?.UserAppTheme = AppTheme.Light;
        }

        Preferences.Set("TemaSelecionado", tema_Selecionado);

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        string temaSalvo = Preferences.Get("TemaSelecionado", "Sistema");

        pickerTema.SelectedItem = temaSalvo;
    }
}