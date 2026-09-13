using UrnaLab.Tablet.Data;
using UrnaLab.Tablet.Models;

namespace UrnaLab.Tablet;

public partial class ChapasPage : ContentPage
{
    private readonly ChapaDatabase chapaDatabase = new();

    private List<Chapa> todasChapas = new();

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

    private void txtBuscarChapa_TextChanged(
        object? sender,
        TextChangedEventArgs e)
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
}