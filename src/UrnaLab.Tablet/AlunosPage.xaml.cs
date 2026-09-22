using UrnaLab.Tablet.Data;
using UrnaLab.Tablet.Models;

namespace UrnaLab.Tablet;

public partial class AlunosPage : ContentPage
{
    private readonly AlunoDatabase alunoDatabase = new();

    private List<Aluno> todosAlunos = new();
    private Aluno? alunoSelecionado;

    public AlunosPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await CarregarAlunosAsync();
    }

    private async Task CarregarAlunosAsync()
    {
        todosAlunos = await alunoDatabase.ObterAlunosAsync();

        listaAlunos.ItemsSource = null;
        listaAlunos.ItemsSource = todosAlunos;
    }

    private async void btnNovoAluno_Click(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CadastroAlunoPage));
    }

    private void txtBuscarAluno_TextChanged(object? sender, TextChangedEventArgs e)
    {
        string busca = e.NewTextValue?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(busca))
        {
            listaAlunos.ItemsSource = todosAlunos;
            return;
        }

        var resultado = todosAlunos.Where(a =>a.Nome.Contains(busca, StringComparison.OrdinalIgnoreCase)
                ||
                a.Ra.Contains(busca, StringComparison.OrdinalIgnoreCase)).ToList();
        listaAlunos.ItemsSource = resultado;
    }

    private void listaAlunos_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        alunoSelecionado = e.CurrentSelection.FirstOrDefault() as Aluno;

        bool temAlunoSelecionado = alunoSelecionado is not null;

        btnEditarAluno.IsEnabled = temAlunoSelecionado;
        btnExcluirAluno.IsEnabled = temAlunoSelecionado;
    }

    private async void btnEditarAluno_Click(object? sender, EventArgs e)
    {
        if (alunoSelecionado is null)
            return;

        await Shell.Current.GoToAsync($"{nameof(CadastroAlunoPage)}?alunoId={alunoSelecionado.Id}");
    }

    private async void btnExcluirAluno_Click(object? sender, EventArgs e)
    {
        if (alunoSelecionado is null)
            return;
        bool confirmacao = await DisplayAlert("Confirmação", $"Deseja realmente excluir o aluno {alunoSelecionado.Nome}?", "Sim", "Não");
        if (!confirmacao)
            return;
        if (alunoSelecionado.JaVotou == true)
        {
            await DisplayAlert("Erro", "Não é possível excluir um aluno que já votou.", "OK");
            return;
        }
        await alunoDatabase.ExcluirAsync(alunoSelecionado);
        await CarregarAlunosAsync();
    }
}