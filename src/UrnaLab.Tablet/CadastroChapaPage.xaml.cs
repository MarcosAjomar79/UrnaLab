using UrnaLab.Tablet.Data;
using UrnaLab.Tablet.Models;

namespace UrnaLab.Tablet;

public partial class CadastroChapaPage : ContentPage
{
    private readonly ChapaDatabase chapaDatabase = new();

    public CadastroChapaPage()
    {
        InitializeComponent();

        pickerStatus.Items.Add("Ativo");
        pickerStatus.Items.Add("Inativo");

        pickerStatus.SelectedIndex = 0;
    }

    private async void btnSalvar_Click(object? sender, EventArgs e)
    {
        string numeroTexto = txtNumero.Text?.Trim() ?? "";
        string nome = txtNome.Text?.Trim() ?? "";
        string status =
            pickerStatus.SelectedItem?.ToString() ?? "Ativo";

        if (!int.TryParse(numeroTexto, out int numero))
        {
            await DisplayAlert("Número inválido", "Digite um número válido para a chapa.", "OK");
            return;
        }

        if (numero < 0 || numero > 999)
        {
            await DisplayAlert("Número inválido", "O número da chapa deve possuir até 3 dígitos.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(nome))
        {
            await DisplayAlert("Campo obrigatório", "Informe o nome da chapa.", "OK");
            return;
        }

        var chapa = new Chapa
        {
            Numero = numero,
            Nome = nome,
            Status = status
        };

        try
        {
            await chapaDatabase.CadastrarAsync(chapa);
            await DisplayAlert("Cadastro realizado", "Chapa cadastrada com sucesso.", "OK");
            await Shell.Current.GoToAsync("..");
        }
        catch (SQLite.SQLiteException)
        {
            await DisplayAlert("Número já cadastrado", "Já existe uma chapa com esse número.", "OK");
        }
    }

    private async void btnCancelar_Click(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}