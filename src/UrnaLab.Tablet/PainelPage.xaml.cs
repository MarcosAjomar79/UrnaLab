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
        await Shell.Current.GoToAsync(nameof(LiberarVotacaoPage));
    }

    private async void btnRelatorios_Click(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(RelatoriosPage));
    }
}