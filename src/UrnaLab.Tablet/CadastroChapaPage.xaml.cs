using UrnaLab.Tablet.Data;
using UrnaLab.Tablet.Models;

namespace UrnaLab.Tablet;

public partial class CadastroChapaPage : ContentPage, IQueryAttributable
{
    private readonly ChapaDatabase chapaDatabase = new();

    private int? chapaIdEdicao;
    private Chapa? chapaEmEdicao;

    public CadastroChapaPage()
    {
        InitializeComponent();

        pickerStatus.Items.Add("Ativo");
        pickerStatus.Items.Add("Inativo");

        pickerStatus.SelectedIndex = 0;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("chapaId", out object? valor))
        {
            if (int.TryParse(valor?.ToString(), out int Id))
            {
                chapaIdEdicao = Id;
            }
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CarregarChapaParaEdicao();
    }

    private async void btnSalvar_Click(object? sender, EventArgs e)
    {
        string numeroTexto = txtNumero.Text?.Trim() ?? "";
        string nome = txtNome.Text?.Trim() ?? "";
        string status = pickerStatus.SelectedItem?.ToString() ?? "Ativo";

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

        try
        {
            if (chapaEmEdicao is null)
            {
                var chapa = new Chapa
                {
                    Numero = numero,
                    Nome = nome,
                    Status = status
                };

                await chapaDatabase.CadastrarAsync(chapa);
                await DisplayAlert("Cadastro realizado", "Chapa cadastrada com sucesso.", "OK");
                
            }
            else
            {
                chapaEmEdicao.Nome = nome;
                chapaEmEdicao.Numero = numero;
                chapaEmEdicao.Status = status;
                await chapaDatabase.AtualizarAsync(chapaEmEdicao);
                await DisplayAlert(
                    "Edição realizada",
                    "Chapa atualizada com sucesso.",
                    "OK");
                await Shell.Current.GoToAsync("..");
            }
        }
        catch (SQLite.SQLiteException)
        {
            await DisplayAlert("Número já cadastrado", "Já existe uma chapa com esse número.", "OK");
        }
    }

        public async Task CarregarChapaParaEdicao()
    {
        if (chapaIdEdicao.HasValue)
        {
            chapaEmEdicao = await chapaDatabase.ObterPorIdAsync(chapaIdEdicao.Value);
            if (chapaEmEdicao != null)
            {
                txtNome.Text = chapaEmEdicao.Nome;
                txtNumero.Text = chapaEmEdicao.Numero.ToString();
                pickerStatus.SelectedItem = chapaEmEdicao.Status;

                Title = "Editar Chapa";
            }
        }
    }

    private async void btnCancelar_Click(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}