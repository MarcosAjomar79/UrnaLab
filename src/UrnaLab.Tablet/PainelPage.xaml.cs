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
}