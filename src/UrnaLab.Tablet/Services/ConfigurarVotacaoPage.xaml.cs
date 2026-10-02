using SQLite;
using UrnaLab.Tablet.Models;
using UrnaLab.Tablet.Data;

namespace UrnaLab.Tablet;

public partial class ConfigurarVotacaoPage : ContentPage
{
    private readonly ConfiguracaoEleicaoDatabase configuracaoDatabase = new();
    public ConfigurarVotacaoPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var configuracao = await configuracaoDatabase.ObterConfiguracaoAsync();

        if (configuracao.Status == "Encerrada")
        {
            lblStatusEleicao.Text = "Status da eleição: Encerrada";
            btnEncerrarEleicao.IsEnabled = false;
            btnNovaEleicao.IsEnabled = true;
        }

        else
        {
            lblStatusEleicao.Text = "Status da eleição: Aberta";
            btnEncerrarEleicao.IsEnabled = true;
            btnNovaEleicao.IsEnabled = false;
        }

    }

	private async void btnIdentificada_Click(object? sender, EventArgs e)
	{
        var configuracao = await configuracaoDatabase.ObterConfiguracaoAsync();

        if (configuracao.Status == "Encerrada")
        {
            await DisplayAlertAsync("Votação Bloqueada", "Não é possível fazer uma votação que já foi encerrada", "OK");
            return;
        }
        configuracao.ModoVotacao = "Identificada";

        await configuracaoDatabase.AtualizarAsync(configuracao);
        
        await Shell.Current.GoToAsync(nameof(LiberarVotacaoPage));
    }
	private async void btnAnonima_Click(object? sender, EventArgs e)
	{
		var configuracao = await configuracaoDatabase.ObterConfiguracaoAsync();
        
        if (configuracao.Status == "Encerrada")
        {
            await DisplayAlertAsync("Votação Bloqueada", "Não é possível fazer uma votação que já foi encerrada", "OK");
            return;
        }
        configuracao.ModoVotacao = "Anonima";
        await configuracaoDatabase.AtualizarAsync(configuracao);
        await Shell.Current.GoToAsync(nameof(VotacaoPage));
        
    }

    private async void btnEncerrarEleicao_Click(object? sender, EventArgs e)
    {
        var configuracao = await configuracaoDatabase.ObterConfiguracaoAsync();

        bool confirmar = await DisplayAlertAsync(
            "Encerrar eleição",
            "Tem certeza que deseja encerrar a eleição?",
            "SIM",
            "CANCELAR"
        );
       
        if (!confirmar)
            return;

        configuracao.Status = "Encerrada";
        await configuracaoDatabase.AtualizarAsync(configuracao);

        
        lblStatusEleicao.Text = "Status da eleição: ENCERRADA";
        btnEncerrarEleicao.IsEnabled = false;
        btnNovaEleicao.IsEnabled = true;
    }
    
    private async void btnNovaEleicao_Click(object? sender, EventArgs e)
    {
        var configuracao = await configuracaoDatabase.ObterConfiguracaoAsync();

        if (configuracao.Status != "Encerrada")
        {
            await DisplayAlertAsync("Votação Não Encerrada", "A votação ainda está aberta e não foi possível criar nova eleição!", "OK");
            return;

        }

        bool confirmar = await DisplayAlertAsync(
           "Nova eleição",
           "Tem certeza que deseja criar uma nova eleição?",
           "SIM",
           "CANCELAR"
       );

        if (!confirmar)
            return;

        await configuracaoDatabase.ResetarEleicaoAsync();
        lblStatusEleicao.Text = "Status da eleição: ABERTA";
        btnEncerrarEleicao.IsEnabled = true;
        btnNovaEleicao.IsEnabled = false;
        await DisplayAlertAsync("Sucesso", "Nova eleição criada e resetada com sucesso", "OK");
    }
}