using UrnaLab.Tablet.Data;
using UrnaLab.Tablet.Models;


namespace UrnaLab.Tablet;

public partial class LiberarVotacaoPage : ContentPage
{
	private readonly AlunoDatabase alunoDatabase = new();
    private List<Aluno> todosAlunos = new();
    private Aluno? alunoSelecionado;

    public LiberarVotacaoPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        alunoSelecionado = null;

        listaAlunos.SelectedItem = null;

        lblAlunoSelecionado.Text =
            "Nenhum aluno selecionado";

        btnLiberar.IsEnabled = false;

        await CarregarAlunosAsync();
    }

    private async Task CarregarAlunosAsync()
    {
        todosAlunos = await alunoDatabase.ObterAlunosAsync();

        listaAlunos.ItemsSource = todosAlunos;
    }

    private void txtBuscarAluno_TextChanged(object? sender, TextChangedEventArgs e)
    {
        string busca = e.NewTextValue?.Trim() ?? "";

        if (string.IsNullOrEmpty(busca))
        {
            listaAlunos.ItemsSource = todosAlunos;
            return;
        }

        var resultado = todosAlunos
           .Where(a =>a.Nome.Contains(busca, StringComparison.OrdinalIgnoreCase)
               ||
               a.Ra.Contains(busca, StringComparison.OrdinalIgnoreCase)).ToList();

        listaAlunos.ItemsSource = resultado;
    }

    private void listaAlunos_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        alunoSelecionado = e.CurrentSelection.FirstOrDefault() as Aluno;

        if (alunoSelecionado is null)
        {
            lblAlunoSelecionado.Text = "Nenhum aluno selecionado.";

            btnLiberar.IsEnabled = false; return;

        }

        lblAlunoSelecionado.Text = $"Aluno selecionado: {alunoSelecionado.Nome} (RA: {alunoSelecionado.Ra})";

        btnLiberar.IsEnabled = true;
    }

    private async void btnLiberar_Click(object? sender, EventArgs e)
    {
        if (alunoSelecionado is null)
            return;

        if(alunoSelecionado.Status !="Ativo")
        {
            await DisplayAlert("Atenção", "O aluno selecionado não está ativo e não pode liberar a votação.", "OK");
            return;
        }

        if (alunoSelecionado.JaVotou)
        {
            await DisplayAlert(
                "Votação bloqueada",
                "Este aluno já realizou sua votação.",
                "OK");

            return;
        }
        await Shell.Current.GoToAsync($"{nameof(VotacaoPage)}?alunoId={alunoSelecionado.Id}");
    }
}
