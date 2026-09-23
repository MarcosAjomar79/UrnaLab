using UrnaLab.Tablet.Data;
using UrnaLab.Tablet.Models;

namespace UrnaLab.Tablet;

public partial class ChapasPage : ContentPage
{
    private readonly ChapaDatabase chapaDatabase = new();

    private List<Chapa> todasChapas = new();

    private Chapa? chapaSelecionada;
    public ChapasPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await CarregarChapasAsync();
    }

    private async Task CarregarChapasAsync()
    {
        todasChapas = await chapaDatabase.ObterChapasAsync();

        listaChapas.ItemsSource = null;
        listaChapas.ItemsSource = todasChapas;
    }

    private async void btnNovaChapa_Click(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CadastroChapaPage));
    }

    private void txtBuscarChapa_TextChanged(object? sender, TextChangedEventArgs e)
    {
        string busca = e.NewTextValue?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(busca))
        {
            listaChapas.ItemsSource = todasChapas;
            return;
        }

        var resultado = todasChapas
            .Where(c =>
                c.Nome.Contains(
                    busca,
                    StringComparison.OrdinalIgnoreCase)
                ||
                c.Numero.ToString().Contains(busca))
            .ToList();

        listaChapas.ItemsSource = resultado;
    }

    private void listaChapas_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var chapaSelecionada = e.CurrentSelection.FirstOrDefault() as Chapa;

        bool temChapaSelecionada = chapaSelecionada is not null;

        btnEditarChapa.IsEnabled = temChapaSelecionada;
        btnExcluirChapa.IsEnabled = temChapaSelecionada;

    }

    private async void btnEditarChapa_Click(object? sender, EventArgs e)
    {
        var chapaSelecionada = listaChapas.SelectedItem as Chapa;
        if (chapaSelecionada is null)
            return;

        await Shell.Current.GoToAsync($"{nameof(CadastroChapaPage)}?chapaId={chapaSelecionada.Id}");
    }

    private async void btnExcluirChapa_Click(object? sender, EventArgs e)
    {
        var chapaSelecionada = listaChapas.SelectedItem as Chapa;
        if (chapaSelecionada is null)
            return;
        bool confirmacao = await DisplayAlert(
            "Confirmação",
            $"Deseja realmente excluir a chapa {chapaSelecionada.Nome}?",
            "Sim",
            "Não"
        );
        if (!confirmacao)
            return;
        await chapaDatabase.ExcluirAsync(chapaSelecionada);
        await CarregarChapasAsync();
    }
}
