using UrnaLab.Tablet.Data;
using UrnaLab.Tablet.Models;
using UrnaLab.Tablet.Services;
using Plugin.Maui.Audio;

#if ANDROID
using AndroidX.Core.View;
using Microsoft.Maui.ApplicationModel;
#endif

namespace UrnaLab.Tablet;

public partial class VotacaoPage : ContentPage, IQueryAttributable
{
    private readonly AlunoDatabase alunoDatabase = new();
    private readonly ChapaDatabase chapaDatabase = new();
    private readonly VotoDatabase votoDatabase = new();
    private readonly ConfiguracaoEleicaoDatabase configuracaoEleicaoDatabase = new();
    private IAudioPlayer? audioPlayer;
    private int? alunoId;

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
        EntrarModoImersivo();
        var configuracao = await configuracaoEleicaoDatabase.ObterConfiguracaoAsync();

        if (configuracao.ModoVotacao == "Anonima")
        {
            lblAluno.Text = "Votação sem identificação";
            return;
        }

        if (!alunoId.HasValue)
        {
            await DisplayAlertAsync(
                "Erro",
                "Aluno inválido.",
                "OK");

            await Shell.Current.GoToAsync("..");
            return;
        }

        Aluno? aluno = await alunoDatabase.ObterPorIdAsync(alunoId.Value);

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

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        SairModoImersivo();
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

    private async void btnConfirmar_Click(object? sender,EventArgs e)
    {
        if (chapaSelecionada is null)
            return;

        btnConfirmar.IsEnabled = false;

        var configuracao = await configuracaoEleicaoDatabase.ObterConfiguracaoAsync();

        if (configuracao.ModoVotacao == "Identificada")
        {
            await votoDatabase.RegistrarVotoAsync(alunoId, chapaSelecionada.Id);
            await TocarSomVotoAsync();

            await DisplayAlertAsync(
                "Voto confirmado",
                "Voto registrado com sucesso.",
                "OK");

            await Shell.Current.GoToAsync("..");
        }

        if (configuracao.ModoVotacao == "Anonima")
        {
            if (chapaSelecionada is null)
                return;

            btnConfirmar.IsEnabled = false;
            await votoDatabase.RegistrarVotoAsync(alunoId, chapaSelecionada.Id);
            await TocarSomVotoAsync();

            await DisplayAlertAsync(
                "Voto confirmado",
                "Voto registrado com sucesso.",
                "OK");

            numeroDigitado = "";
            chapaSelecionada = null;

            lblNumero.Text = "---";
            lblChapa.Text = "Digite o número da chapa";
        

            btnConfirmar.IsEnabled = true;
        }
    }

    private async Task TocarSomVotoAsync()
    {
        var stream = await FileSystem.OpenAppPackageFileAsync("urnalab_voto.wav");
        audioPlayer = AudioManager.Current.CreatePlayer(stream);

        audioPlayer.Play();
    }

    private void EntrarModoImersivo()
    {
#if ANDROID
        var activity = Platform.CurrentActivity;

        if (activity?.Window is null)
            return;

        var window = activity.Window;

        WindowCompat.SetDecorFitsSystemWindows(window, false);

        var controller =
            WindowCompat.GetInsetsController(window, window.DecorView);

        controller?.SystemBarsBehavior =
            WindowInsetsControllerCompat.BehaviorShowTransientBarsBySwipe;

        controller?.Hide(WindowInsetsCompat.Type.SystemBars());
#endif
    }

    private void SairModoImersivo()
    {
#if ANDROID
        var activity = Platform.CurrentActivity;

        if (activity?.Window is null)
            return;

        var window = activity.Window;

        var controller =
            WindowCompat.GetInsetsController(window, window.DecorView);

        controller?.Show(WindowInsetsCompat.Type.SystemBars());

        WindowCompat.SetDecorFitsSystemWindows(window, true);
#endif
    }

}