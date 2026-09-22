using UrnaLab.Tablet.Data;
using UrnaLab.Tablet.Models;

namespace UrnaLab.Tablet;

public partial class VotacaoPage : ContentPage, IQueryAttributable
{
    private readonly AlunoDatabase alunoDatabase = new();
    private readonly ChapaDatabase chapaDatabase = new();
    private readonly VotoDatabase votoDatabase = new();

    private int alunoId;

    private string numeroDigitado = "";

    private Chapa? chapaSelecionada;

    public VotacaoPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("alunoId", out object? valor) &&
            int.TryParse(valor?.ToString(), out int id))
        {
            alunoId = id;
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (alunoId <= 0)
        {
            await DisplayAlertAsync(
                "Erro",
                "Aluno inválido.",
                "OK");

            await Shell.Current.GoToAsync("..");
            return;
        }

        Aluno? aluno = await alunoDatabase.ObterPorIdAsync(alunoId);

        if (aluno is null)
        {
            await DisplayAlertAsync(
                "Erro",
                "Aluno não encontrado.",
                "OK");

            await Shell.Current.GoToAsync("..");
            return;
        }

        lblAluno.Text =
            $"{aluno.Nome} - RA {aluno.Ra}";
    }

    private async void btnNumero_Click(object? sender, EventArgs e)
    {
        if (numeroDigitado.Length >= 3)
            return;

        if (sender is not Button botao)
            return;

        string? digito = botao.CommandParameter?.ToString();

        if (string.IsNullOrWhiteSpace(digito))
            return;

        numeroDigitado += digito;

        await AtualizarVisorAsync();
    }

    private async Task AtualizarVisorAsync()
    {
        lblNumero.Text = string.IsNullOrWhiteSpace(numeroDigitado)
                ? "---"
                : numeroDigitado;

        chapaSelecionada = null;

        btnConfirmar.IsEnabled = false;

        lblChapa.Text =
            "Digite o número da chapa";

        if (!int.TryParse(
            numeroDigitado,
            out int numero))
        {
            return;
        }

        Chapa? chapa = await chapaDatabase.ObterPorNumeroAsync(numero);

        if (chapa is null)
        {
            lblChapa.Text = "Chapa não encontrada";

            return;
        }

        if (chapa.Status != "Ativo")
        {
            lblChapa.Text = "Chapa inativa";

            return;
        }

        chapaSelecionada = chapa;

        lblChapa.Text =
            chapa.Nome;

        btnConfirmar.IsEnabled = true;
    }

    private void btnCorrige_Click(
        object? sender,
        EventArgs e)
    {
        numeroDigitado = "";

        chapaSelecionada = null;

        lblNumero.Text = "---";

        lblChapa.Text = "Digite o número da chapa";

        btnConfirmar.IsEnabled = false;
    }

    private async void btnConfirmar_Click(
        object? sender,
        EventArgs e)
    {
        if (chapaSelecionada is null)
            return;

        btnConfirmar.IsEnabled = false;

        try
        {
            await votoDatabase.RegistrarVotoAsync(alunoId, chapaSelecionada.Id);

            await DisplayAlertAsync(
                "Voto confirmado",
                "Voto registrado com sucesso.",
                "OK");

            await Shell.Current.GoToAsync("..");
        }
        catch (InvalidOperationException ex)
        {
            await DisplayAlertAsync(
                "Votação bloqueada",
                ex.Message,
                "OK");

            await Shell.Current.GoToAsync("..");
        }
        catch (SQLite.SQLiteException)
        {
            await DisplayAlertAsync(
                "Erro",
                "Não foi possível registrar o voto.",
                "OK");

            btnConfirmar.IsEnabled = true;
        }
    }
}