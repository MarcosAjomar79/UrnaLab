using UrnaLab.Tablet.Data;
using UrnaLab.Tablet.Models;

namespace UrnaLab.Tablet;

public partial class AlunosPage : ContentPage
{
    private readonly AlunoDatabase alunoDatabase = new();

    private List<Aluno> todosAlunos = new();

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
}